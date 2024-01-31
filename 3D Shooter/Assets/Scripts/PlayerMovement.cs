using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 1.5f;

    public float gravity;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    //Declare and initialise variables for use

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
		{
            velocity.y = -2f;
		}
        //If the player is grounded then takes away velocity to reduce build up

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        //Allows the player to move using inputs

        if(Input.GetButton("Jump") && isGrounded)
		{
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        } //if the user is on the ground and presses jump then they jump

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        //applies gravity to the player

    }
}
