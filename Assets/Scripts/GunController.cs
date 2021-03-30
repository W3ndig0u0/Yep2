using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
  public float fireRate = 20f;
  Animator mAnimation;
  // Start is called before the first frame update
  void Start()
  {
    mAnimation = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButton("Fire1") && Time.time >= fireRate)
    {
      mAnimation.SetTrigger("Shoot");
    }
    else
    {
      mAnimation.SetTrigger("NotShoot");
    }
  }

}
