using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

namespace ErasmusGluten
{
    public class GameManager : Singleton<GameManager>
    {
        public static EdibleSpawner edibleSpawner;

        public static bool LeftHandContaminated;
        public static bool RightHandContaminated;

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

        #region Monobehaviour
        private void Awake()
        {
            Assert.IsNotNull(edibleSpawner, "Food spawner");
        }
        #endregion
    }
}