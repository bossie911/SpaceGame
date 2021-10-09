using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    float speed = 12f;
    float gravity = 0.1f;
    float jumpHeight = 1f;
    float rotSpeed = 0.6f;
    float jetpackSpeed = 10f;

    public Vector3 velocity;

    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public bool isInSpace;

    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        //Gravity with a SphereCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded == false && isInSpace == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - gravity, transform.localPosition.z);
        }

        //Space Controll
        if (isInSpace == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0, 0, rotSpeed);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0, 0, -rotSpeed);
            }
            if (Input.GetButton("Jump"))
            {
                Vector3 jetUp = transform.up;
                controller.Move(jetUp * jetpackSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 jetUp = transform.up;
                controller.Move(-jetUp * jetpackSpeed * Time.deltaTime);
            }
        }


        /*
        //Space Movement up and down
        if (isInSpace)
        {
            //Input
            if (Input.GetButton("Jump"))
            {
                velocity.y = speed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity.y = -speed;
            }

                //Jump
        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded && !isInSpace)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

            //Drag
            if(velocity.y > 0)
            {
                velocity.y--;
            }
            else if (velocity.y < 0)
            {
                velocity.y++;
            }
        }

        //Velocity applying
        controller.Move(velocity * Time.deltaTime);

        //Gravity applying
        if (isInSpace == false)
        {
            //velocity.y += gravity * Time.deltaTime;           
        }

        //Gravity Reset
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0 && isInSpace == false)
        {
            velocity.y = -2f;
        }

    */

    }
}
