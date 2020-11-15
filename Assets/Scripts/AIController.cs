using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar = null;
    // [SerializeField] private Transform groundTransform = null;
    // [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private int maxHealth = 100;
    // [SerializeField] private float moveSpeed = 10f;

    private int currentHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

}
