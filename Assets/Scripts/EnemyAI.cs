using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
  public NavMeshAgent agent;
  public Transform player;
  public LayerMask whatIsGround, whatIsPlayer;
  public float attackRange, timeBetweenAttack, damage;
  public bool playerInAttackRange;
  bool alreadyAttacked;

  void Awake()
  {
    player = GameObject.Find("PlayerContainer").transform;
    agent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
    //   !Kolla efter syn och attackRange
    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

    // !AI Status
    if (playerInAttackRange)
    {
      AttackPlayer();
    }
    else
    {
      ChasePlayer();
    }
  }

  RaycastHit hit;
  void AttackPlayer()
  {
    Target target = hit.transform.GetComponent<Target>();

    if (!alreadyAttacked)
    {
      if (Input.GetKey(KeyCode.G))
      {
        target.TakeDamage(damage);
      }

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

