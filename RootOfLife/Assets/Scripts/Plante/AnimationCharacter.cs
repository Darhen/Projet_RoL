using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    public GameObject avatar;
    public Animator animator;
    

    //BOOLS
    public bool isLedgeClimbing;
    public bool isJumping;
    public bool isClimbing;
    public float yInput;
    public float xInput;

    //SCRIPTS
    LedgeClimb ledgeClimb;
    PlayerClimbing playerClimbing;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.Find("TestCharacter27_janvier");
        ledgeClimb = GetComponent<LedgeClimb>();
        playerClimbing = GetComponent<PlayerClimbing>();
    }

    // Update is called once per frame
    void Update()
    {
        //float input horizontal et vertical
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        animator.SetFloat("horizontal", xInput);
        animator.SetFloat("vertical", yInput);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge") && isJumping)
        {
            animator.Play("LedgeClimb");
            animator.SetBool("jump", false);
        }
    }
}
