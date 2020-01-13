using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    interface IGameLoop
    {
        void OnGameStart();
        void OnGameEnds();
    }
}
