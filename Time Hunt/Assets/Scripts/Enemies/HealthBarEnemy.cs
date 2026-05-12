using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.gameObject.SetActive(false);
    }

    public void UpdateMaxHealth(int maxHealth, int currentHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void UpdateCurrentHealth(int modify, int currentHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = currentHealth;
    }

}
