// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private HealthBarScript healthBar = null;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public int currentHealth = 100; // public for debug purposes

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void SetHealthBar(HealthBarScript bar)
    {
        healthBar = bar;
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;

        // Update health bar, if applicable
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Update health bar, if applicable
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void LoseHealth(int health)
    {
        currentHealth -= health;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false); // better to set inactive than destroy to avoid null references
        }

        // Update health bar, if applicable
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(maxHealth);
        }
    }

}
