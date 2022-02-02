using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody myRigidbody;

    public float xInput;
    //public float zInput;
    private Vector3 movementVector;
    private bool isMoving;

    public int playerJumpForce = 50;
    public int fallMultiplier = 15;
    public float lowJumpMultiplier = 15;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool jumpQueued;
    public bool isFalling;

    public Transform model;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        jumpQueued = false;
        isMoving = false;
        isFalling = false;
    }


    void Update()
    {
        //InputDetection();
        xInput = Input.GetAxis("Horizontal");
        movementVector = new Vector3(xInput * speed, myRigidbody.velocity.y, 0);

        //tentative
        /*Vector3 movement = transform.forward * movementVector.x;
        movement.y = myRigidbody.velocity.y;
        myRigidbody.velocity = movement;*/

        if (xInput != 0)
        {
            isMoving = true;
        }

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
        {
            jumpQueued = true;
        }

        //Rotate the avatar on the same direction the player is moving to
         if (Input.GetAxis("Horizontal") != 0)
         {
             Quaternion turnModel = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
             model.rotation = turnModel;

         }

        //fall multiplier
        if (myRigidbody.velocity.y < 0)
        {
            isFalling = true;
        }
        else if (myRigidbody.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")))
        {
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            myRigidbody.velocity = movementVector;
            isMoving = false;
        }

        if (jumpQueued)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
            if (isGrounded)
            {
                myRigidbody.velocity += Vector3.up * playerJumpForce;
                //myRigidbody.AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);
                jumpQueued = false;
                isFalling = false;
            }
        }

        if (isFalling)
        {
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}
