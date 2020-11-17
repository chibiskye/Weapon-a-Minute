using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [SerializeField] private float range = 25.0f;

    private WeaponControls weaponControls = null;
    private Rigidbody rigidBody = null;
    private Vector3 throwLocation;
    private Vector3 returnLocation;
    private Quaternion origionalRotation;
    private bool go;
    private bool isThrown;

    void Awake()
    {
        weaponControls = new WeaponControls();
        weaponControls.BoomerangInputs.Throw.performed += _ => Throw();
    }

    void OnEnable()
    {
        weaponControls.Enable();
    }

    void OnDisable()
    {
        weaponControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        go = false;
        isThrown = false;
        returnLocation = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isThrown)
        {
            gameObject.transform.Rotate(0, Time.deltaTime * 500, 0);

            if (go)
            {
                transform.position = Vector3.MoveTowards(transform.position, throwLocation, Time.deltaTime * 40);
            }
            if (!go)
            {
                transform.position = Vector3.MoveTowards(transform.position, returnLocation, Time.deltaTime * 40);
            }
            if (!go && Vector3.Distance(returnLocation, transform.position) < 1.5f)
            {
                Debug.Log("Gone back");
                isThrown = false;
                transform.rotation = origionalRotation;
                transform.position = returnLocation;
                rigidBody.velocity = new Vector3(0, 0, 0);

                //TODO the player should be holding the boomerang again
            }
        }
    }

    void Throw()
    {
        if(isThrown) { return; }
        Debug.Log("Throwing");
        returnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        throwLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z) + gameObject.transform.forward * range;
        origionalRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        isThrown = true;
        StartCoroutine(Boom());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isThrown)
        {
            Debug.Log("Hit");
            go = false;
            transform.rotation = origionalRotation;
        }
    }
}
