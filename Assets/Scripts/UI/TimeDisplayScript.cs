// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text = null;
    [SerializeField] private float maxTime = 60f;

    public void SetMaxTime(float time)
    {
        maxTime = time;
    }

    public void ResetTime()
    {
        DisplayTime(maxTime);
    }

    public void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string display = string.Format("{0:0}:{1:00}", minutes, seconds);
        text.SetText(display);
    }
}
