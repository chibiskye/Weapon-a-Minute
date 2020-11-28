using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBodyController : MonoBehaviour
{
    [SerializeField] private float speed = 9f;
    [SerializeField] private float height = 7.21f;
    [SerializeField] private float attackRange = 8f;
    [SerializeField] private float sightRange = 20f;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private EnemySwordScript weapon = null;
    [SerializeField] private GameObject walker = null;
    [SerializeField] private AIController aIController = null;
    [SerializeField] private float timeBetweenAttacks = 1.0f;
    private bool flyingToSomething = false;
    private Transform target;
    private bool alreadyAttacked = false;
    private bool movingBack = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flyingToSomething) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            if (Physics.CheckSphere(transform.position, attackRange, whatIsPlayer)) {
                AttackPlayer();
            } else if (Physics.CheckSphere(transform.position, sightRange, whatIsPlayer)) {
                Debug.Log("Unpausing");
                flyingToSomething = false;
                movingBack = true;
            }
        } else if (movingBack) {
            Debug.Log("GoingUp");
            Vector3 goingTo = new Vector3(transform.position.x, height, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, goingTo, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, goingTo) < 1f) {
                movingBack = false;

                //Put the walker under the flying body
                walker.transform.position = new Vector3(transform.position.x, walker.transform.position.y, transform.position.z);
                aIController.unpauseMainAI();
            }
        }
    }

    // Attack the player if player spotted and in attack range
    private void AttackPlayer()
    {
        Debug.Log("Attacking");
        // Make AI face the player when attacking
        transform.LookAt(target);

        // Check if AI has already attacked the player
        if (!alreadyAttacked)
        {
            weapon.Attack();
            StartCoroutine(ResetAttack());
        }
    }

    // Prevent the AI from attacking too often
    IEnumerator ResetAttack()
    {
        alreadyAttacked = true;
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;
    }

    public void FlyTowards(Transform newTarget) {
        target = newTarget;
        flyingToSomething = true;
    }
}
