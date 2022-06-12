
using System;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    PlayableDirector myDirector;
    public GameState targetState;
    // Start is called before the first frame update
    void Start()
    {
        myDirector = GetComponent<PlayableDirector>();

        myDirector.stopped += CutsceneFinished;
    }


    void CutsceneFinished(PlayableDirector aDirector)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SendMessage
            ("OnStateChanged", targetState);
    }
}
