using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten {
    [CreateAssetMenu(menuName = "ErasmusGlutenVR/New Food Object Data", fileName = "NewFoodObjectData.asset")]
    public partial class EdibleObjectData : ScriptableObject
    {
        [Header("Food contains gluten")]
        [SerializeField] private bool _containsGluten= false;

        public bool ContainsGluten
        {
            get { return _containsGluten; }
        }

        [Header("Max lifetime in seconds")]
        [SerializeField] private int _maxLifetimeInSeconds = 10;

        public int MaxLifetimeInSeconds
        {
            get { return _maxLifetimeInSeconds; }
        }
    }
}
