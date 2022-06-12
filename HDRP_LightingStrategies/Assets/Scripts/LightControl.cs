using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public FloatVariable myIntesity;
    public FloatVariable myTemperate;

    private Light _myLight;

    // Start is called before the first frame update
    void Start()
    {
        _myLight = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        _myLight.intensity = myIntesity._runtimeValue;
        _myLight.colorTemperature = myTemperate._runtimeValue;
    }
}
