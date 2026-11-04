using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    //============================================
    [Header("Velocidades")]
    private float moveSpeed = 2f;
    private float rotationSpeed = 10f;


    [Header("Referencias")]
    [SerializeField] private Transform playerTransform;


    [Header("Rango de detección")]
    private Vector3 walkPoint;
    bool walkPointSet;
    private float walkPointRange = 10f;


    [Header("Rango de ataque")]
    private float sightRange = 20f;
    private bool playerInSightRange;


    public LayerMask whatIsGround, whatIsPlayer;

    
    private NavMeshAgent agent;
    //============================================

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        if (playerInSightRange) ChasePlayer();
    } 

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.position, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(playerTransform.position);
    }
}
