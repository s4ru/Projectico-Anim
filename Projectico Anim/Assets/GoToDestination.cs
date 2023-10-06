using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToDestination : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        // Move the character
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Set the animator parameters for movement
        animator.SetFloat("speed", moveDirection.magnitude);

        // Check for jump input and jump if grounded
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
    }
}
