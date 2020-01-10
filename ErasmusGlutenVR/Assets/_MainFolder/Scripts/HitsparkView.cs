using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class HitsparkView : MonoBehaviour
        , IThrowing
    {
        private List<ParticleSystem> _particleSystems;

        public void OnHitChef(EdibleObject o)
        {
            for (int i = 0; i < _particleSystems.Count; i++)
                _particleSystems[i].Play();
        }

        // Start is called before the first frame update
        void Start()
        {
            _particleSystems = new List<ParticleSystem>();

            foreach (Transform eachChild in transform)
                if (eachChild.GetComponent<ParticleSystem>())
                    _particleSystems.Add(eachChild.GetComponent<ParticleSystem>());
        }
    }
}
