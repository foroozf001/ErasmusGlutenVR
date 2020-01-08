using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public interface IEdibleObject
    {
        void OnEat();
        void OnHitChef();
    }
}
