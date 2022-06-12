using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    
    public Light _lightSource;

    private void Start()
    {
        GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        Toggle(false);
    }

    public void Toggle(bool value)
    {
        if(_lightSource)
        _lightSource.enabled = value;
    }
   
}
