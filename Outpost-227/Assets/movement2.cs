using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    public float speed = 10f;

    public CharacterController controller;

    public float gravity = -9.18f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDist = 0.45f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;
    public float sprint = 20f;
    public bool sprinting = false;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey("left shift"))
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }


        if (sprinting == true) {
            speed = sprint;
        }
        if (sprinting == false) {
            speed = 10f;
        }
            

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }

}
