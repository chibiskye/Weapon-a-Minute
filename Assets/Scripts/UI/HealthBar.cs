using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private Slider slider = null;
    private TextMeshProUGUI healthText = null;

    void Awake()
    {
        slider = GetComponent<Slider>();
        healthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Sets max value for slider
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        if (healthText != null)
        {
            healthText.SetText(string.Format("{0} / {1}", slider.maxValue, slider.maxValue));
        }
    }

    // Sets current value for slider
    public void SetHealth(int health)
    {
        slider.value = health;
        if (healthText != null)
        {
            healthText.SetText(string.Format("{0} / {1}", slider.value, slider.maxValue));
        }
    }
}
