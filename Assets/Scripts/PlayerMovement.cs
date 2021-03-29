using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public CharacterController controller;

  public Transform groundCheck;

  public float groundDistance = 0.4f;
  public LayerMask groundMask;


  public float jumpHeight = 3f;


  public float speed = 20;
  public float g = -9.81f;

  Vector3 velocity;
  bool isGrounded;

  void Update()
  {

    //  !Reseting velocity

    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    if (isGrounded && velocity.y < 0)
    {
      velocity.y = -2f;
    }

    // !Controller

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;

    controller.Move(move * speed * Time.deltaTime);

    // !Jump
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
      velocity.y = Mathf.Sqrt(jumpHeight * -2f * g * 4);
    }

    // !Running
    if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
    {
      controller.Move(move * (speed - 5) * Time.deltaTime);
    }

    // !Gravity

    velocity.y += g * Time.deltaTime;

    controller.Move(velocity * Time.deltaTime);
  }
}
