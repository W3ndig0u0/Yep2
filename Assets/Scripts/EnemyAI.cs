using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

  public NavMeshAgent agent;

  public Transform player;

  public LayerMask whatIsGround, whatIsPlayer;

  // !Patrolling
  public Vector3 walkPoint;
  bool walkpointSet;
  public float walkPointRange;

  // !States
  public float sightRange, attackRange;
  public bool playerInSightRange, playerInAttackRange;

  //  !Attacking
  public float timeBetweenAttack;
  bool alreadyAttacked;

  void Awake()
  {
    player = GameObject.Find("PlayerContainer").transform;
    agent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
    //   !Kolla efter syn och attackRange
    playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

    // !AI Status
    if (playerInSightRange && playerInAttackRange)
    {
      AttackPlayer();
    }

    else if (playerInSightRange && !playerInAttackRange)
    {
      ChasePlayer();
    }
    else
    {
      Patroling();
    }
  }

  void SearchWalkPoint()
  {
    //! Random värden
    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    float randomX = Random.Range(-walkPointRange, walkPointRange);

    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    // !kollar om det är i marken
    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    {
      walkpointSet = true;
    }
  }
  void Patroling()
  {
    if (!walkpointSet)
    {
      SearchWalkPoint();
    }

    if (walkpointSet)
    {
      agent.SetDestination(walkPoint);
    }

    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    // !När Målet är nått
    if (distanceToWalkPoint.magnitude < 1f)
    {
      walkpointSet = false;
    }
  }
  void AttackPlayer()
  {

    // !Enemy rör ej
    agent.SetDestination(transform.position);

    // !Stalka player
    transform.LookAt(player);

    if (!alreadyAttacked)
    {

      // !Attack Koden:

      //! 

      alreadyAttacked = true;
      Invoke(nameof(ResetAttacked), timeBetweenAttack);
    }

  }

  void ResetAttacked()
  {
    alreadyAttacked = false;
  }

  void ChasePlayer()
  {
    // !Jagar spelaren
    agent.SetDestination(player.position);
  }

}

