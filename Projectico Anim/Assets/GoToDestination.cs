using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDestination : MonoBehaviour
{
    private Animator animator;
    public float rotationSpeed = 20f; // Adjust this to control the rotation speed.
    public float movementSpeed = 3f;  // Adjust this to control the movement speed.
    public float jumpForce = 5f;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool jumpPressed = Input.GetKey("space");

        // Handle rotation when turning left (A key) or right (D key).
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Handle forward and backward movement.
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (forwardPressed)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (backwardPressed)
        {
            animator.SetBool("IsBackward", true);
        }
        else
        {
            animator.SetBool("IsBackward", false);
        }

        if (jumpPressed)
        {
            animator.SetBool("Jump", true);
            Jump();
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }

    private void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
