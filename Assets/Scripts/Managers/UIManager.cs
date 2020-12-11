using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private FadeAwayScript fadeAwayScript = null;
    [SerializeField] private GameObject titleScreen = null;
    [SerializeField] private GameObject controlsScreen = null;
    [SerializeField] private GameObject highScoreScreen = null;
    [SerializeField] private GameObject pauseScreen = null;
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private GameObject playerScreen = null;

    private Dictionary<string, GameObject> screensList = null;
    
    void Awake()
    {
        screensList = new Dictionary<string, GameObject>();
        screensList.Add("Player", playerScreen); // must have reference to player screen

        if (titleScreen != null)        screensList.Add("Title", titleScreen);
        if (controlsScreen != null)     screensList.Add("Controls", controlsScreen);
        if (highScoreScreen != null)    screensList.Add("HighScore", highScoreScreen);
        if (pauseScreen != null)        screensList.Add("Pause", pauseScreen);
        if (gameOverScreen != null)     screensList.Add("GameOver", gameOverScreen);
    }

    public void ShowScreenOnly (string screenName)
    {
        StartCoroutine(fadeAwayScript.FadeAway());

        foreach (var item in screensList)
        {
            GameObject screen = item.Value;
            screen.SetActive((item.Key == screenName));
        }
    }

    public void ShowScreenForeground (string screenName)
    {
        GameObject screen = screensList[screenName];
        if (screen != null)
        {
            screen.SetActive(true);
        }
    }

    public void HideScreen (string screenName)
    {
        GameObject screen = screensList[screenName];
        if (screen != null)
        {
            screen.SetActive(false);
        }
    }

    public void ResetPlayerScreen()
    {
        DebugLogScript debugLog = GetComponentInChildren<DebugLogScript>();
        TimeDisplayScript timeDisplay = GetComponentInChildren<TimeDisplayScript>();
        WeaponDisplayScript weaponDisplay = GetComponentInChildren<WeaponDisplayScript>();
        debugLog.ClearLog();
        timeDisplay.ResetTime();
        weaponDisplay.DisplayWeapon("");
    }
}
