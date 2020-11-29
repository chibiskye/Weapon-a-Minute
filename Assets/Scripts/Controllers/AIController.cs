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
    [SerializeField] public WeaponScript weapon = null;
    private NavMeshAgent agent = null;
    private AIControls aiControls = null;

    //Patroling
    [SerializeField] private float walkPointRange = 10.0f;
    [SerializeField] private float walkPointCheckRange = 2.0f;
    [SerializeField] private float walkTime = 10.0f;
    [SerializeField] private float height = 7.21f; //For Flying
    [SerializeField] private float flyingSpeed = 9f;
    [SerializeField] private GameObject walker = null;
    [SerializeField] private ApproachScript flyingBody = null;
    public Vector3 walkPoint; // public for debug purposes
    private bool walkPointSet = false;
    private float timeLeftToWalk = 0f;

    //Attacking
    [SerializeField] private float timeBetweenAttacks = 1.0f;
    private bool alreadyAttacked = false;

    //States
    [SerializeField] private float sightRange = 20f;
    [SerializeField] private float attackRange = 8f;

    public bool playerInSightRange = false; // public for debug purposes
    public bool playerInAttackRange = false; // public for debug purposes
    private bool pauseMainAI = false;

    //States for flying
    public bool isFlying = false;
    public bool flyingToSomething = false;
    private bool movingBack = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timeLeftToWalk = walkTime;

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
        playerInSightRange = Physics.CheckSphere(walker.transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(walker.transform.position, attackRange, whatIsPlayer);

        if(isFlying) {
            
            if (flyingToSomething) {
                
                bool flyingBodyInSightRange = Physics.CheckSphere(flyingBody.transform.position, sightRange, whatIsPlayer);
                bool flyingBodyInAttackRange = Physics.CheckSphere(flyingBody.transform.position, attackRange, whatIsPlayer);
                // Debug.Log("Moving to player");
                flyingBody.Approach(player.position, flyingSpeed);
                if (flyingBodyInAttackRange) {
                   // Debug.Log("Attacking");
                    AttackPlayer();
                } 
                else if (!(flyingBodyInSightRange || flyingBodyInAttackRange)) {
                    //Debug.Log("Unpausing");
                    flyingToSomething = false;
                    movingBack = true;
                }
                return;
            } 
            else if (movingBack) {
               // Debug.Log("GoingUp");
                Vector3 goingTo = new Vector3(flyingBody.transform.position.x, height, flyingBody.transform.position.z);
                flyingBody.Approach(goingTo, flyingSpeed);
                if (Vector3.Distance(flyingBody.transform.position, goingTo) < 1f) {
                    movingBack = false;

                    //Put the walker under the flying body
                    transform.position = new Vector3(flyingBody.transform.position.x, transform.position.y, flyingBody.transform.position.z);

                    SearchWalkPoint();
                }
                return;
            }
        }

        // Detect and update state
        if (!playerInSightRange && !playerInAttackRange) { Patroling(); }
        if (playerInSightRange && !playerInAttackRange && !flyingToSomething && !movingBack) { 
            if (isFlying) {
                //pauseMainAI = true;
                FlyTowards();
            }
            else {
                ChasePlayer();
            }
        }
        if (playerInAttackRange && playerInSightRange && !isFlying) { 
            AttackPlayer();
        }
    }

    // Patrol when player is not in sight
    private void Patroling()
    {
        // Set next random walk point
        if (!walkPointSet || timeLeftToWalk <= 0) SearchWalkPoint();
        timeLeftToWalk -= Time.deltaTime; // calcualte another walk point if take too long to get to point

        // Move AI towards walk point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
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

    public void FlyTowards() {
        flyingToSomething = true;
    }

    // Chase the player when player enters sight range
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    // Attack the player if player spotted and in attack range
    private void AttackPlayer()
    {
        if (!isFlying) {
            //Make sure enemy doesn't move
            agent.SetDestination(transform.position);
        }

        Transform attacker = null;
        if(isFlying) {
            attacker = flyingBody.transform;
        } else {
            attacker = transform;
        }

        // Make AI face the player when attacking
        attacker.LookAt(player);

        // Check if AI has already attacked the player
        if (!alreadyAttacked)
        {
            Debug.Log("Not already attacked");
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
