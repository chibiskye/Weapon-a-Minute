// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool debugMode = false; // public for debugging purposes

    [SerializeField] private GameObject screen = null;
    // [SerializeField] private Camera screenCamera = null;
    [SerializeField] private UIManager uiManager = null;
    [SerializeField] private GameObject levelPrefab = null;
    [SerializeField] private GameObject playerPrefab = null;

    // private UIManager uiManager = null;
    // private Camera screenCamera = null;
    private Camera m_camera = null;
    private GameObject level = null;
    private GameObject player = null;

    void Awake()
    {
        // uiManager = FindObjectOfType<UIManager>();
        // screenCamera = FindObjectOfType<Camera>();
        m_camera = Camera.main;
        screen.SetActive(true);
    }

    void Start()
    {
        if (debugMode)
        {
            EnableDebugMode();
        }
        else 
        {
            uiManager.ShowScreenOnly("Title");
        }
    }

    public void StartGame()
    {
        // screenCamera.enabled = false;
        level = Instantiate(levelPrefab, this.transform);
        player = Instantiate(playerPrefab, this.transform);
    }

    private void EnableDebugMode()
    {
        // screenCamera.enabled = false;
        uiManager.ShowScreenOnly("Player");
        level = Instantiate(levelPrefab, this.transform);
        player = Instantiate(playerPrefab, this.transform);
    }

// Singleton code -------------------------------------------------------------------------

    // private static GameManager _instance;

    // public static GameManager Instance {
    //     get {
    //         if (_instance == null)
    //         {
    //             _instance = new GameManager();
    //         }
    //         return _instance;
    //     }
    // }

    // void Awake()
    // {
    //     if (_instance != null && _instance != this)
    //     {
    //         Destroy(this.gameObject); // destroy any existing instances
    //     }
    //     else
    //     {
    //         _instance = this;
    //         DontDestroyOnLoad(this); // persist over scene changes
    //     }
    // }
}
