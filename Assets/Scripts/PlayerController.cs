using UnityEngine;

// Script will not run if game object does not have a character controller component
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // SerializeField makes private variables visible in the Inspector without making the variable public to other scripts
    [SerializeField] private float moveSpeed = 10f;

    private CharacterController characterController = null;
    private InputManager inputManager = null;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Read movement value from input controls
        Vector2 moveInput = inputManager.GetPlayerMovement();

        // Move the player
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move(moveVector.normalized * moveSpeed * Time.deltaTime);
    }
}
