using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Current AI Specific Code was implemented by following a tutorial by 'Dave / GameDevelopment' on YouTube
public class AIController : MonoBehaviour
{
    //Components
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] private Transform player = null;
    [SerializeField] private EnemySwordScript weapon = null;
    private NavMeshAgent agent = null;
    private AIControls aiControls = null;

    //Patroling
    [SerializeField] private float walkPointRange = 10.0f;
    [SerializeField] private float walkPointCheckRange = 2.0f;
    public Vector3 walkPoint; // public for debug purposes
    private bool walkPointSet = false;

    //Attacking
    [SerializeField] private float timeBetweenAttacks = 1.0f;
    private bool alreadyAttacked = false;

    //States
    [SerializeField] private float sightRange = 20f;
    [SerializeField] private float attackRange = 8f;
    public bool playerInSightRange = false; // public for debug purposes
    public bool playerInAttackRange = false; // public for debug purposes

    private void Awake()
    {
        player = GameObject.Find("DummyPlayerArmed").transform;
        agent = GetComponent<NavMeshAgent>();

        // Detect debug commands
        aiControls = new AIControls();
        aiControls.Debug.ToggleMovement.performed += _ => DebugToggleMove();
    }

    void OnEnable()
    {
        aiControls.Enable();
    }

    void OnDisable()
    {
        aiControls.Disable();
    }

    private void FixedUpdate()
    {
        if (agent.isStopped) return;

        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // Detect and update state
        if (!playerInSightRange && !playerInAttackRange) { Patroling(); }
        if (playerInSightRange && !playerInAttackRange) { ChasePlayer(); }
        if (playerInAttackRange && playerInSightRange) { AttackPlayer(); }
    }

    // Patrol when player is not in sight
    private void Patroling()
    {
        // Set next random walk point
        if (!walkPointSet) SearchWalkPoint();

        // Move AI towards walk point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        // Vector3 distanceToWalkPoint = transform.position - walkPoint;
        // if (distanceToWalkPoint.magnitude < 1.0f)
        // {
        //     walkPointSet = false; // calculate next walk point
        // }

        //Thought that this method would be more intuitive to understand
        // Check if AI reached walk point
        if (Vector3.Distance(transform.position, walkPoint) <= agent.stoppingDistance)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        // Set walk point to random point
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Check if walk point is valid point on map
        if (Physics.Raycast(walkPoint, -transform.up, walkPointCheckRange, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    // Chase the player when player enters sight range
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    // Attack the player if player spotted and in attack range
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // Make AI face the player when attacking
        transform.LookAt(player);

        // Check if AI has already attacked the player
        if (!alreadyAttacked)
        {
            weapon.Attack();

            //According to Unity Docs, Coroutines work better than Invoke, so using Coroutine instead
            // alreadyAttacked = true;
            // Invoke(nameof(ResetAttack), timeBetweenAttacks);
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

    // ---------------------------------------------------------------------------------------------
    // Below are methods used for debugging
    // ---------------------------------------------------------------------------------------------

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void DebugToggleMove()
    {
        agent.isStopped = !agent.isStopped;
        if (agent.isStopped)
        {
            Debug.Log("opponent paused");
        }
        else
        {
            Debug.Log("opponent unpaused");
        }
    }

}
