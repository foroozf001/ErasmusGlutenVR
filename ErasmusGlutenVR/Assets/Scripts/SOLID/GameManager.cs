using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

namespace ErasmusGluten
{
    [RequireComponent(typeof(Clock))]
    public class GameManager : Singleton<ErasmusGluten.GameManager>
        , IEating
    {
        public EdibleSpawner edibleSpawner;
        private bool _spawnerIsActive = true;

        public bool leftHandContaminated;
        public bool rightHandContaminated;

        #region interfaces
        private List<Transform> _rootTransforms;
        private List<IEating> _edibleObjects;
        private List<IThrowing> _throwableObjects;
        #endregion

        #region Gameplay
        IEnumerator SpawnEdibleObject()
        { 
            while (_spawnerIsActive)
            {
                int wait = edibleSpawner.spawnerData.BaseRespawnTime + Random.Range(0, edibleSpawner.spawnerData.DeviationRespawnTime);
                yield return new WaitForSeconds(wait);

                bool throwGluten = Random.Range(0f, 1f) <= edibleSpawner.spawnerData.ChanceToSpawnGluten;
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
        #endregion

        #region Monobehaviour
        private void Awake()
        {
            Assert.IsNotNull(edibleSpawner, "Food spawner");

            List<Transform> rootTransforms = (from t in FindObjectsOfType<Transform>()
                                               where t.parent == null
                                               select t).ToList();

            _edibleObjects = new List<IEating>();
            foreach (Transform t in rootTransforms)
                _edibleObjects.AddRange(t.GetComponentsInChildren<IEating>());

            _throwableObjects = new List<IThrowing>();
            foreach (Transform t in rootTransforms)
                _throwableObjects.AddRange(t.GetComponentsInChildren<IThrowing>());
        }

        private void Start()
        {
            StartCoroutine(SpawnEdibleObject());
        }

        public void OnEat(EdibleObject o)
        {
            if (_edibleObjects.Count > 0)
                for (int i = 0; i < _edibleObjects.Count; i++)
                    if (_edibleObjects[i].GetType() != typeof(GameManager)) //Negeert zichzelf als interface
                        _edibleObjects[i].OnEat(o);
            Destroy(o.gameObject);
        }
        #endregion
    }
}