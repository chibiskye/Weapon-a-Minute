using UnityEngine;

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private float moveSpeed = 10f;

    private CharacterController characterController;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is airborn or on the ground
        isGrounded = characterController.isGrounded;

        // Read movement value from input controls
        Vector2 moveInput = inputManager.GetPlayerMovement();
        Vector3 moveVector = new Vector3(moveInput.x, 0f, moveInput.y);

        // Move the player
        characterController.Move(moveVector * moveSpeed * Time.deltaTime);

        // Rotates player to look in the direction that they are moving in
        if (moveVector != Vector3.zero)
        {
            transform.forward = moveVector;
        }
    }
}
