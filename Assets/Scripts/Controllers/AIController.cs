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
    [SerializeField] private DebugLogScript debugLog = null;
    [SerializeField] private WeaponScript weapon = null;
    [SerializeField] private bool isFlying = false;
    [SerializeField] private GameObject flyingBody = null; // for flying AI
    [SerializeField] private float flyingSpeed = 3f; // for flying AI
    private NavMeshAgent agent = null;
    private AIControls aiControls = null;

    //Patroling
    [SerializeField] private float walkPointRange = 10.0f;
    [SerializeField] private float walkPointCheckRange = 2.0f;
    [SerializeField] private float walkTime = 10.0f;
    public Vector3 walkPoint; // public for debug purposes
    private bool walkPointSet = false;
    private float flyingHeight = 8f; // for flying AI
    private float timeLeftToWalk = 0f;

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
        agent = GetComponent<NavMeshAgent>();
        timeLeftToWalk = walkTime;

        if (isFlying && flyingBody != null)
        {
            flyingHeight = flyingBody.transform.position.y;
        }

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
        if (!walkPointSet || timeLeftToWalk <= 0) SearchWalkPoint();
        timeLeftToWalk -= Time.deltaTime; // calculate another walk point if take too long to get to point

        // Move AI towards walk point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            if (isFlying && !playerInAttackRange)
            {
                Vector3 flyPoint = new Vector3(walkPoint.x, flyingHeight, walkPoint.z);
                FlyTowards(flyPoint);
            }
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1.0f)
        {
            walkPointSet = false; // calculate next walk point
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
            timeLeftToWalk = walkTime;
        }
    }

    private void FlyTowards(Vector3 destination)
    {
        flyingBody.transform.position = Vector3.MoveTowards(flyingBody.transform.position, destination, Time.deltaTime * flyingSpeed);
    }

    // Chase the player when player enters sight range
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if (isFlying)
        {
            FlyTowards(player.position);
        }
    }

    // Attack the player if player spotted and in attack range
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // Make AI face the player when attacking
        if (isFlying)
        {
            flyingBody.transform.LookAt(player);
        }
        else
        {
            transform.LookAt(player);
        }
        
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
        Vector3 gizmoCenter = transform.position;
        if (isFlying)
        {
            gizmoCenter = flyingBody.transform.position;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gizmoCenter, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gizmoCenter, sightRange);
    }

    void DebugToggleMove()
    {
        agent.isStopped = !agent.isStopped;

        // Check if debug log is available to write in
        if (debugLog == null) return;
        
        if (agent.isStopped)
        {
            debugLog.AddLog("AI navigation: PAUSED");
        }
        else
        {
            debugLog.AddLog("AI navigation: RESUMED");
        }
    }

}