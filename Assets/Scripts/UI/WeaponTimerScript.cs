// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Timer implemented with the help of the tutorial:
//  - https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

public class WeaponTimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private float maxTime = 60f;

    private float timeLeft = 60f;
    public bool timerOn = false; // public for debug purposes

    void Awake()
    {
        timeLeft = maxTime;
        SetTime();
    }

    public void SetMaxTime(float time)
    {
        maxTime = time;
        timeLeft = time;
    }

    public void RestartTimer()  { timeLeft = maxTime; }
    public void StartTimer()    { timerOn = true; }
    public void StopTimer()     { timerOn = false; }

    void Update()
    {
        // Pause timer
        if (!timerOn) return;

        if (timeLeft < 1f)
        {
            // Reset timer
            SetTime();

            Debug.Log("Time's up! Time to switch weapons!");
            timerOn = false;
            timeLeft = maxTime;
        }
        else
        {
            // Countdown and update display
            timeLeft -= Time.deltaTime;
            SetTime();
        }
    }

    private void SetTime()
    {
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        string time = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.SetText(time);
    }
}
