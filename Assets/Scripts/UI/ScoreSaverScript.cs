// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaverScript : MonoBehaviour
{
    [SerializeField] private Text nameInputText = null;

    private InfoDisplayScript infoDisplay = null;

    void Awake()
    {
        infoDisplay = GetComponent<InfoDisplayScript>();
    }

    void OnEnable()
    {
        infoDisplay.DisplayScore(PlayerController.PlayerScore);
    }
    
    public void SaveScore()
    {
        if (nameInputText != null)
        {
            Debug.Log(nameInputText.text);
            Debug.Log(PlayerController.PlayerScore);
        }
    }

}
