using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    public Health observedHealth;
    private Image myHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        myHealthBar = GetComponent<Image>();

        observedHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        myHealthBar.fillAmount = observedHealth.GetHealthAsPercentage();
    }
}
