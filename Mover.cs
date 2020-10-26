using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float jumpHeight = 7f;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 2;
    private Rigidbody rb;
    public float moveSpeed = 1f;
    public float topSpeed = 5f;
    public bool stopRoll = false;
    bool canJump = false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        if (!stopRoll)
        {
            Roll();
        }
    }

    private void Roll()
    {
        float speed = Vector3.Magnitude(rb.velocity);  // test current object speed

        if (speed > topSpeed)

        {
            float brakeSpeed = speed - topSpeed;  // calculate the speed decrease

            Vector3 normalisedVelocity = rb.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value

            rb.AddForce(-brakeVelocity);  // apply opposing brake force
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement);

    }

    private void Jump()
    {
        if (NumberJumps == 0f)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stopRoll = true;
                rb.AddForce(Vector3.up * jumpHeight);
                NumberJumps -= 1;
            }
        }

    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "floor")
        {
            isGrounded = true;
            NumberJumps = 2f;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
}
