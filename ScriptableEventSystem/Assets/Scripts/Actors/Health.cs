using UnityEngine;

public class Health : MonoBehaviour
{
    public GameplayEvent playerDeathEvent;
     public FloatVariable health;

    private void Start()
    {
        //Restart the health in the case where it is zero. We assume that means we died on a previous round
        if(health.runtimeValue <= 0)
        health.runtimeValue = health.initialValue;
    }

    public void TakeDamage(float amount)
    {
        health.runtimeValue -= amount;

        Debug.Log("Taking damage " + health.runtimeValue);

        if (health.runtimeValue <= 0)
        {
            playerDeathEvent.Raise();
            OnPlayerDeath();
        }
    }

    public void OnPlayerDeath()
    {
        Destroy(gameObject);
    }
}
