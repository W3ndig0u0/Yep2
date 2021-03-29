using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

  public float health, getScoreFromKill, score;

  public void TakeDamage(float damageAmount)
  {
    // !Skada
    health -= damageAmount;
    if (health <= 0f)
    {
      Die();
    }
  }
  void Die()
  {
    // !Dör
    Destroy(gameObject);
    score += getScoreFromKill;

  }

}
