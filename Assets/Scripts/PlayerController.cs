using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private LayerMask detectMasks;
    [SerializeField] private DebugLogScript debugLog = null;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float timeToSwitch = 10f;
    // [SerializeField] private Transform l_HandWeaponHold = null;
    // [SerializeField] private Transform r_HandWeaponHold = null;
    [SerializeField] private GameObject[] weaponsList = null;

    // [SerializeField] private GameObject camera = null;
    // [SerializeField] private GameObject body = null;

    private CharacterController characterController = null;
    private PlayerControls playerControls = null;
    private int prevWeaponIndex = -1;
    private int nextWeaponIndex = -1;
    private float switchTimeLeft = 0f;
    private bool timerOn = true;
    // private GameObject l_handWeapon = null;
    // private GameObject r_HandWeapon = null;
    // private bool isGrounded = true;

    // Awake is called once before the Start method
    void Awake()
    {
        playerControls = new PlayerControls();

        // Detect user input
        playerControls.Movement.Jump.performed += _ => Jump();

        // Debug commands
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
        characterController = GetComponent<CharacterController>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Switch weapons after some time interval
        if (timerOn)
        {
            switchTimeLeft -= Time.deltaTime; // update timer
            if (switchTimeLeft <= 0)
            {
                // Randomly select a weapon to summon next, cannot use same weapon twice in a row
                nextWeaponIndex = Random.Range(0, weaponsList.Length);
                while (weaponsList[nextWeaponIndex] == null && nextWeaponIndex != prevWeaponIndex)
                {
                    nextWeaponIndex = Random.Range(0, weaponsList.Length);
                }
                DebugSummon(nextWeaponIndex);
                prevWeaponIndex = nextWeaponIndex; // save reference to selected weapon
                switchTimeLeft = timeToSwitch; // reset timer
            }
        }

        // // Prevent additional player movement when player is in mid-air
        // isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, detectMasks);
        // if (!isGrounded) return;

        // Read movement value from input controls
        Vector2 moveInput = playerControls.Movement.Move.ReadValue<Vector2>();

        // Move the player
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(moveVector.normalized * this.moveSpeed * Time.deltaTime);

        // //Rotate player
        // Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        // transform.rotation = Quaternion.LookRotation(movement);
    }

    void Jump()
    {
        // TODO: implement jump action
        Debug.Log("jump");
    }

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    void DebugToggleTimer()
    {
        timerOn = !timerOn;
        if (timerOn)
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
        Health healthScript = GetComponent<Health>();
        healthScript.LoseHealth(damage);
    }

    void DebugAddHealth(int health)
    {
        Health healthScript = GetComponent<Health>();
        healthScript.AddHealth(health);
    }

    void DebugSummon(int weaponIndex)
    {
        for (int i = 0; i < weaponsList.Length; i++)
        {
            if (i == weaponIndex)
            {
                DebugLogWeapon(weaponIndex);
                weaponsList[weaponIndex].SetActive(true);
            }
            else if (weaponsList[i] != null) // ignore destroyed or one-time-use weapons
            {
                weaponsList[i].SetActive(false);
            }
        }
    }

    // void DebugSummonGun()
    // {
    //     // Check if player is already holding a weapon
    //     if (r_HandWeapon) Destroy(r_HandWeapon);

    //     // Instantiate weapon on player's right hand
    //     GameObject gun = weaponsList[0];

    //     // Add slight offset in y-direction above player hand
    //     Vector3 gunPosition = new Vector3(r_HandWeaponHold.transform.position.x, r_HandWeaponHold.transform.position.y + 0.2f, r_HandWeaponHold.transform.position.z);

    //     // Rotate gun to make it horizontal
    //     Quaternion gunRotation = Quaternion.Euler(90f, 0f, 0f);

    //     r_HandWeapon = Instantiate(gun, gunPosition, gunRotation, r_HandWeaponHold);
    //     r_HandWeapon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //     r_HandWeapon.SetActive(true);
    // }

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
