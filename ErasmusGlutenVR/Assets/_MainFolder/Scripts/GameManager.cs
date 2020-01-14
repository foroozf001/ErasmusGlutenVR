using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;
using System;

namespace ErasmusGluten
{
    [RequireComponent(typeof(Clock))]
    public class GameManager : Singleton<GameManager>
        , IEating, IThrowing, ITutorial, IGameLoop
    {
        public EdibleSpawner edibleSpawner;
        private bool _spawnerIsActive = true;

        public OvrAvatar player;
        public TutorialView tutorial;

        [HideInInspector] public bool leftHandContaminated;
        [HideInInspector] public bool rightHandContaminated;

        [HideInInspector] public int score;
        [HideInInspector] public int amountOfGlutenObjectsEaten;
        [HideInInspector] public List<string> glutenObjectsEaten;

        [HideInInspector] public bool introCompleted = false;
        public int waitSecondsAfterTutorialComplete = 5;
        public int waitSecondsBeforeTutorial = 5;
        public int waitSecondsAfterGameComplete = 20;

        #region delegates
        public delegate void OnStartThrowAnimation();
        public event OnStartThrowAnimation OnStartThrowEvent;
        #endregion

        #region interfaces
        private List<Transform> _rootTransforms;
        private List<IEating> _edibleInterfaces;
        private List<IThrowing> _throwableInterface;
        private List<ITutorial> _tutorialInterfaces;
        private List<IGameLoop> _gameLoopInterfaces;
        #endregion

        #region Gameplay
        IEnumerator SpawnEdibleObject()
        { 
            while (_spawnerIsActive)
            {
                int wait = edibleSpawner.spawnerData.BaseRespawnTime + UnityEngine.Random.Range(0, edibleSpawner.spawnerData.DeviationRespawnTime);
                yield return new WaitForSeconds(wait);

                bool throwGluten = UnityEngine.Random.Range(0f, 1f) <= edibleSpawner.spawnerData.ChanceToSpawnGluten;
                
                OnStartThrowEvent?.Invoke();
                
                if (throwGluten)
                    edibleSpawner.ThrowFoodRoutine(
                        edibleSpawner.CreateFoodObject(edibleSpawner.spawnerData.SpawnableGlutenObjects[UnityEngine.Random.Range(0, edibleSpawner.spawnerData.SpawnableGlutenObjects.Count)], edibleSpawner.transform.position),
                        edibleSpawner.spawnerData.ThrowDirection
                        );
                else
                    edibleSpawner.ThrowFoodRoutine(
                        edibleSpawner.CreateFoodObject(edibleSpawner.spawnerData.SpawnableNonGlutenObjects[UnityEngine.Random.Range(0, edibleSpawner.spawnerData.SpawnableNonGlutenObjects.Count)], edibleSpawner.transform.position),
                        edibleSpawner.spawnerData.ThrowDirection
                        );
            }
        }

        IEnumerator StartTutorial(int wait)
        {
            yield return new WaitForSeconds(wait);

            for (int i = 0; i < _tutorialInterfaces.Count; i++)
                _tutorialInterfaces[i].OnTutorialStart();
        }

        void OnTimesUp()
        {
            OnGameEnds();
        }

        public void OnEat(EdibleObject o)
        {
            //Release object from the grabber
            o.GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(o.GetComponent<OVRGrabbable>());
            //Disable gravity
            o.GetComponent<Rigidbody>().useGravity = false;

            if (_edibleInterfaces.Count > 0)
                for (int i = 0; i < _edibleInterfaces.Count; i++)
                    if (_edibleInterfaces[i].GetType() != typeof(GameManager)) //Negeert zichzelf als interface
                        _edibleInterfaces[i].OnEat(o);

            if (!o.hasGluten)
                score++;
            else
            {
                amountOfGlutenObjectsEaten++;
                if (o.edibleObjectData.ContainsGluten && !glutenObjectsEaten.Contains(o.name))
                    glutenObjectsEaten.Add(o.name);
            }
                

            //Instead of destroying the edible move it somewhere outside the scene and set invisible and wait for destroy
            //Spawning many objects and destroying them causes the ovrgrabber to bug because it gets
            //destroyed before the grabber is able to remove it, it thinks grabber is still holding something
            if (o.IsTutorialEdible)
            {
                //Destroy(o.gameObject);
                o.gameObject.GetComponent<MeshRenderer>().enabled = false;
                o.gameObject.transform.position = new Vector3(3, 1, 3);
                o.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                o.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                OnTutorialComplete();
            }
            else
            {
                o.gameObject.GetComponent<MeshRenderer>().enabled = false;
                o.gameObject.transform.position = new Vector3(3, 1, 3);
                o.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                o.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
                
        }

        public void OnHitChef(EdibleObject o)
        {
            if (_throwableInterface.Count > 0)
                for (int i = 0; i < _throwableInterface.Count; i++)
                    if (_throwableInterface[i].GetType() != typeof(GameManager))
                        _throwableInterface[i].OnHitChef(o);
            score++;
            Destroy(o.gameObject);
        }

        public void OnTutorialStart()
        {
            tutorial.GetComponentInChildren<TextBalloonView>(true).gameObject.SetActive(true);
            
            Vector3 introEdiblePosition;

            //Berekenen waar het intro object moet komen
            if (player)
                introEdiblePosition = player.transform.position + new Vector3(0f, 1f, .62f);
            else
                introEdiblePosition = new Vector3(0f, 1f, 1f);

            //Neem een willekeurig non-gluten object
            EdibleObject randomObject = edibleSpawner.spawnerData.SpawnableNonGlutenObjects.ElementAt(UnityEngine.Random.Range(0, edibleSpawner.spawnerData.SpawnableNonGlutenObjects.Count));
            EdibleObject introEdible = Instantiate(randomObject);
            introEdible.transform.position = introEdiblePosition;
            introEdible.IsTutorialEdible = true;
        }

        public void OnTutorialComplete()
        {
            for (int i = 0; i < _tutorialInterfaces.Count; i++)
                if (_tutorialInterfaces[i].GetType() != typeof(GameManager))
                    _tutorialInterfaces[i].OnTutorialComplete();

            StartCoroutine(WaitAfterTutorialCompleteRoutine(waitSecondsAfterTutorialComplete));
        }

        IEnumerator WaitAfterTutorialCompleteRoutine(float wait)
        {
            yield return new WaitForSeconds(wait);

            introCompleted = true;
            _spawnerIsActive = true;
            StartCoroutine(SpawnEdibleObject());
        }

        public void OnTutorialMiddle()
        {
            //Tutorial section
        }
        #endregion

        #region Monobehaviour
        private void Awake()
        {
            Assert.IsNotNull(edibleSpawner, "Food spawner");
            Assert.IsNotNull(player, "Player");
            Assert.IsNotNull(tutorial, "Tutorial");

            Clock.Instance.OnTimesUpEvent += OnTimesUp;

            glutenObjectsEaten = new List<string>();

            List<Transform> rootTransforms = (from t in FindObjectsOfType<Transform>()
                                               where t.parent == null
                                               select t).ToList();

            _edibleInterfaces = new List<IEating>();
            foreach (Transform t in rootTransforms)
                _edibleInterfaces.AddRange(t.GetComponentsInChildren<IEating>(true));

            _throwableInterface = new List<IThrowing>();
            foreach (Transform t in rootTransforms)
                _throwableInterface.AddRange(t.GetComponentsInChildren<IThrowing>(true));

            _tutorialInterfaces = new List<ITutorial>();
            foreach (Transform t in rootTransforms)
                _tutorialInterfaces.AddRange(t.GetComponentsInChildren<ITutorial>(true));
            
            _gameLoopInterfaces = new List<IGameLoop>();
            foreach (Transform t in rootTransforms)
                _gameLoopInterfaces.AddRange(t.GetComponentsInChildren<IGameLoop>(true));
        }

        IEnumerator WaitBeforeStart(float wait)
        {
            yield return new WaitForSeconds(wait);
            OnGameStart();
        }

        private void Reset()
        {
            score = 0;
            amountOfGlutenObjectsEaten = 0;
            introCompleted = false;
            leftHandContaminated = false;
            rightHandContaminated = false;
            glutenObjectsEaten.Clear();
            DestroyAllPlates();
        }

        private void DestroyAllPlates()
        {
            List<Plate> plates = (from t in FindObjectsOfType<Plate>()
                                              select t).ToList();
            foreach (Plate t in plates)
                Destroy(t.gameObject);
        }

        public void Start()
        {
            OnGameStart();
        }

        public void OnGameStart()
        {
            Reset();

            if (_gameLoopInterfaces.Count > 0)
                for (int i = 0; i < _gameLoopInterfaces.Count; i++)
                    if (_gameLoopInterfaces[i].GetType() != typeof(GameManager)) //Negeert zichzelf als interface
                        _gameLoopInterfaces[i].OnGameStart();

            StartCoroutine(StartTutorial(waitSecondsBeforeTutorial));
        }

        public void OnGameEnds()
        {
            _spawnerIsActive = false;

            if (_gameLoopInterfaces.Count > 0)
                for (int i = 0; i < _gameLoopInterfaces.Count; i++)
                    if (_gameLoopInterfaces[i].GetType() != typeof(GameManager)) //Negeert zichzelf als interface
                        _gameLoopInterfaces[i].OnGameEnds();

            StartCoroutine(WaitBeforeStart(waitSecondsAfterGameComplete));
        }
        #endregion
    }
}