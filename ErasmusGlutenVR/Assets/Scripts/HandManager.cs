using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer grabberLeft;
    [SerializeField] SkinnedMeshRenderer grabberRight;
    [SerializeField] Material red;
    [SerializeField] Material green;

    public void ChangeMaterial(SkinnedMeshRenderer s, Material m)
    {
        s.material = m;
    }
}
