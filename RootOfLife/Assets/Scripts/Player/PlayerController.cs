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

    //Liane

    LadderClimb ladderClimb;
    public GameObject liane;
    public bool isClimbing;

    public bool plantIsPlugged;
    public bool playerIsPushing;
    public bool canPlug;

    public ParticleSystem dust;

    public bool isJumping;
    private bool isActivated;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        jumpQueued = false;
        isMoving = false;
        isFalling = false;
        isFastJumping = false;
        plantIsPlugged = false;

        //liane = GameObject.Find("LianeRigide");
        //ladderClimb = liane.GetComponent<LadderClimb>();

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

        //Active le script de déplacement
        if (xInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            //myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
        }

        //Active jump si input est maintenu 
        if (Input.GetButtonDown("Jump"))
        {
            jumpQueued = true;
            Debug.Log("Jump!");
            this.animator.SetBool("jump", true);
            CreateDust();
        }

        //Active le low Jump si input est "juste préssé"
        /*if (myRigidbody.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) )
        {
            isFastJumping = true;
        }*/

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
        if (canPlug)
        {
            if (Input.GetKeyDown(KeyCode.G) || Input.GetButtonDown("Fire1"))
            {
                plantIsPlugged = true;
            }
        }


        if (Input.GetKey(KeyCode.P) || Input.GetButton("Fire2"))
        {
            playerIsPushing = true;
        }
        else
        {
            playerIsPushing = false;
        }



        //ANIMATION JUMP

        if (Input.GetButton("Jump"))
        {
            this.animator.SetBool("jump", true);
            isJumping = true;
        }

        if (isGrounded)
        {
            this.animator.SetBool("grounded", true);
            this.animator.SetBool("jump", false);
            this.animator.SetBool("falling", false);
            // GetComponent<LianeController>().enabled = true;
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
            isJumping = false;

            if (jumpQueued)
            {
                myRigidbody.velocity += Vector3.up * playerJumpForce;
                jumpQueued = false;
            }

            /*if (isFastJumping)
            {
                myRigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                isFastJumping = false;
            }*/
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


    }

    //Slope

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Slope")
        {
            if (myRigidbody.velocity.y < 0)
            {
                animator.SetBool("Sliding", true);
            }
            else
            {
                animator.SetBool("Sliding", false);
            }
        }
        else
        {
            animator.SetBool("Sliding", false);
        }

        /*if (collision.gameObject.tag == "GoodGround")
        {
            canPlug = true;
        }
        else
        {
            canPlug = false;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlugArea" && !isActivated)
        {
            canPlug = true;
            StartCoroutine("PlugPos");
        }

        if (other.gameObject.tag == "PlugArea" && isActivated)
        {
            canPlug = false;
            StartCoroutine("PlugNeg");
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            CreateDust();
        }
    }
    void CreateDust()
    {
        dust.Play();
    }

    IEnumerator PlugNeg()
    {
        yield return new WaitForSeconds(0.1f);
        isActivated = false;
    }

    IEnumerator PlugPos()
    {
        yield return new WaitForSeconds(0.1f);
        isActivated = true;
    }
}
