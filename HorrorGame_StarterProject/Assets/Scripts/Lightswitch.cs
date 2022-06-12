using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour, IInteractable {

    public bool _isOn = false;
    //This string identifies the light group that is activated by this switch
    public List<Light> _lightGroup = new List<Light>();

    //Toggle the current on/off state for the switch
    public void Interact()
    {
        //Toggle the switch status
        _isOn = !_isOn;
        //Get all the lightSources belonging to this light group and toggle their state
        foreach (Light lightSource in _lightGroup)
        {
            LightBulb lightBulb = lightSource.GetComponent<LightBulb>();
            //Toggle the state of the light component
            if (lightBulb != null) lightBulb.toggle();
        }
    }
}
