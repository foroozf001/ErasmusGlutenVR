using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

namespace ErasmusGluten
{
    [RequireComponent(typeof(Clock))]
    public class GameManager : Singleton<ErasmusGluten.GameManager>
        , IEating, IThrowing, ITutorial
    {
        public EdibleSpawner edibleSpawner;
        private bool _spawnerIsActive = true;

        public OvrAvatar player;
        public TutorialView tutorial;
        public GIPView gip;

        [HideInInspector] public bool leftHandContaminated;
        [HideInInspector] public bool rightHandContaminated;

        [HideInInspector] public int score;
        [HideInInspector] public int amountOfGlutenObjectsEaten;

        [HideInInspector] public bool introCompleted = false;

        #region delegates
        public delegate void OnStartThrowAnimation();
        public event OnStartThrowAnimation OnStartThrowEvent;
        #endregion

        #region interfaces
        private List<Transform> _rootTransforms;
        private List<IEating> _edibleInterfaces;
        private List<IThrowing> _throwableInterface;
        private List<ITutorial> _tutorialInterfaces;
        #endregion

        #region Gameplay
        IEnumerator SpawnEdibleObject()
        { 
            while (_spawnerIsActive)
            {
                int wait = edibleSpawner.spawnerData.BaseRespawnTime + Random.Range(0, edibleSpawner.spawnerData.DeviationRespawnTime);
                yield return new WaitForSeconds(wait);

                bool throwGluten = Random.Range(0f, 1f) <= edibleSpawner.spawnerData.ChanceToSpawnGluten;
                
                OnStartThrowEvent?.Invoke();
                
                if (throwGluten)
                    edibleSpawner.ThrowFoodRoutine(
                        edibleSpawner.CreateFoodObject(edibleSpawner.spawnerData.SpawnableGlutenObjects[Random.Range(0, edibleSpawner.spawnerData.SpawnableGlutenObjects.Count)], edibleSpawner.transform.position),
                        edibleSpawner.spawnerData.ThrowDirection
                        );
                else
                    edibleSpawner.ThrowFoodRoutine(
                        edibleSpawner.CreateFoodObject(edibleSpawner.spawnerData.SpawnableNonGlutenObjects[Random.Range(0, edibleSpawner.spawnerData.SpawnableNonGlutenObjects.Count)], edibleSpawner.transform.position),
                        edibleSpawner.spawnerData.ThrowDirection
                        );
            }
        }

        void StartTutorial()
        {
            for (int i = 0; i < _tutorialInterfaces.Count; i++)
                _tutorialInterfaces[i].OnTutorialStart();
        }

        void Reset()
        {
            score = 0;
            amountOfGlutenObjectsEaten = 0;
            introCompleted = false;
            leftHandContaminated = false;
            rightHandContaminated = false;
            gip.gameObject.SetActive(false);
        }

        void OnTimesUp()
        {
            _spawnerIsActive = false;
            Clock.Instance.paused = true;
            gip.gameObject.SetActive(true);
            //Start();
        }

        public void OnEat(EdibleObject o)
        {
            if (_edibleInterfaces.Count > 0)
                for (int i = 0; i < _edibleInterfaces.Count; i++)
                    if (_edibleInterfaces[i].GetType() != typeof(GameManager)) //Negeert zichzelf als interface
                        _edibleInterfaces[i].OnEat(o);

            if (!o.hasGluten)
                score++;
            else
                amountOfGlutenObjectsEaten++;

            if (o.IsTutorialEdible)
            {
                Destroy(o.gameObject);
                OnTutorialMiddle();
                return;
            }
            else if (o.IsTutorialEdibleMiddle) //Opnieuw de tutorial sectie starten want hij moet het gooien
            {
                Destroy(o.gameObject);
                OnTutorialMiddle();
                return;
            }
            else
            {
                Destroy(o.gameObject);
            }
        }

        public void OnHitChef(EdibleObject o)
        {
            if (_throwableInterface.Count > 0)
                for (int i = 0; i < _throwableInterface.Count; i++)
                    if (_throwableInterface[i].GetType() != typeof(GameManager))
                        _throwableInterface[i].OnHitChef(o);

            score++;

            if (o.IsTutorialEdibleMiddle)
                OnTutorialComplete();

            Destroy(o.gameObject);
        }

        public void OnTutorialStart()
        {
            if (tutorial)
                tutorial.GetComponentInChildren<TextBalloonView>(true).gameObject.SetActive(true);
            
            Vector3 introEdiblePosition;

            //Berekenen waar het intro object moet komen
            if (player)
                introEdiblePosition = player.transform.position + new Vector3(0f, .82f, .55f);
            else
                introEdiblePosition = new Vector3(0f, 1f, 1f);

            //Neem een willekeurig non-gluten object
            EdibleObject randomObject = edibleSpawner.spawnerData.SpawnableNonGlutenObjects.ElementAt(Random.Range(0, edibleSpawner.spawnerData.SpawnableNonGlutenObjects.Count));
            EdibleObject introEdible = Instantiate(randomObject);
            introEdible.transform.position = introEdiblePosition;
            introEdible.IsTutorialEdible = true;
        }

        public void OnTutorialComplete()
        {
            if (tutorial)
                tutorial.GetComponentInChildren<TextBalloonView>(true).gameObject.SetActive(false);

            for (int i = 0; i < _tutorialInterfaces.Count; i++)
                if (_tutorialInterfaces[i].GetType() != typeof(GameManager))
                    _tutorialInterfaces[i].OnTutorialComplete();

            introCompleted = true;
            _spawnerIsActive = true;
            StartCoroutine(SpawnEdibleObject());
        }

        public void OnTutorialMiddle()
        {
            for (int i = 0; i < _tutorialInterfaces.Count; i++)
                if (_tutorialInterfaces[i].GetType() != typeof(GameManager))
                    _tutorialInterfaces[i].OnTutorialMiddle();

            Vector3 introEdiblePosition;

            //Berekenen waar het intro object moet komen
            if (player)
                introEdiblePosition = player.transform.position + new Vector3(0f, .82f, .55f);
            else
                introEdiblePosition = new Vector3(0f, 1f, 1f);

            //Neem een willekeurig gluten object
            EdibleObject randomObject = edibleSpawner.spawnerData.SpawnableGlutenObjects.ElementAt(Random.Range(0, edibleSpawner.spawnerData.SpawnableNonGlutenObjects.Count));
            EdibleObject introEdible = Instantiate(randomObject);
            introEdible.transform.position = introEdiblePosition;
            introEdible.IsTutorialEdibleMiddle = true;
        }
        #endregion

        #region Monobehaviour
        private void Awake()
        {
            Assert.IsNotNull(edibleSpawner, "Food spawner");
            Assert.IsNotNull(player, "Player");
            Assert.IsNotNull(tutorial, "Tutorial");
            Assert.IsNotNull(gip, "Gip");

            Clock.Instance.OnTimesUpEvent += OnTimesUp;

            List<Transform> rootTransforms = (from t in FindObjectsOfType<Transform>()
                                               where t.parent == null
                                               select t).ToList();

            _edibleInterfaces = new List<IEating>();
            foreach (Transform t in rootTransforms)
                _edibleInterfaces.AddRange(t.GetComponentsInChildren<IEating>());

            _throwableInterface = new List<IThrowing>();
            foreach (Transform t in rootTransforms)
                _throwableInterface.AddRange(t.GetComponentsInChildren<IThrowing>());

            _tutorialInterfaces = new List<ITutorial>();
            foreach (Transform t in rootTransforms)
                _tutorialInterfaces.AddRange(t.GetComponentsInChildren<ITutorial>());
        }

        public void Start()
        {
            Reset();
            StartTutorial();
        }
        #endregion
    }
}