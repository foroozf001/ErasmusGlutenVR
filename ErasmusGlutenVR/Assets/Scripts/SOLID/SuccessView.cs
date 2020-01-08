using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class SuccessView : MonoBehaviour, IEating
    {
        public void OnEat(EdibleObject o)
        {
            if (!o.edibleObjectData.ContainsGluten)
                this.GetComponent<ParticleSystem>().Play();
        }
    }
}