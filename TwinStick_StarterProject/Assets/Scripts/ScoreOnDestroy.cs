using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    public int scoreValue = 10;

    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
             GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().AddToScore(scoreValue);
    }
}
