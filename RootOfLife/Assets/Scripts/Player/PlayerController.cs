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

    //Ladder

    LadderClimb ladderClimb;
    public GameObject liane;
    public bool isClimbing;

    public bool plantIsPlugged;
    public bool playerIsPushing;

    public ParticleSystem dust;
    public ParticleSystem jump;

    public bool isJumping;
    private bool isActivated;

    public bool canSpawnSac;

    //Trampoline
    public bool trampolineMode;

    PlugPlant plugPlant;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        jumpQueued = false;
        isMoving = false;
        isFalling = false;
        isFastJumping = false;
        plantIsPlugged = false;

        dust.gameObject.SetActive(false);
        //liane = GameObject.Find("LianeRigide");
        //ladderClimb = liane.GetComponent<LadderClimb>();

    }


    void Update()
    {


        //On stock dans un float l'input x qu'on insert dans un vector3 multipli? par speed et en ignorant la v?locit? y du rigidbody ("?vite les conflits de physique")
        xInput = Input.GetAxis("Horizontal");
        //movementVector = new Vector3(xInput * speed, myRigidbody.velocity.y, 0);
        //deplacementX = xInput * speed;

        //Animation horizontal
        this.animator.SetFloat("horizontal", xInput);

        //Check si le player est sur le sol
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.30f, groundLayer);

        //Active le script de d?placement
        if (xInput != 0 && !plantIsPlugged)
        {
            isMoving = true;
            movementVector = new Vector3(xInput * speed, myRigidbody.velocity.y, 0);
        }
        else
        {
            isMoving = false;
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0);
        }


        //Active jump si input est maintenu 
        if (!trampolineMode)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpQueued = true;
                Debug.Log("Jump!");

                if (isGrounded)
                {
                    JumpPs();
                }

            }
        }



        //Active le low Jump si input est "juste pr?ss?"
        /*if (myRigidbody.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) )
        {
            isFastJumping = true;
        }*/

        //Rotate l'avatar dans la m?me direction (+ / -) ou le player bouge
        if (Input.GetAxis("Horizontal") != 0)
        {
            Quaternion turnModel = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
            model.rotation = turnModel;
        }

        //On d?tecte si la v?locit? en y du player est inf ? 0 et on active la fake gravit?  
        if (myRigidbody.velocity.y < -14)
        {
            isFalling = true;

        }
        else
        {
            isFalling = false;
        }

        if(canSpawnSac)
        {
            if (Input.GetKeyDown(KeyCode.G) && !plantIsPlugged || Input.GetButtonDown("Fire1") && !plantIsPlugged)
            {
                plantIsPlugged = true;
                movementVector = new Vector3(0, myRigidbody.velocity.y, 0);
            }
        }

        //Bool is jumping residu du animator, a verifier si encore utile dans un autre script

        if (Input.GetButton("Jump"))
        {
            isJumping = true;

        }

        //pushing
        /*
        if (Input.GetKey(KeyCode.P) || Input.GetButton("Fire3"))
        {
            playerIsPushing = true;
        }
        else
        {
            playerIsPushing = false;
        }
        */
        if (plantIsPlugged)
        {
            speed = 0;
            myRigidbody.velocity = new Vector3(0, 0, 0);
        }

        if (!plantIsPlugged)
        {
            speed = 10;
        }
    }

    private void FixedUpdate()
    {
        //Physique du d?placement
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
            myRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; // Fake Gravit?
        }

        //physique de la fake gravit?
        if (isFalling)
        {
            // myRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.layer == 6)
        {
            CreateDust();
        }*/
        if (other.gameObject.tag == "Slope")
        {
            CreateDust();
        }
    }

    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "Slope")
        {
            StartCoroutine("TimerDust");
        }
    }

    IEnumerator TimerDust()
    {
        yield return new WaitForSeconds(.25f);
        dust.gameObject.SetActive(false);
    }
    void CreateDust()
    {
        StopCoroutine("TimerDust");
        dust.gameObject.SetActive(true);
        dust.Play();
    }

    void JumpPs()
    {
        jump.Play();
    }

}
