using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public int score = 0;

    public void AddToScore(int amount)
    {
        score += amount;
    }
}
