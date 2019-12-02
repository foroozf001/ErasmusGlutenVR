using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private CharacterControl characterControl;

    private void Awake()
    {
        characterControl = this.GetComponent<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VirtualInputManager.Instance.Throw)
            characterControl.Throw = true;
        else
            characterControl.Throw = false;

        if (VirtualInputManager.Instance.Hit)
            characterControl.Hit = true;
        else
            characterControl.Hit = false;
    }
}
