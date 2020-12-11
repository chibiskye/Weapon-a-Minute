using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Camera controls implemented with the help of the following tutorials:
// - Third person movement = https://youtu.be/4HpC--2iowE

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private LayerMask detectMasks;
    [SerializeField] private DebugLogScript debugLog = null;
    [SerializeField] private TimeDisplayScript timeDisplay = null;
    [SerializeField] private WeaponDisplayScript weaponDisplay = null;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float timeToSwitch = 60f;
    [SerializeField] private GameObject[] weaponsList = null;

    // private GameManager gameManager = null;
    private CharacterController characterController = null;
    private PlayerControls playerControls = null;
    private Transform cameraTransform = null;
    private HealthScript healthScript = null;
    private float turnSmoothVelocity; // used as reference variable
    
    private bool switchTimerOn = true;
    private float switchTimeLeft = 60f;
    private int prevWeaponIndex = -1;
    private int nextWeaponIndex = -1;
    // private bool isGrounded = true;

    // Awake is called once before the Start method
    void Awake()
    {

        // Detect user input
        playerControls = new PlayerControls();
        playerControls.Movement.Jump.performed += _ => Jump();

        // Debug commands
        // gameManager = GameManager.Instance;
        if (GameManager.DebugMode)
        {
            debugLog = FindObjectOfType<DebugLogScript>();
            playerControls.Debug.ToggleSwitchTimer.performed += _ => DebugToggleTimer();
            playerControls.Debug.HealthDecrease.performed += _ => DebugTakeDamage(10);
            playerControls.Debug.HealthIncrease.performed += _ => DebugAddHealth(10);
            playerControls.Debug.SummonHandGun.performed += _ => DebugSummon(0);
            playerControls.Debug.SummonLaserGun.performed += _ => DebugSummon(1);
            playerControls.Debug.SummonSword.performed += _ => DebugSummon(2);
            playerControls.Debug.SummonShield.performed += _ => DebugSummon(3);
            playerControls.Debug.SummonBanana.performed += _ => DebugSummon(4);
            playerControls.Debug.SummonBoomerang.performed += _ => DebugSummon(5);
        }
    }

    // OnEnable is called when script is first enabled
    void OnEnable()
    {
        playerControls.Enable();
    }

    // OnDisable is called when script is disabled
    void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find references to required components
        if (cameraTransform == null) {
            // cameraTransform = GameObject.FindWithTag("PlayerCamera").transform;
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }
        if (timeDisplay == null) {
            timeDisplay = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<TimeDisplayScript>();
        }
        if (weaponDisplay == null) {
            weaponDisplay = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<WeaponDisplayScript>();
        }
        characterController = GetComponent<CharacterController>();

        // Set health bar UI element for health script
        healthScript = GetComponent<HealthScript>();
        HealthBarScript healthBar = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<HealthBarScript>();
        healthScript.SetHealthBar(healthBar);
        healthScript.ResetHealth();

        // Setup switch timer and weapon player will be spawned with
        switchTimeLeft = timeToSwitch;
        timeDisplay.DisplayTime(timeToSwitch);
        SwitchWeapon();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // // Prevent additional player movement when player is in mid-air
        // isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, detectMasks);
        // if (!isGrounded) return;

        // Handle player movement
        Vector2 moveInput = playerControls.Movement.Move.ReadValue<Vector2>();
        if (moveInput.y != 0)
        {
            // Only rotate player if there was input in the forward-backward direction
            float turnAngle = cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, turnAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        }
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(moveVector.normalized * moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        // Toggle input controls depending on game state
        if (GameManager.GamePaused)
        {
            playerControls.Disable();
        }
        else 
        {
            playerControls.Enable();
        }

        // Switch weapons after some time interval
        if (switchTimerOn)
        {
            switchTimeLeft -= Time.deltaTime;
            timeDisplay.DisplayTime(switchTimeLeft);

            if (switchTimeLeft <= 0)
            {
                timeDisplay.DisplayTime(0);
                switchTimeLeft = timeToSwitch; // reset timer
                SwitchWeapon();
            }
        }
    }

    void Jump()
    {
        // TODO: implement jump action
        Debug.Log("jump");
    }

    void SwitchWeapon()
    {
        // Randomly select a weapon to summon next, cannot use same weapon twice in a row
        nextWeaponIndex = Random.Range(0, weaponsList.Length);
        while (weaponsList[nextWeaponIndex] == null && nextWeaponIndex != prevWeaponIndex)
        {
            nextWeaponIndex = Random.Range(0, weaponsList.Length);
        }
        DebugSummon(nextWeaponIndex);
        prevWeaponIndex = nextWeaponIndex; // save reference to selected weapon
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugToggleTimer()
    {
        switchTimerOn = !switchTimerOn;
        if (switchTimerOn)
        {
            debugLog.AddLog("Random weapon switching: ON");
        }
        else
        {
            debugLog.AddLog("Random weapon switching: OFF");
        }
    }

    void DebugTakeDamage(int damage)
    {
        healthScript.LoseHealth(damage);
    }

    void DebugAddHealth(int health)
    {
        healthScript.AddHealth(health);
    }

    void DebugSummon(int weaponIndex)
    {
        for (int i = 0; i < weaponsList.Length; i++)
        {
            if (i == weaponIndex)
            {
                GameObject weapon = weaponsList[weaponIndex];
                weapon.SetActive(true);
                weaponDisplay.DisplayWeapon(weapon.transform.name);
            }
            else if (weaponsList[i] != null) // ignore destroyed or one-time-use weapons
            {
                weaponsList[i].SetActive(false);
            }
        }
    }

    void DebugLogWeapon(int weaponIndex)
    {
        string debugText = "Current weapon: ";
        switch (weaponIndex)
        {
            case 0:
                debugLog.AddLog(debugText + "HAND GUN");
                break;
            case 1:
                debugLog.AddLog(debugText + "LASER GUN");
                break;
            case 2:
                debugLog.AddLog(debugText + "SWORD");
                break;
            case 3:
                debugLog.AddLog(debugText + "SHIELD");
                break;
            case 4:
                debugLog.AddLog(debugText + "BANANA");
                break;
            case 5:
                debugLog.AddLog(debugText + "BOOMERANG");
                break;
        }
    }
}
