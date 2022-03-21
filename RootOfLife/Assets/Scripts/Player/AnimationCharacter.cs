using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    public GameObject avatar;
    public Animator animator;
    

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

    //SCRIPTS
    LedgeClimb ledgeClimb;
    PlayerClimbing playerClimbing;
    RespawnMerged respawnMerged;
    PlayerController playerController;
    MoveObject moveObject;


    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.Find("TestCharacter27_janvier");
        ledgeClimb = GetComponent<LedgeClimb>();
        playerClimbing = GetComponent<PlayerClimbing>();
        respawnMerged = GetComponent<RespawnMerged>();
        playerController = GetComponent<PlayerController>();
        moveObject = GetComponent<MoveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //float input horizontal et vertical
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        animator.SetFloat("horizontal", xInput);
        animator.SetFloat("vertical", yInput);
        isDying = respawnMerged.isDying;
        isFalling = playerController.isFalling;

        //update bools
        isGrounded = playerController.isGrounded;
        pushingController = moveObject.pushingController;

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
        if(isFalling)
        {
            animator.SetBool("falling", true);
        }
        if(!isFalling)
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Ledge Climb
        if (other.gameObject.CompareTag("Ledge") && isJumping)
        {
            animator.Play("LedgeClimb");
            animator.SetBool("jump", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Mort Bras robot (voir coroutine Respawn pour la suite)
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            animator.SetBool("armDeath", true);
            StartCoroutine(Respawn());
        }
        //Mort robot spider (voir coroutine Respawn pour la suite)
        if (collision.gameObject.CompareTag("EnnemiGround"))
        {
            animator.SetBool("spiderDeath", true);
            StartCoroutine(Respawn());
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
