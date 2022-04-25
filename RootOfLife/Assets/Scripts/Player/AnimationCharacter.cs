using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    public GameObject avatar;
    public Animator animator;
    public Animator trampolineAnimator;
    [SerializeField] ParticleSystem particleHit = null;

    //VARIABLES
    public bool isLedgeClimbing;
    public bool isJumping;
    public bool isClimbing;
    public float yInput;
    public float xInput;
    public bool isDying;
    public bool isGrounded;
    public bool isFalling;
    public bool pushingController;
    public int direction;
    public bool plantIsPlugged;
    private float yVelocity;
    private Rigidbody myRigidbody;

    //SCRIPTS
    public LedgeClimb ledgeClimb;
    PlayerClimbing playerClimbing;
    RespawnMerged respawnMerged;
    PlayerController playerController;
    MoveObject moveObject;


    //SON 
    public AK.Wwise.Event MoveObjectSFX;
    public AK.Wwise.Event MoveObjectStopSFX;
    public AK.Wwise.Event SlopeSFX;
    public AK.Wwise.Event SlopeStopSFX;
   // public AK.Wwise.Event KneelSFX;
    private bool SFXisPlayed;
    private bool BoxSFXisPlaying;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.Find("TestCharacter27_janvier");
        //ledgeClimb = GetComponent<LedgeClimb>();
        playerClimbing = GetComponent<PlayerClimbing>();
        respawnMerged = GetComponent<RespawnMerged>();
        playerController = GetComponent<PlayerController>();
        moveObject = GetComponent<MoveObject>();
        ParticleSystem particleHit = GameObject.Find("Particle Hit").GetComponent<ParticleSystem>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float input horizontal et vertical
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        animator.SetFloat("horizontal", xInput);
        animator.SetFloat("vertical", yInput);
        animator.SetFloat("yVelocity", yVelocity);

        //update velocity
        yVelocity = myRigidbody.velocity.y;

        //update bools
        isGrounded = playerController.isGrounded;
        pushingController = moveObject.pushingController;
        plantIsPlugged = playerController.plantIsPlugged;
        isDying = respawnMerged.isDying;
        isFalling = playerController.isFalling;
        //UPDATE BOOLS ANIMATION

        //grounded
        if (isGrounded)
        {
            animator.SetBool("grounded", true);
        }
        if (!isGrounded)
        {
            animator.SetBool("grounded", false);
        }

        //Animation falling
        if (isFalling)
        {
            animator.SetBool("falling", true);
        }
        if (!isFalling)
        {
            animator.SetBool("falling", false);
        }

        //Animation jump
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
        }

        //Animation ledge climb (voir OnTriggerEnter pour le reste)
        isLedgeClimbing = ledgeClimb.isLedgeClimbing;
        isJumping = ledgeClimb.isJumping;

        //Animation ladder climb
        isClimbing = playerClimbing.isClimbing;
        if (isClimbing)
        {
            animator.SetBool("isClimbing", true);
        }
        else
        {
            animator.SetBool("isClimbing", false);
        }

        //Animation mort asphyxie (voir coroutine Respawn pour suite)
        if (isDying)
        {
            animator.SetBool("dieAir", true);
            StartCoroutine(Respawn());
        }

        //Animation controller pushing
        direction = moveObject.direction;
        if (pushingController)
        {
            if (!BoxSFXisPlaying)
            {
                MoveObjectSFX.Post(gameObject);
                BoxSFXisPlaying = true;
            }
            

            if (direction == 1)
            {
                animator.SetBool("pushingDroit", true);
            }
            if (direction == -1)
            {
                animator.SetBool("pushingGauche", true);
            }
        }
        if (!pushingController)
        {
            animator.SetBool("pushingDroit", false);
            animator.SetBool("pushingGauche", false);

            MoveObjectStopSFX.Post(gameObject);
            BoxSFXisPlaying = false;
        }

        //Animation plug plant
        if (plantIsPlugged)
        {
            animator.SetBool("growing", true);
            //KneelSFX.Post(gameObject);
        }
        if (!plantIsPlugged)
        {
            animator.SetBool("growing", false);
           // KneelSFX.Stop(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*
        //Ledge Climb
        if (isLedgeClimbing)
        {
            animator.Play("LedgeClimb");
        }
        */
        /*
        if (other.gameObject.CompareTag("Ledge") && isJumping && !isClimbing)
        {
            animator.Play("LedgeClimb");
            animator.SetBool("jump", false);
        }
        else if (other.gameObject.CompareTag("Ledge") && !isJumping && isClimbing)
        {
            animator.Play("LedgeClimb");
        }
        else if (isLedgeClimbing)
        {
            animator.Play("LedgeClimb");
        }
        */
        /* }
         private void OnTriggerEnter(Collider other)
         {*/
        //Mort Bras robot (voir coroutine Respawn pour la suite)
        if (other.gameObject.CompareTag("Ennemi"))
        {
            animator.SetBool("armDeath", true);
            StartCoroutine(Respawn());
        }
        //Mort robot spider (voir coroutine Respawn pour la suite)
        if (other.gameObject.CompareTag("EnnemiGround") || other.gameObject.CompareTag("EnnemiSolBoss"))
        {
            animator.SetBool("spiderDeath", true);
            StartCoroutine(Respawn());
        }
        //Mort robot drone (voir coroutine Respawn pour la suite)
        if (other.gameObject.CompareTag("EnnemiDrone"))
        {
            particleHit.Play();
            animator.SetBool("dieAir", true);
            StartCoroutine(Respawn());
        }
    }

    // SFX SLOPES
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Slope")
        {
            if (SFXisPlayed == false)
            {
                SlopeSFX.Post(gameObject);
                Debug.Log(SlopeSFX);
                SFXisPlayed = true;
            }
        }

        if (other.gameObject.tag != "Slope")
        {
            if(SFXisPlayed == true)
            {
                SlopeStopSFX.Post(gameObject);
                //SlopeSFX.Stop(this.gameObject, 500, AkCurveInterpolation.AkCurveInterpolation_Constant);
                Debug.Log(SlopeStopSFX);
                SFXisPlayed = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Slope
        if (collision.gameObject.CompareTag("Slope"))
        {
            animator.SetBool("Sliding", true);
        }
        else
        {
            animator.SetBool("Sliding", false);
        }
    }

    //Sequence de reset mort au respawn
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("dieAir", false);
        animator.SetBool("armDeath", false);
        animator.SetBool("spiderDeath", false);
    }
}
