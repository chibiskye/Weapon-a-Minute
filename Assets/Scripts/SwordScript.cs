using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    [SerializeField] private float range = 8.0f;
    // [SerializeField] private int hitDamage = 10; // not used yet

    private InputManager inputManager = null;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void DebugRaycast()
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, range, layerMask))
        {
            Debug.DrawRay(rayOrigin, camera.transform.forward * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(rayOrigin, camera.transform.forward * 1000, Color.white);
        }
    }

    void FixedUpdate()
    {
        DebugRaycast();

        // Check if player clicked button for attack
        bool playerSwing = inputManager.GetPlayerAttacked();
        if (playerSwing) Swing();
    }

    void Swing()
    {
        Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);
        }
        else
        {
            Debug.Log("missed");
        }
    }
}
