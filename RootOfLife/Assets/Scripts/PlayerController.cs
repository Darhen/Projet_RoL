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
    public bool isFastJumping;

    public Transform model;

    public CapsuleCollider capCollider;

    public Animator animator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        jumpQueued = false;
        isMoving = false;
        isFalling = false;
        isFastJumping = false;
    }


    void Update()
    {
        //InputDetection;
        xInput = Input.GetAxis("Horizontal");
        movementVector = new Vector3(xInput * speed, myRigidbody.velocity.y, 0);

        //animation horizontal
        this.animator.SetFloat("horizontal", xInput);
        

        //tentative
        /*Vector3 movement = transform.forward * movementVector.x;
        movement.y = myRigidbody.velocity.y;
        myRigidbody.velocity = movement;*/

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        if (xInput != 0)
        {
            isMoving = true;
        }

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
        {
            jumpQueued = true;
        }
        //low Jump
        if (myRigidbody.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")))
        {
            isFastJumping = true;
        }

        //Rotate the avatar on the same direction the player is moving to
        if (Input.GetAxis("Horizontal") != 0)
        {
             Quaternion turnModel = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
             model.rotation = turnModel;

        }

        //fall multiplier (fake gravité)
        if (myRigidbody.velocity.y < 0)
        {
            isFalling = true;
        }
    }

    /*private void OnCollisionStay(Collision col)
    {
        foreach (ContactPoint p in col.contacts)
        {
            Vector3 bottom = capCollider.bounds.center - (Vector3.up * capCollider.bounds.extents.y);
            Vector3 curve = bottom + (Vector3.up * capCollider.radius);
            Vector3 dir = curve - p.point;
        }
    }*/

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
            isFalling = false; 
    }*/

    private void FixedUpdate()
    {
        if (isMoving)
        {
            myRigidbody.velocity = movementVector;
            isMoving = false;
        }

        if (isGrounded)
        {
            isFalling = false;
            //isFastJumping = false;
            //isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
            if (jumpQueued)
            {
                //myRigidbody.AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);

                myRigidbody.velocity += Vector3.up * playerJumpForce;
                jumpQueued = false;
                //isFalling = false;
                
            }
        }

        if (isFalling)
        {
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (isFastJumping)
        {
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            isFastJumping = false;
        }
    }
}
