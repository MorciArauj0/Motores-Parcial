using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    //============================================
    private enum State
    {
        Patrolling,
        Chasing,
    }
    private State currentState = State.Patrolling;

    private enum PatrolMode
    {
        WayPoints,
        RandomNavMesh,
    }

    [Header("Referencias")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform playerTransform;


    [Header("Patrolling")]
    private PatrolMode patrolMode = PatrolMode.WayPoints;
    bool randomWayPointintOrder = false;
    private float randomPatrolRadius = 10f;


    [Header("Rango de detección")]
    private float sightRange = 20f;
    private float sightRangeLose = 25f;
    private float reinicioRange = 2.6f;


    public LayerMask whatIsGround, whatIsPlayer;
    private Material patrolMaterial;
    private Renderer rend;
    private int patrolIndex = 0;
    private NavMeshAgent agent;
    //============================================

    private void Awake()
    {
        GameObject contenedor = GameObject.Find("PatrolPoints");

        if (contenedor != null)
        {
            patrolPoints = new Transform[contenedor.transform.childCount];
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                patrolPoints[i] = contenedor.transform.GetChild(i);
            }
        }

        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        bool playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        bool playersightRangeLose = Physics.CheckSphere(transform.position, sightRangeLose, whatIsPlayer);

        if (playerInSightRange && currentState != State.Chasing)
        {
            currentState = State.Chasing;
        }

        else if (!playersightRangeLose && currentState == State.Chasing)
        {
            currentState = State.Patrolling;
            agent.ResetPath();
        }

        if (currentState == State.Patrolling)
            Patrolling();
        else if (currentState == State.Chasing)
            ChasePlayer();
    }

    private void Patrolling()
    {
        rend.material = patrolMaterial;
        
        if (!agent.hasPath || agent.remainingDistance < 0.3f)
        {
            if (patrolMode == PatrolMode.WayPoints && patrolPoints.Length > 0)
            {
                if (randomWayPointintOrder)
                {
                    patrolIndex = Random.Range(0, patrolPoints.Length);
                }
                else
                {
                    patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
                }

                agent.SetDestination(patrolPoints[patrolIndex].position);
            }
            else if (patrolMode == PatrolMode.RandomNavMesh)
            {
                agent.SetDestination(RandomNavMeshPoint());
            }
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= reinicioRange)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ReiniciarLoop();
            }
        }
    }

    private Vector3 RandomNavMeshPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * randomPatrolRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, randomPatrolRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return transform.position;
    }
}
