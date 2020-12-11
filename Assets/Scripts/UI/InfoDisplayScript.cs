// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDisplayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    public void ResetWave()
    {
        DisplayWave(0);
    }

    public void ResetScore()
    {
        DisplayScore(0);
    }

    public void DisplayWave(int wave)
    {
        if (waveText != null)
        {
            waveText.SetText(string.Format("Wave {0}", wave));
        }
    }

    public void DisplayScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.SetText(string.Format("Score: {0}", score));
        }
    }
}
