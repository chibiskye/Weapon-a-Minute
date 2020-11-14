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
    [SerializeField] private Transform r_HandWeaponHold = null;
    [SerializeField] private GameObject[] usableWeapons = null;

    private CharacterController characterController = null;
    private InputManager inputManager = null;
    // private GameObject l_handWeapon = null;
    private GameObject r_HandWeapon = null;
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
        debugInput = inputManager.GetDebugSummonGun();
        if (debugInput) DebugSummonGun();

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
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
    }

    void DebugAddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    void DebugSummonGun()
    {
        // Check if player is already holding a weapon
        if (r_HandWeapon) Destroy(r_HandWeapon);

        // Instantiate weapon on player's right hand
        GameObject gun = usableWeapons[0];
        Vector3 gunPosition = gun.transform.position;
        Quaternion gunRotation = gun.transform.rotation;

        float positionY = r_HandWeaponHold.position.y + gunPosition.y;
        float rotationX = r_HandWeaponHold.rotation.x + gunRotation.x;

        // TODO: instantiates with wrong rotation
        Vector3 instantiatePosition = new Vector3(r_HandWeaponHold.position.x, positionY, r_HandWeaponHold.position.z);
        Quaternion instantiateRotation = Quaternion.Euler(rotationX, r_HandWeaponHold.rotation.y, r_HandWeaponHold.rotation.z);

        r_HandWeapon = Instantiate(gun, instantiatePosition, instantiateRotation, r_HandWeaponHold);
        r_HandWeapon.SetActive(true);
    }
}
