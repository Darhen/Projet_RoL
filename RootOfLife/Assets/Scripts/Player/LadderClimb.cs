using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float speed = 2;
    private float playerXInput;
    private float jumpForce;

    public bool moving;
   

    public Animator animator;
    public GameObject avatar;
    public float yInput;
    public bool playerGrounded;
    public bool climbing;
    public GameObject Player;
    public int initialFallmultiplier;
    private Vector3 playerPosition;

    PlayerController playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        moving= false;
        Player = GameObject.Find("Player");
        avatar = GameObject.Find("TestCharacter27_janvier");
        initialFallmultiplier = Player.GetComponent<PlayerController>().fallMultiplier;
        playerController = Player.GetComponent<PlayerController>();
        playerPosition = Player.GetComponent<Transform>().position;
    }
    
    private void Update()
    {
        yInput = Input.GetAxis("Vertical");
        avatar.GetComponent<Animator>().SetFloat("vertical", yInput);
        jumpForce = playerController.playerJumpForce;
        playerXInput = playerController.xInput * playerController.speed;
        jumpForce = playerController.playerJumpForce;

        //activation du box collider lorsque le player isGrounded
        playerGrounded = GameObject.FindWithTag("Player").GetComponent<PlayerController>().isGrounded;

        //activation du box collider lorsque le player isGrounded
        if (playerGrounded)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            //Debug.Log("grounded");
       
        }
       
        //detection si le player bouge

        if (yInput != 0)
        {
            moving = true;
        }

        //detection si le player bouge pas
        else
        {
            moving = false;
        }

        //bool animation pour climbing
        if (climbing)
        {
            animator.SetBool("jump", false);
            animator.SetBool("isClimbing", true);
        }

        else 
        {
            animator.SetBool("isClimbing", false);
        }


    }

    private void FixedUpdate()
    {
        //déplacements sur liane
        if (climbing)
        {
            playerPosition.x = transform.position.x;
            playerPosition.z = transform.position.z;
            //Player.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            Player.GetComponent<PlayerController>().fallMultiplier = 0;

            if (moving)
            {
                Player.GetComponent<Rigidbody>().velocity = new Vector3(0, yInput * speed, 0);
                Player.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
            else
            {
                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
           
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        else
        {
            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            Player.GetComponent<PlayerController>().fallMultiplier = initialFallmultiplier;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetButton("Fire3"))
            {
            climbing = true;
            }
        else
        {
            climbing = false;
        }

    }

        private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        animator.SetBool("isClimbing", false);

    }

    void Jump()
    {
        climbing = false;
        
    }

}


