using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{

    public void ShowTextForTime(float seconds)
    {
        ShowText();
        Invoke("HideText", seconds);
    }

    public void ShowText()
    {
        GetComponent<Text>().enabled = true;
    }

    public void HideText()
    {
        GetComponent<Text>().enabled = false;
    }

}
