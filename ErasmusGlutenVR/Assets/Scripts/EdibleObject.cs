using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleObject : SpawnableObject
{
    public bool _hasGluten = false;

    public bool HasGluten()
    {
        return _hasGluten;
    }

    public void SetHasGluten(bool m_hasGluten)
    {
        _hasGluten = m_hasGluten;
    }
}
