using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class PlateSelfdestruct : MonoBehaviour
    , IGameLoop
    {
        public void OnGameEnds()
        {
            //Destroy(this.gameObject);
        }

        public void OnGameStart()
        {
            Destroy(this.gameObject);
        }
    }

}