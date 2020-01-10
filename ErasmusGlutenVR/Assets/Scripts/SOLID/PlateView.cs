using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten 
{ 
    public class PlateView : MonoBehaviour
        , IEating, IThrowing
    {
        [SerializeField] GameObject _plate;

        public void OnEat(EdibleObject o)
        {
            GameObject plate = GameObject.Instantiate(_plate);
            plate.transform.position = this.transform.position;
        }

        public void OnHitChef(EdibleObject o)
        {
            GameObject plate = GameObject.Instantiate(_plate);
            plate.transform.position = this.transform.position;
        }
    }
}
