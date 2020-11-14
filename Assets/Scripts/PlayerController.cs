using UnityEngine;

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private LayerMask detectMasks;
    [SerializeField] private HealthBar healthBar = null;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Transform groundTransform = null;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float moveSpeed = 10f;

    private CharacterController characterController = null;
    private InputManager inputManager = null;
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
        bool debugInput = inputManager.GetHealthDecrease();
        if (debugInput) TakeDamage(10);
        debugInput = inputManager.GetHealthIncrease();
        if (debugInput) AddHealth(10);

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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
    }

    void AddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}
