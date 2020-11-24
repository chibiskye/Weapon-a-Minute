﻿using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider = null;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Sets max value for slider
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    // Sets current value for slider
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}