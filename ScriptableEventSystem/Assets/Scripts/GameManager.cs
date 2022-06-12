using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Gameplay Events to listen for...
    public GameplayEvent playerDiedEvent;
    public GameplayEvent enemyDiedEvent;
    public GameplayEvent newRoundEvent;
    public GameplayEvent beginRoundEvent;

    //Flag to indicate when the player has been defeated
    private bool playerDefeated = false; 
    public float restartDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        Restart();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r") && playerDefeated)
        {
            playerDefeated = false;
            Restart();
        }
    }

    public void PlayerDied()
    {
        playerDefeated = true;
    }

    public void Restart()
    {
        newRoundEvent.Raise();
        Invoke("NewRound", restartDelay);
    }

    void NewRound()
    {
        beginRoundEvent.Raise();
    }
}
