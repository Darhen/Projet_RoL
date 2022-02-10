using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody myRigidbody;

    public float xInput;
    private Vector3 movementVector;

    public int playerJumpForce = 50;
    public int fallMultiplier = 15;
    public float lowJumpMultiplier = 15f;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool isMoving;
    public bool jumpQueued;
    public bool isFalling;
    public bool isFastJumping;

    public Transform model;
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
        //On stock dans un float l'input x qu'on insert dans un vector3 multiplié par speed et en ignorant la vélocité y du rigidbody ("évite les conflits de physique")
        xInput = Input.GetAxis("Horizontal");
        movementVector = new Vector3(xInput * speed, myRigidbody.velocity.y, 0);

        //Animation horizontal
        this.animator.SetFloat("horizontal", xInput);

        //Check si le player est sur le sol
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.30f, groundLayer);

        //Active le script de déplacement & Active le physicMat de noFriction (permet au joueur de se déplacer sur des pentes) 
        if (xInput != 0)
        {
            isMoving = true;
        }
        //Désactive la fonction & active le physicMat noFriction (permet au player de ne pas glisser sur les pentes)
        else
        {
            isMoving = false;
        }

        //Active jump si input est maintenu 
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
        {
            jumpQueued = true;
            this.animator.SetBool("jump", true);

        }

        //Active le low Jump si input est "juste préssé"
        if (myRigidbody.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) )
        {
            isFastJumping = true;
        }

        //Rotate l'avatar dans la même direction (+ / -) ou le player bouge
        if (Input.GetAxis("Horizontal") != 0)
        {
            Quaternion turnModel = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
            model.rotation = turnModel;
        }

        //On détecte si la vélocité en y du player est inf à 0 et on active la fake gravité  
        if (myRigidbody.velocity.y < 0)
        {
            isFalling = true;

        }

        /*Désactive la fake gravité si player sur le ground
        if (isGrounded)
        {
            isFalling = false;
            
        }*/

        //ANIMATION JUMP

        if (Input.GetButton("Jump"))
        {
            this.animator.SetBool("jump", true);
        }

        if (isGrounded)
        {
            this.animator.SetBool("grounded", true);
            this.animator.SetBool("jump", false);
            this.animator.SetBool("falling", false);
        }
        else
        {
            this.animator.SetBool("grounded", false);
        }

        if (isFalling)
        {
            this.animator.SetBool("falling", true);
        }

    }

    private void FixedUpdate()
    {
        //Physique du déplacement
        if (isMoving)
        {
            myRigidbody.velocity = movementVector;
        }

        //si player au sol, alors on autorise le Jump 
        if (isGrounded)
        {
            if (jumpQueued)
            {
                myRigidbody.velocity += Vector3.up * playerJumpForce;
                Debug.Log("Yolo");
                jumpQueued = false;
            }
        }
        else
        {
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //physique de la fake gravité
        if (isFalling)
        {
           // myRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //physique du lowJump
        if (isFastJumping)
        {
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            isFastJumping = false;
        }
    }
}
