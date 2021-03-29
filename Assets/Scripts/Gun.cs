using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

  public float damage = 20f;
  public float range = 100f;
  public float impactForce = 100f;
  public float fireRate = 20f;

  public Camera aimCam;

  public ParticleSystem flash;

  public GameObject effect;

  float fireTime = 0f;
  void Update()
  {
    // !Kontroll
    if (Input.GetButton("Fire1") && Time.time >= fireTime)
    {
      fireTime = Time.time + 1f / fireRate;
      Shoot();
    }
  }
  void Shoot()
  {
    // !Skottet
    RaycastHit hit;
    if (Physics.Raycast(aimCam.transform.position, aimCam.transform.forward, out hit, range))
    {

      // ?Fansy mansy Flashy helpy 
      flash.Play();

      EnemyAI target = hit.transform.GetComponent<EnemyAI>();

      // !Skadar Target
      if (target != null)
      {
        target.TakeDamage(damage);
      }

      // !Force
      if (hit.rigidbody != null)
      {
        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }

      // !Effekt
      GameObject effektGO = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
      Destroy(effektGO, 1f);

    }
  }

}