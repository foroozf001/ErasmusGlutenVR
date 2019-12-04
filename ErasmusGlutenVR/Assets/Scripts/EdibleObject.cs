using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleObject : SpawnableObject
{
    public bool _hasGluten = false;

    private void Start()
    {
        WaitForDestroy(this.lifetimeInSeconds);
    }

    public bool HasGluten()
    {
        return _hasGluten;
    }

    public void SetHasGluten(bool m_hasGluten)
    {
        _hasGluten = m_hasGluten;
    }

    public void WaitForDestroy(int seconds)
    {
        Object.Destroy(this.gameObject, (float)seconds);
    }
}
