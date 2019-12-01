using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem success;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Edible")
        {
            success.Play();
        }
    }
}
