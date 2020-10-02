using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float detectionRing = 10f;

    public AvatarAnimationController animator;

    public Transform[] patrolPoints;

    public bool isCivilian;

    private int currentPatrolPointIndex = 0;

    Transform target;
    NavMeshAgent agent;
    
    private CharacterCombat combat;
    private CharacterStats targetStats;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        targetStats = target.GetComponent<CharacterStats>();
        
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        animator = GetComponent<AvatarAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // Cop behaviour - patrol & attack
        if (!agent.pathPending)
        {
            // If player is in range.
            if (distance <= detectionRing)
            {
                AgentChaseAndRun();

                if (distance <= agent.stoppingDistance + 0.5f)
                {
                    // Attack the player
                    if (targetStats != null)
                    {
                        //Debug.Log(distance);
                        animator.HumanShootGun1();
                        combat.Attack(GetComponent<CharacterStats>().damage, targetStats);
                    }

                    // Face the player
                    FaceTarget();
                }
            }
            else if (agent.remainingDistance < agent.stoppingDistance)
            {
                // Keep patrolling between points.
                AgentPatrol();
                animator.HumanWalk();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRing);
    }

    private void AgentPatrol()
    {
        if (patrolPoints.Length > 0)
        {
            agent.destination = patrolPoints[currentPatrolPointIndex].position;

            currentPatrolPointIndex++;
            currentPatrolPointIndex %= patrolPoints.Length;
        }
    }

    private void AgentChaseAndRun()
    {
        if (!isCivilian)
        {
            agent.SetDestination(target.position);
            animator.HumanRun();
        }
        else
        {
            GameObject FleePoint = GameObject.FindGameObjectWithTag("flee");
            agent.SetDestination(FleePoint.transform.position);
            animator.HumanRun();
        }
    }
}
