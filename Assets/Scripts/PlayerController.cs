using UnityEngine;

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private LayerMask detectMasks;
    [SerializeField] private HealthBar healthBar = null;
    [SerializeField] private Transform groundTransform = null;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float moveSpeed = 10f;
    // [SerializeField] private Transform l_HandWeaponHold = null;
    // [SerializeField] private Transform r_HandWeaponHold = null;
    [SerializeField] private GameObject[] weaponsList = null;

    private CharacterController characterController = null;
    private InputManager inputManager = null;
    // private GameObject l_handWeapon = null;
    // private GameObject r_HandWeapon = null;
    private int currentHealth = 100;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Prevent additional player movement when player is in mid-air
        isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, detectMasks);
        if (!isGrounded) return;

        // Read values from debug input controls
        bool debugInput = inputManager.GetDebugHealthDecrease();
        if (debugInput) DebugTakeDamage(10);
        debugInput = inputManager.GetDebugHealthIncrease();
        if (debugInput) DebugAddHealth(10);
        debugInput = inputManager.GetDebugSummonHandGun();
        if (debugInput) DebugSummon(0);
        debugInput = inputManager.GetDebugSummonLaserGun();
        if (debugInput) DebugSummon(1);
        debugInput = inputManager.GetDebugSummonSword();
        if (debugInput) DebugSummon(2);
        debugInput = inputManager.GetDebugSummonShield();
        if (debugInput) DebugSummon(3);

        // Read movement value from input controls
        Vector2 moveInput = inputManager.GetPlayerMovement();
        bool jumpInput = inputManager.GetPlayerJumped();
        if (jumpInput) Debug.Log("jumped");

        // Make the player jump


        // Move the player
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(moveVector.normalized * moveSpeed * Time.deltaTime);
    }

    // Below are methods used for debugging

    void DebugTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
    }

    void DebugAddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    void DebugSummon(int weaponIndex)
    {
        for (int i = 0; i < weaponsList.Length; i++)
        {
            if (i == weaponIndex)
            {
                Debug.Log("Using " + weaponsList[weaponIndex].transform.name);
                weaponsList[weaponIndex].SetActive(true);
            }
            else 
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
}
