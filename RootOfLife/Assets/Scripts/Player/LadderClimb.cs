using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float speed = 1;
    private float playerXInput;
    private float jumpForce;
    

    // Start is called before the first frame update
    void Start()
    {
    
      
    }
    
    private void Update()
    {
       
    }

    /*private void OnTriggerStay(Collider other)
    {
        //other.GetComponent<Rigidbody>().useGravity = false;

        if (other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
        }

        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, 0);
        }
    }*/

    /*private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().isKinematic = true;

        if (other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Transform>().position = new Vector3(other.GetComponent<Transform>().position.x, speed, other.GetComponent<Transform>().position.z);
        }

        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Transform>().position = new Vector3(other.GetComponent<Transform>().position.x, -speed, other.GetComponent<Transform>().position.z);
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        playerXInput = other.GetComponent<PlayerController>().xInput * other.GetComponent<PlayerController>().speed;
        jumpForce = other.GetComponent<PlayerController>().playerJumpForce;

        if (other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
            other.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }

        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, 0);
            other.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }

        else
        {
            
            if (other.GetComponent<PlayerController>().isGrounded == false )
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
            
            if (Input.GetButton("Jump"))
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                other.GetComponent<Rigidbody>().AddForce(playerXInput, jumpForce, 0);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

}


