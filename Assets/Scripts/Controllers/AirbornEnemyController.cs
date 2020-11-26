using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirbornEnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private GameObject[] checkpointList = null;
    [SerializeField] private EnemySwordScript weapon = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private float attackRange = 8f;
    [SerializeField] private float timeBetweenAttacks = 1.0f;
    [SerializeField] private float speed = 40;
    private int currentCheckpointIndex = 0;
    private bool alreadyAttacked = false;
    private string state = "PATROL";
    void Start()
    {
        player = GameObject.Find("DummyPlayerCamera");
    }
    void FixedUpdate()
    {
        if(state == "PATROL" && Physics.CheckSphere(transform.position, attackRange, whatIsPlayer)) {
            Debug.Log("Player near");
            state = "ATTACK";
        }
        if(state == "PATROL") {
            transform.position = Vector3.MoveTowards(transform.position, checkpointList[currentCheckpointIndex].transform.position, Time.deltaTime * speed);
            if(Vector3.Distance(checkpointList[currentCheckpointIndex].transform.position, transform.position) < 0.1f) {
                currentCheckpointIndex++;
                if(currentCheckpointIndex >= checkpointList.Length) {
                    currentCheckpointIndex = 0;
                }
            }
        } else {
            Debug.Log("Moving to player");
            Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
        
    }

    private void AttackPlayer()
    {
        // Make AI face the player when attacking
        transform.LookAt(player.transform);

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
}
