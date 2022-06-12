using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {
    
    public Image _batteryPercentageIndicator;
    private Flashlight _flashlight;

    private Text _label;

    private void Start()
    {
        _flashlight = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>();

        _label = GetComponentInChildren<Text>();

        displayMessage("Press F to toggle Flashlight", 3f);
    }

    void Update () {
        //Update the image fill amount based on the current battery fill percentage. Normalise scale
        _batteryPercentageIndicator.fillAmount = _flashlight.getBatteryPercentage()/100.0f;
    }

    public void displayMessage(string message)
    {
        _label.text = message;
    }

    public void displayMessage(string message, float time)
    {
        displayMessage(message);

        Invoke("ClearHUD", time);
    }
    
    public void ClearHUD()
    {
        //Clear the text label
        _label.text = "";
    }
}
