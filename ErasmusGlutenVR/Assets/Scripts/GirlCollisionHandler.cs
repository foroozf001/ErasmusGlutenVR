using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCollisionHandler : MonoBehaviour
{
    public ParticleSystem[] hitspark;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (other.gameObject.GetComponent<EdibleObject>() != null)
            if (other.gameObject.GetComponent<EdibleObject>().HasGluten())
            {
                this.GetComponent<CharacterControl>().Hit = true;
                foreach (ParticleSystem p in hitspark)
                {
                    p.Play();
                }
                Destroy(other.gameObject);
            }
                
    }
}
