using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

namespace ErasmusGluten
{
    public class GameManager : Singleton<ErasmusGluten.GameManager>
        , IEating
    {
        public EdibleSpawner edibleSpawner;
        private bool _spawnerIsActive = true;

        public bool leftHandContaminated;
        public bool rightHandContaminated;

        #region delegates
        public delegate void OnEatDelegate();
        public event OnEatDelegate OnEatEvent;
        #endregion

        #region interfaces
        private bool _includeInactive = false;
        private List<Transform> _rootTransforms;
        List<Transform> RootTransforms
        {
            get
            {
                if(_rootTransforms == null)
                {
                    _rootTransforms = (from t in FindObjectsOfType<Transform>()
                                       where t.parent == null
                                       select t).ToList();
                }
                return _rootTransforms;
            }
        }

        private List<IEating> _edibleObjects;
        List<IEating> EdibleObjects
        {
            get
            {
                if (_edibleObjects == null)
                {
                    _edibleObjects = new List<IEating>();
                    foreach (Transform t in _rootTransforms)
                        _edibleObjects.AddRange(t.GetComponentsInChildren<IEating>(_includeInactive));
                }
                return _edibleObjects;
            }
        }

        private List<IThrowing> _throwableObjects;
        List<IThrowing> ThrowableObjects
        {
            get
            {
                if (_throwableObjects == null)
                {
                    _throwableObjects = new List<IThrowing>();
                    foreach (Transform t in _rootTransforms)
                        _throwableObjects.AddRange(t.GetComponentsInChildren<IThrowing>(_includeInactive));
                }
                return _throwableObjects;
            }
        }
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
        }

        private void Start()
        {
            StartCoroutine(SpawnEdibleObject());
        }

        public void OnEat(EdibleObject o)
        {
            if (EdibleObjects.Count > 0)
                for (int i = 0; i < EdibleObjects.Count; i++)
                    EdibleObjects[i].OnEat(o);
            Destroy(o);
        }
        #endregion
    }
}