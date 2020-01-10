using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class GirlCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other == null)
                return;

            if (other.gameObject.GetComponent<EdibleObject>() != null)
                if (other.gameObject.GetComponent<EdibleObject>().hasGluten)
                {
                    GameManager.Instance.OnHitChef(other.gameObject.GetComponent<EdibleObject>());
                }
        }
    }
}

