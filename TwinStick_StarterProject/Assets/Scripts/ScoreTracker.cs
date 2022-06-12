using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreTracker : MonoBehaviour
{
    private Score observedScore;

    private Text myScoreTextField;

    // Start is called before the first frame update
    void Start()
    {
        myScoreTextField = GetComponent<Text>();

        if(GameObject.FindGameObjectWithTag("Player") != null)
             observedScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        myScoreTextField.text = "Score: " + observedScore.score;
    }
}
