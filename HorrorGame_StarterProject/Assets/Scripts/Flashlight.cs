using UnityEngine;

public class Flashlight : MonoBehaviour {

    public bool _isOn = false;
    public Light _Spotlight;
    public Light _areaLight;

    private float _batteryPower = 100f;
    public float _batteryDrainAmount = 1f;
    public float _batteryDrainTimer = .3f;


    private void Start()
    {
        //If the flash light is on be default start draining on start
        if (_isOn)
        {
            StartBatteryDrain();
        }
    }

    // Update is called once per frame
    void Update ()
    {
     //Toggle whether out light is on
     if(Input.GetKeyDown("f") && _batteryPower > 0.0f)
     {
            Toggle();
     }
    }

    public void Toggle()
    {
        //Toggle the current state of the flashlight
        _isOn = !_isOn;


        //Set the assigned light sources based on the current value of isOn
        if (_Spotlight != null && _areaLight != null)
        {
            _Spotlight.enabled = _isOn;
            _areaLight.enabled = _isOn;
        }

        //Now start draining the battery is on or stop if off
        if (_isOn)
        {
            StartBatteryDrain();
        }
        else
        {
            StopBatteryDrain();
        }
    }

    void DrainBattery()
    {
        if (_batteryPower - _batteryDrainAmount > 0.0f)
        {
            _batteryPower -= _batteryDrainAmount;
        }
        else
        {
            _batteryPower = 0.0f;
            Toggle();
        }
    }

    void StartBatteryDrain()
    {
        InvokeRepeating("DrainBattery", _batteryDrainTimer, _batteryDrainTimer);
    }

    void StopBatteryDrain()
    {
        CancelInvoke();
    }
    public float getBatteryPercentage()
    {
        return _batteryPower;
    }
}
