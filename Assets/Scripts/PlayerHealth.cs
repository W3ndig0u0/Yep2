using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
  public HealthBar healthbar;
  public static float health;
  public float maxHealth = 100;
  public GameObject hitEffect;
  bool gameHasEnded = false;

  public GameObject endMenuUI;

  void Start()
  {
    // !Sätter max liv o Health bar
    health = maxHealth;
    healthbar.SetMaxHealth(maxHealth);
    FindObjectOfType<AudioManager>().Play("Bgm");
  }
  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.CompareTag("Enemy"))
    {
      TakeDamage(20);
      GameObject hitEffectGO = Instantiate(hitEffect, transform.position, Quaternion.identity);
      FindObjectOfType<AudioManager>().Play("PlayerHit");
    }
  }
  public void TakeDamage(float damageAmount)
  {
    // !Skada
    health -= damageAmount;

    // !Minskar healthbar
    healthbar.SetHealth(health);

    if (health <= 0f)
    {
      GameOver();
    }
  }
  void GameOver()
  {
    if (gameHasEnded == false)
    {
      gameHasEnded = true;
      print("ded");
      EndSceen();
    }
  }
  public void EndSceen()
  {
    endMenuUI.SetActive(true);
    Time.timeScale = 0f;
    gameHasEnded = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    FindObjectOfType<AudioManager>().Stop("Bgm");
    FindObjectOfType<AudioManager>().Play("PauseLoop");
  }
}
