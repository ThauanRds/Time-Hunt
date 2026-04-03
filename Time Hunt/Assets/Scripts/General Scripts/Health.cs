using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private UnityEvent<int, int> OnHealthUpdate;  // Chamado quando a saúde é atualizada, passando a saúde atual e a saúde máxima
    [SerializeField] private UnityEvent<int, int> OnReducetHealth;  // Chamado quando a saúde é deduzida, passando a quantidade de saúde perdida e a saúde atual
    [SerializeField] private UnityEvent<int, int> OnGainHealth;    // Chamado quando a saúde é ganha, passando a quantidade de saúde ganha e a saúde atual
    [SerializeField] private UnityEvent OnDie;  // Chamado quando a saúde chega a zero

    private void Start()
    {
        UpdateMaxHealth(maxHealth, currentHealth);
    }

    public void UpdateMaxHealth(int maxHealth, int currentHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;

        OnHealthUpdate.Invoke(maxHealth, currentHealth);
    }

    public void ReduceHealth(int amount)
    {
        currentHealth -= amount;

        OnReducetHealth.Invoke(amount, currentHealth);

        if (currentHealth <= 0)
        {
            OnDie.Invoke();
        }
    }

    public void GainHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnGainHealth.Invoke(amount, currentHealth);
    }
}
