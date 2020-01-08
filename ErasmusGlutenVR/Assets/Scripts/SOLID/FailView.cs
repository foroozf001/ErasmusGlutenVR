using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class FailView : MonoBehaviour, IEating
    {
        public void OnEat(EdibleObject o)
        {
            if (o.edibleObjectData.ContainsGluten)
                StartCoroutine(WaitRoutine(1));
        }

        IEnumerator WaitRoutine(int wait)
        {
            this.GetComponent<Canvas>().enabled = true;
            yield return new WaitForSeconds(wait);
            this.GetComponent<Canvas>().enabled = false;
        }
    }
}
