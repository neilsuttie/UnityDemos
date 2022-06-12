using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    private int roundsSurvived = 0;
    private Text roundsCounter;
    private void Start()
    {
        roundsCounter = GetComponent<Text>();
    }

    public void Restart()
    {
        roundsSurvived = 0;
        roundsCounter.text = ($"You have survived {roundsSurvived} rounds");
    }

     public void IncrementCount(int amount)
    {
        roundsSurvived += amount;
        roundsCounter.text = ($"You have survived {roundsSurvived} rounds");
    }
}
