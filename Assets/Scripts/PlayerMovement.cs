using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public GameObject player;
    public float speed = 12f;
    public float runspeed = 20f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public bool isWalking;
    public bool isRunning;
    public Transform groundCheck;
    public Transform cellingCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
        }

        float CurrentEnergy = player.GetComponent<PlayerStatus>().CurrentEnergy;
        if (Input.GetKey(KeyCode.LeftShift) && isWalking && CurrentEnergy > 0 && isGrounded)
        {
            //hold shift to run
            controller.Move(move * runspeed * Time.deltaTime);
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isWalking = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || !isWalking )
        {
            isRunning = false;
        }


        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
