using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(0, 100), Tooltip("The objects health")]
    public float health;

    [Range(0, 100), Tooltip("the objects max health")]
    public int maxHealth;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public float GetHealthAsPercentage()
    {
        return (float)health / maxHealth;
    }
}
