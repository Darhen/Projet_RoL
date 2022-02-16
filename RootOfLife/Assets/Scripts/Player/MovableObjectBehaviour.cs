using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour
{

    private Rigidbody rb;
    public Animator animator;
    private bool isPushing;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            isPushing = true;
        }
        else
        {
            isPushing = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(isPushing)
            {
                rb.isKinematic = false;
                this.animator.SetBool("pushing", true);
            }
            else if (!isPushing)
            {
                rb.isKinematic = true;
                this.animator.SetBool("pushing", false);
            }
        }
    }

}
