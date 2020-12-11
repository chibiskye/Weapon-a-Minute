// using System.Collections;
// using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI namesText = null;
    [SerializeField] private TextMeshProUGUI scoresText = null;
    [SerializeField] private int maxHighScores = 10;
    [SerializeField] private int numScoresToShow = 10;

    public void UpdateHighScores(string name, int score)
    {
        int scoreCount = PlayerPrefs.GetInt("HighScoreCount");
        if (scoreCount == 0) {
            SetHighScore(scoreCount, name, score);
        }
        else {
            for (int i = 0; i < scoreCount || i < maxHighScores; i++)
            {
                int hscore = PlayerPrefs.GetInt($"HighScore{i}_Score");
                if (score > hscore) {
                    ShiftScoresAfterIndex(i);
                    SetHighScore(i, name, score);
                    break;
                }
            }
        }
        DisplayScores();
    }

    public void DisplayScores()
    {
        int scoreCount = PlayerPrefs.GetInt("HighScoreCount");
        namesText.text = "";
        scoresText.text = "";

        for (int i = 0; i < numScoresToShow && i < scoreCount; i++)
        {
            namesText.text += PlayerPrefs.GetString($"HighScore{i}_Name") + "\n";
            scoresText.text += PlayerPrefs.GetInt($"HighScore{i}_Score") + "\n";
        }
    }

    private void SetHighScore(int rank, string name, int score)
    {
        PlayerPrefs.SetString($"HighScore{rank}_Name", name);
        PlayerPrefs.SetInt($"HighScore{rank}_Score", score);
        PlayerPrefs.SetInt("HighScoreCount", PlayerPrefs.GetInt("HighScoreCount")+1);
    }

    private void ShiftScoresAfterIndex(int index)
    {
        int startIndex = Mathf.Max(PlayerPrefs.GetInt("HighScoreCount")+1, maxHighScores);
        for (int i = startIndex; i > index; i--)
        {
            string prevName = PlayerPrefs.GetString($"HighScore{i-1}_Name");
            int prevScore = PlayerPrefs.GetInt($"HighScore{i-1}_Score");
            SetHighScore(i, prevName, prevScore);
        }
    }
}
