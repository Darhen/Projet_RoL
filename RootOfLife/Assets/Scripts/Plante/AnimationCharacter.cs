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

    //SCRIPTS
    LedgeClimb ledgeClimb;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.Find("TestCharacter27_janvier");
        ledgeClimb = GetComponent<LedgeClimb>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animation ledge climb (voir OnTriggerEnter pour le reste)
        isLedgeClimbing = ledgeClimb.isLedgeClimbing;
        isJumping = ledgeClimb.isJumping;

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
