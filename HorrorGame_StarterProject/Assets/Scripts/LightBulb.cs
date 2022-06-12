using System.Collections;
using UnityEngine;

public class LightBulb : MonoBehaviour {

    //Lightbulbs states 
    public bool _isOn  = false;
    public bool _flickering = false;

    //Objects lightComponent
    private Light _lightSource;
    //Physical light source's physical object renderer
    private Renderer _filament;

    //Max and Min range for the light used for flickering
    public float _minRange = 0.0f;
    public float _maxRange = 10.0f;

    //Max and min intensity of the light. Used for flickering
    public float _minIntensity = 0.0f;
    public float _maxIntensity = 1.0f;

    // Use this for initialization
    private void Start () {
        _lightSource = GetComponent<Light>();
        _lightSource.enabled = _isOn;

        //Get a reference to the lightbulb's filament renderer
        _filament = GetComponent<Renderer>();
        //Set the emissive material
        SetEmissiveMaterial(_isOn);
    }
	
	// Update is called once per frame
	private void Update () {
        //Is the light bulb flickering?
        if (_flickering) {
            _lightSource.intensity = Random.Range(_minIntensity, _maxIntensity);
            _lightSource.range = Random.Range(_minRange, _maxRange);
        }
	}
    public void toggle()
    {
        //Toggle the bolean flag
        _isOn = !_isOn;

        //Turn off the light is it is off
        _lightSource.enabled = _isOn;

        //Flip the emission material
        SetEmissiveMaterial(_isOn);
    }
    public void FadeToBlack()
    {
        StartCoroutine(DecreaseToMin());
    }

    IEnumerator DecreaseToMin()
    {
       while(_maxIntensity > 0f) {
            _minIntensity = Mathf.Lerp(_minIntensity, 0f, .01f);
            _maxIntensity = Mathf.Lerp(_maxIntensity, 0f, .01f);
            yield return null;
        }
    }
    public void SetEmissiveMaterial(bool isOn)
    {
        if (isOn)
        {
            _filament.material.SetColor("_EmissionColor", Color.white);
        }
        else
        {
            _filament.material.SetColor("_EmissionColor", Color.black);
        }
    }
 }
