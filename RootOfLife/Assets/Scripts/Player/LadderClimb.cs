using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float speed = 5;
    private float playerXInput;
    private float jumpForce;

    public bool movingUp;
    public bool movingDown;

    public Animator animator;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        movingUp = false;
        movingDown = false;
        
      
    }
    
    private void Update()
    {
       if (Input.GetAxis("Vertical") > 0)
        {
            movingUp = true;
            movingDown = false;
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            movingUp = false;
            movingDown = true;
        }

        else
        {
            movingUp = false;
            movingDown = false;
        }

    }


    private void OnTriggerStay(Collider other)
    {
        playerXInput = other.GetComponent<PlayerController>().xInput * other.GetComponent<PlayerController>().speed;
        jumpForce = other.GetComponent<PlayerController>().playerJumpForce;

        if (other.tag == "Player" && movingUp == true)
        {
            
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
            other.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            animator.SetBool("isClimbing", true);
        }

        else if (other.tag == "Player" && movingDown == true)
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, 0);
            other.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            animator.SetBool("isClimbing", true);
        }

        else
        {
            
            if (other.GetComponent<PlayerController>().isGrounded == false )
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

                animator.SetBool("isClimbing", true);

            }
            
            if (Input.GetButton("Jump"))
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                other.GetComponent<Rigidbody>().AddForce(playerXInput, jumpForce, 0);

                animator.SetBool("isClimbing", false);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        animator.SetBool("isClimbing", false);

    }

}


