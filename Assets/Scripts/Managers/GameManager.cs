// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public static bool DebugMode = true; // public static so that other classes can reference
    public static bool GameStart = false;
    public static bool GamePaused = false;
    public static bool GameOver = false;

    [SerializeField] private GameObject levelPrefab = null;
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject enemyWaveSystem = null;

    private WaveSystemScript waveSystem = null;
    private UIManager uiManager = null;
    private GameControls gameControls = null;
    private Camera m_camera = null;
    private GameObject level = null;
    private GameObject player = null;

    void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject); // destroy any existing instances
        } else {
            _instance = this;
            // DontDestroyOnLoad(this); // persist over scene changes
        }

        m_camera = Camera.main;
        if (uiManager == null) {
            uiManager = FindObjectOfType<UIManager>();
        }

        gameControls = new GameControls();
        gameControls.GameState.Pause.performed += _ => TogglePauseGame();
    }

    void OnEnable()
    {
        gameControls.Enable();
    }

    void OnDisable()
    {
        gameControls.Disable();
    }

    void Start()
    {
        if (DebugMode) {
            StartGame();
        } else {
            ShowTitleScreen();
        }
    }

    public void ShowTitleScreen()
    {
        ResetLevel();
        ResetState();
        m_camera.enabled = true;
        uiManager.ShowScreenOnly("Title");
    }

    public void StartGame()
    {
        LockCursor();
        m_camera.enabled = false;
        uiManager.ShowScreenOnly("Player");

        level = Instantiate(levelPrefab, this.transform);
        player = Instantiate(playerPrefab, this.transform);
        waveSystem = Instantiate(enemyWaveSystem, this.transform).GetComponent<WaveSystemScript>();
        GameStart = true;
    }

    void Update()
    {
        if (GameOver || GamePaused)
        {
            UnlockCursor();
        }

        if (player != null && !player.active)
        {
            GameEnd();
        }
    }

    public void TogglePauseGame()
    {
        // Check if game has ended
        if (!GameStart || GameOver) return;

        GamePaused = !GamePaused;
        if (GamePaused) // pause
        {
            Time.timeScale = 0f;
            uiManager.ShowScreenForeground("Pause");
        }
        else // unpause
        {
            Time.timeScale = 1f;
            uiManager.HideScreen("Pause");
            LockCursor();
        }
    }

    public void RestartGame()
    {
        ResetLevel();
        ResetState();
        StartGame();
    }

    public void GameEnd()
    {
        GameOver = true;
        ResetLevel();
        m_camera.enabled = true;
        uiManager.ShowScreenOnly("GameOver");
    }

    private void ResetLevel()
    {
        if (player != null)     Destroy(player.gameObject);
        if (level != null)      Destroy(level.gameObject);
        if (waveSystem != null) Destroy(waveSystem.gameObject);
        GameObject[] destroyables = GameObject.FindGameObjectsWithTag("Destroyable");
        foreach (GameObject obj in destroyables) {
            Destroy(obj);
        }

        uiManager.HideScreen("Pause");
        uiManager.HideScreen("GameOver");
        uiManager.ResetPlayerScreen();
    }

    private void ResetState()
    {
        Time.timeScale = 1f;
        GameStart = false;
        GamePaused = false;
        GameOver = false;
    }

    private void LockCursor()
    {
        // Lock cursor to center of screen and make it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        // Free cursor and make it visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

// Singleton code -------------------------------------------------------------------------

    
}
