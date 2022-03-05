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
    public PlayerController playerController;
    public bool isJumping;
    public Vector3 endOffset;
    public int direction;



    void Start()
    {
        //timerAnimation = 2.3f;
        direction = 1;
    }


    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        }
  

        isJumping = GetComponent<PlayerController>().isJumping;

        if (isClimbing)
        {
            //this.gameObject.GetComponent<Transform>().position = climbStartPoint.transform.position;

            //StartCoroutine(Waiter());

            animator.SetBool("ledgeClimbing", true);
            GetComponent<PlayerController>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            //this.gameObject.GetComponent<Transform>().position = Vector3.Lerp(transform.position, climbEndPoint.transform.position + endOffset, 20f * Time.deltaTime);
        }
        else
        {
            //animator.SetBool("ledgeClimbing", false);
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
            isClimbing = true;
            endOffset = new Vector3(-2, 0, 0) * direction;
            StartCoroutine(Waiter());


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
        endOffset = new Vector3(2, 0, 0) * direction;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        GetComponent<PlayerController>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        isClimbing = false;
        animator.SetBool("ledgeClimbing", false);
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

    }

}
