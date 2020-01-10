using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class SuccessView : MonoBehaviour, IEating
    {
        public void OnEat(EdibleObject o)
        {
            if (!o.hasGluten)
                this.GetComponent<ParticleSystem>().Play();
        }
    }
}