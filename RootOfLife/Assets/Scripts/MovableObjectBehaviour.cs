using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public bool playerTouching;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
            playerTouching = true;
            //StartCoroutine("Timeleft");
            this.animator.SetBool("pushing", true);
        }
        else
        {
            playerTouching = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = true;
            playerTouching = false;
            this.animator.SetBool("pushing", false);
        }
    }

    /*IEnumerator Timeleft()
    {
        yield return new WaitForSeconds(1f);
        if (!playerTouching)
        {
            rb.isKinematic = true;
            StopCoroutine("Timeleft");
        }
        else

            StopCoroutine("Timeleft");

    }*/
    
}
