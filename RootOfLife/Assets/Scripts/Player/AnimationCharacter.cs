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

    //SCRIPTS
    LedgeClimb ledgeClimb;
    PlayerClimbing playerClimbing;
    RespawnMerged respawnMerged;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.Find("TestCharacter27_janvier");
        ledgeClimb = GetComponent<LedgeClimb>();
        playerClimbing = GetComponent<PlayerClimbing>();
        respawnMerged = GetComponent<RespawnMerged>();
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
    }
    private void FixedUpdate()
    {
        //Animation mort asphyxie
        if (isDying)
        {
            animator.SetTrigger("die");
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
        //Mort
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            animator.SetTrigger("die");
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
}
