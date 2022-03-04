using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimb : MonoBehaviour
{
    public bool isClimbing;
    public Transform climbStartPoint;
    public Transform climbEndPoint;
    public float timerAnimation;
    public Animator animator;
    PlayerController playerController;
    public bool isJumping;



    void Start()
    {
        timerAnimation = 2.4f;
    }


    void Update()
    {

        isJumping = GetComponent<PlayerController>().isJumping;

        if (isClimbing)
        {
            //this.gameObject.GetComponent<Transform>().position = climbStartPoint.transform.position;

            //StartCoroutine(Waiter());

            animator.SetBool("ledgeClimbing", true);
        }
        else
        {
            animator.SetBool("ledgeClimbing", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge") && isJumping)
        {
            climbStartPoint = other.gameObject.transform.GetChild(1);
            climbEndPoint = other.gameObject.transform.GetChild(0);

            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Transform>().position = climbStartPoint.transform.position;
            StartCoroutine(Waiter());
            isClimbing = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge"))
        {
            //isClimbing = false;
        }
    }

    IEnumerator Waiter()
    {
        //wait durant le temps de l,animation
        yield return new WaitForSeconds(timerAnimation);
        //position au empty ClimbEndPoint
        this.gameObject.GetComponent<Transform>().position = climbEndPoint.transform.position;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        isClimbing = false;
    }

}
