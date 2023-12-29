using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 4f;
    public float sprintingSpeed = 9f;
    float actualSpeed = 0f;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask isGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;
    Rigidbody rb;

    public AnimatorManager animatorManager;

    private float moveAmount = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        actualSpeed = runningSpeed;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed = sprintingSpeed;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            actualSpeed = walkingSpeed;
            moveAmount = 0.4f;
        }
        else if (Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)) > 0)
        {
            actualSpeed = runningSpeed;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)) - 0.4f;
        }
        else
        {
            actualSpeed = 0;
            moveAmount = 0f;
        }

        // animating idle, walk and running
        //moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
        //Debug.Log("MOVE AMOUNT = " + moveAmount);
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDir.normalized * actualSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > actualSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * actualSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
