using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10;

    public Vector3 velocity;
    public float gravity = -4;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public bool isGrounded;

    private void Update()
    {
        if (!controller.enabled)
        {
            velocity = Vector3.zero;
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
