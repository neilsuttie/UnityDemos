using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { None, Cutscene, Gameplay, PauseMenu }

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.None;

    public GameObject player;
    public bool isLockedOnAwake = false;

    private void Awake()
    {
        if (isLockedOnAwake)
        {
            LockPlayer();
        }
    }

    public void OnStateChanged(GameState newState)
    {
        switch(newState)
        {
            case GameState.Gameplay:
                UnLockPlayer();
                break;
            case GameState.Cutscene:
                LockPlayer();
                break;
        }
    }

    private void LockPlayer()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<PlayerMovement>().isMovementLocked = true;
    }

    private void UnLockPlayer()
    {
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<PlayerMovement>().isMovementLocked = false;
    }
}
