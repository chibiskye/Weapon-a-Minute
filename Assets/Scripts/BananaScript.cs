using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] private float range = 3.0f;

    private string state;
    private InputManager inputManager = null;
    private int layerMask = ~(1 << 8); //attacking doesn't affect the player

    // Start is called before the first frame update
    void Start()
    {
        state = "Held";
        inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DebugRaycast();

        if (state == "Held")
        {
            bool playerSwing = inputManager.GetPlayerAttacked();
            if (playerSwing) Swing();
            bool playerThrow = inputManager.GetPlayerSecondOption();
            if (playerThrow) Throw();
        }


    }

    void Throw()
    {
        if (state == "Held")
        {
            Debug.Log("throwing");
            setState("Thrown");
            rigidbody.AddForce(new Vector3(1, 1, 1) * 400f);
            rigidbody.useGravity = true;
        }
    }

    void DebugRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }

    void Swing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
         //   Debug.Log("Did Hit");
        }
        else
        {
          //  Debug.Log("Did not Hit");
        }
    }

    void setState(string newState)
    {
        state = newState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.name);

        if (state == "Thrown")
        {
            if (collision.gameObject.layer == 11)
            {
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log("Damage");
                //TODO Damange the player/enemy that it collided with
                Destroy(gameObject);
            }

        }

    }
}
