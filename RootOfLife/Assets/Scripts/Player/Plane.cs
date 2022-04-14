using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    PlayerController playerController;
    public int fallMultiplier;
    public int initialFallMultiplier;
    public bool isGrounded;
    public bool jumpQueued;
    public int parachuteMultiplier;
    public Animator animator;
    Rigidbody myRigidBody;

    public float timerParachute;

    //variables camera

    public bool isGliding;

    // Start is called before the first frame update
    void Start()
    {
        initialFallMultiplier = GetComponent<PlayerController>().fallMultiplier;
        playerController = GetComponent<PlayerController>();
        parachuteMultiplier = -4;
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GetComponent<PlayerController>().isGrounded;
        jumpQueued = GetComponent<PlayerController>().jumpQueued;


        if (jumpQueued && !isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                //timer déclanchement parachute
                timerParachute += 1 * Time.deltaTime;

                //si le timer est atteint, on déclanche le parachute
                if(timerParachute >= 0.3f)
                {
                    GetComponent<PlayerController>().fallMultiplier = 1;
                    GetComponent<Rigidbody>().velocity = new Vector3(0, parachuteMultiplier, 0);

                    isGliding = true;

                    animator.SetBool("gliding", true);
                }

                /*
                GetComponent<PlayerController>().fallMultiplier = 1;
                GetComponent<Rigidbody>().velocity = new Vector3(0, parachuteMultiplier, 0);
                
                isGliding = true;

                animator.SetBool("gliding", true);
                */
            }
            if (Input.GetButtonUp("Jump"))
            {
                //reset du timer déclanchement parachute
                timerParachute = 0;

                GetComponent<PlayerController>().fallMultiplier = initialFallMultiplier;
                
                isGliding = false;

                animator.SetBool("gliding", false);
            }

            if (isGrounded)
            {
                //reset du timer déclanchement parachute
                timerParachute = 0;
            }
        }
        else
        {
            GetComponent<PlayerController>().fallMultiplier = initialFallMultiplier;

            isGliding = false;

            animator.SetBool("gliding", false);
        }
    }

    /*private void FixedUpdate()
    {
        if(isGliding)
        {
            GetComponent<PlayerController>().fallMultiplier = 1;
            //GetComponent<Rigidbody>().mass = 0.5f;
            GetComponent<Rigidbody>().velocity = new Vector3(myRigidBody.velocity.x, parachuteMultiplier, 0);

        }
        else
        {
            GetComponent<PlayerController>().fallMultiplier = initialFallMultiplier;
            //GetComponent<Rigidbody>().mass = 1f;
        }
    }*/
}
