using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private int maxNumberOfScores = 10;

    private OrderedDictionary highScores = null;

    void Awake()
    {
        highScores = new OrderedDictionary();
    }

    public OrderedDictionary GetHighScores()
    {
        return highScores;
    }

    public void UpdateHighScores (string name, int score)
    {
        int i = 0;
        foreach (DictionaryEntry entry in highScores)
        {
            int hscore = (int)entry.Value;
            if (score > hscore)
            {
                highScores.Insert(i, name, score);
                return;
            }
            i++;
        }
    }
}
