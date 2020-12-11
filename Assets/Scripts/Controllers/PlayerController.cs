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
    public static int PlayerScore = 0;

    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private LayerMask detectMasks;
    [SerializeField] private DebugLogScript debugLog = null;
    [SerializeField] private TimeDisplayScript timeDisplay = null;
    [SerializeField] private WeaponDisplayScript weaponDisplay = null;
    [SerializeField] private InfoDisplayScript infoDisplay = null;
    [SerializeField] private AnnouncementScript announcement = null;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float timeToSwitch = 60f;
    [SerializeField] private GameObject[] weaponsList = null;

    private CharacterController characterController = null;
    private PlayerControls playerControls = null;
    private Transform cameraTransform = null;
    private HealthScript healthScript = null;
    private float turnSmoothVelocity; // used as reference variable
    
    private Coroutine announcementCoroutine = null;
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
        if (GameManager.DebugMode)
        {
            debugLog = FindObjectOfType<DebugLogScript>();
            playerControls.Debug.ToggleSwitchTimer.performed += _ => DebugToggleTimer();
            playerControls.Debug.HealthDecrease.performed += _ => DebugTakeDamage(10);
            playerControls.Debug.HealthIncrease.performed += _ => DebugAddHealth(10);
            playerControls.Debug.SummonHandGun.performed += _ => ActivateWeapon(0);
            playerControls.Debug.SummonLaserGun.performed += _ => ActivateWeapon(1);
            playerControls.Debug.SummonSword.performed += _ => ActivateWeapon(2);
            playerControls.Debug.SummonBanana.performed += _ => ActivateWeapon(3);
            playerControls.Debug.SummonBoomerang.performed += _ => ActivateWeapon(4);
            // playerControls.Debug.SummonShield.performed += _ => ActivateWeapon(5);
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
        characterController = GetComponent<CharacterController>();
        if (cameraTransform == null) {
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }

        // Set health bar UI element for health script
        healthScript = GetComponent<HealthScript>();
        HealthBarScript healthBar = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<HealthBarScript>();
        healthScript.SetHealthBar(healthBar);
        healthScript.ResetHealth();

        // Set default text for player info
        PlayerScore = 0;
        if (infoDisplay == null) {
            infoDisplay = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<InfoDisplayScript>();
            infoDisplay.ResetWave();
            infoDisplay.ResetScore();
        }
        if (announcement == null) {
            announcement = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<AnnouncementScript>();
        }

        // Setup switch timer and weapon player will be spawned with
        switchTimeLeft = timeToSwitch;
        if (timeDisplay == null) {
            timeDisplay = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<TimeDisplayScript>();
            timeDisplay.SetMaxTime(timeToSwitch);
            timeDisplay.ResetTime();
        }
        if (weaponDisplay == null) {
            weaponDisplay = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<WeaponDisplayScript>();
        }
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

            if (switchTimeLeft <= 0f)
            {
                timeDisplay.DisplayTime(0);
                switchTimeLeft = timeToSwitch; // reset timer
                SwitchWeapon();
            }
            else if (switchTimeLeft <= 4f)
            {
                // StartCoroutine(announcement.InitiateCountdown());
                announcementCoroutine = StartCoroutine(announcement.Announce("WeaponChange"));
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
        ActivateWeapon(nextWeaponIndex);
        prevWeaponIndex = nextWeaponIndex; // save reference to selected weapon
    }

    void ActivateWeapon(int weaponIndex)
    {
        for (int i = 0; i < weaponsList.Length; i++)
        {
            if (i == weaponIndex)
            {
                GameObject weapon = weaponsList[weaponIndex];
                weapon.SetActive(true);

                string weaponName = weapon.transform.name;
                weaponDisplay.DisplayWeapon(weaponName);

                if (announcementCoroutine != null) StopCoroutine(announcementCoroutine);
                StartCoroutine(announcement.Announce(weaponName));
            }
            else if (weaponsList[i] != null) // ignore destroyed or one-time-use weapons
            {
                weaponsList[i].SetActive(false);
            }
        }
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

    // void DebugLogWeapon(int weaponIndex)
    // {
    //     string debugText = "Current weapon: ";
    //     switch (weaponIndex)
    //     {
    //         case 0:
    //             debugLog.AddLog(debugText + "HAND GUN");
    //             break;
    //         case 1:
    //             debugLog.AddLog(debugText + "LASER GUN");
    //             break;
    //         case 2:
    //             debugLog.AddLog(debugText + "SWORD");
    //             break;
    //         case 3:
    //             debugLog.AddLog(debugText + "SHIELD");
    //             break;
    //         case 4:
    //             debugLog.AddLog(debugText + "BANANA");
    //             break;
    //         case 5:
    //             debugLog.AddLog(debugText + "BOOMERANG");
    //             break;
    //     }
    // }
}
