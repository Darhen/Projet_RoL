using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi_2 : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    public bool isSearching;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    //public GameObject projPos;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        isSearching = false;
        Patroling();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

       if (!playerInSightRange && !playerInAttackRange) Patroling();
       if (playerInSightRange && !playerInAttackRange) ChasePlayer();
       if (playerInAttackRange && playerInSightRange) AttackPlayer();


        
    }

    private void Patroling()
    {
       if (walkPointSet == false)
            SearchWalkPoint();

        if (walkPointSet == true)
            agent.SetDestination(walkPoint);

        //Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        float dist = Vector3.Distance(walkPoint, transform.position);
        if (dist < 1f)
        {
            walkPointSet = false;
        }
       
    }

    private void SearchWalkPoint()
    {
        //Caalculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        Debug.Log(walkPoint);
       // if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        GetComponent<NavMeshAgent>().speed = 100f;
        GetComponent<NavMeshAgent>().acceleration = 100f;
        walkPointSet = false;
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        GetComponent<NavMeshAgent>().speed = 100f;
        GetComponent<NavMeshAgent>().acceleration = 100f;
        walkPointSet = false;
        transform.LookAt(player);

        /*
        if (Vector3.Distance(walkPoint, player.position) > 1.0f)
        {
            walkPoint = player.position;
            agent.destination = walkPoint;
        }
        */

        //if (!alreadyAttacked)
        {
            ///Attack code here
           // Rigidbody rb = Instantiate(projectile, projPos.transform.position, projPos.transform.rotation/*Quaternion.identity*/).GetComponent<Rigidbody>();
           // rb.AddForce(transform.forward * 1000f, ForceMode.Impulse);
           // rb.AddForce(transform.up * 1f, ForceMode.Impulse);

            ///

            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    //Vizualise attack range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
 
}
