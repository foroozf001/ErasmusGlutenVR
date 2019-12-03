using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool LeftHandContaminated;
    public bool RightHandContaminated;

    // Start is called before the first frame update
    void Start()
    {
        LeftHandContaminated = false;
        RightHandContaminated = false;
    }
}
