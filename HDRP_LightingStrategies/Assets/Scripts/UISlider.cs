using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    public FloatVariable _myVariable;
    private Slider _mySlider;

    private void Start()
    {
        _mySlider = GetComponent<Slider>();
        _mySlider.value = _myVariable._initialValue;
    }

    public void OnChangeValue()
    {
        _myVariable._runtimeValue = _mySlider.value;
    }

}
