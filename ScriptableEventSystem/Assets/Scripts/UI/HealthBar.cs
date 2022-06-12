using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public FloatVariable health;
    public Image healthBar;

    private void Update()
    { 
        healthBar.fillAmount = (health.runtimeValue) /(health.initialValue);
    }

}
