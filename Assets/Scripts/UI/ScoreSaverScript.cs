// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaverScript : MonoBehaviour
{
    [SerializeField] private Text nameInputText = null;
    private HighScoreScript highScore = null;
    private InfoDisplayScript infoDisplay = null;

    void Awake()
    {
        highScore = transform.parent.GetComponentInChildren<HighScoreScript>();
        infoDisplay = GetComponent<InfoDisplayScript>();
    }

    void OnEnable()
    {
        if (infoDisplay != null)
        {
            infoDisplay.DisplayScore(PlayerController.PlayerScore);
        }
    }
    
    public void SaveScore()
    {
        if (highScore != null && nameInputText != null)
        {
            highScore.UpdateHighScores(nameInputText.text, PlayerController.PlayerScore);
        }
    }

}
