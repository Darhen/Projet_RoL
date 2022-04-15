using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    PlayerController playerController;
    Plane plane;
    public bool isGrounded;
    Rigidbody rb;
    public float upSpeed;
    public float velocityCheck;
    public float velocityLimit;
    public bool bounceSpeedChecked;
    public bool bounce;

    public bool canBounce;
    public int countJump;
    public bool jumpPressed;
    public bool isGliding;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        plane = GetComponent<Plane>();
        bounce = false;
        canBounce = false;
        countJump = 0;
        upSpeed = 1300;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = playerController.isGrounded;
        velocityCheck = rb.velocity.y;
        isGliding = plane.isGliding;

        if (velocityCheck <= velocityLimit)
        {
            bounceSpeedChecked = true;
        }
        else
        {
            bounceSpeedChecked = false;
        }
        if (isGrounded && bounce)
        {
            StartCoroutine("DeactivateBounce");

        }

        if (canBounce)
        {
            if (countJump == 0)
            {
                playerController.trampolineMode = false;
                if (Input.GetButtonDown("Jump"))
                {
                    //StartCoroutine("JumpCount");
                    countJump++;
                }
            }

            else
            {
                playerController.trampolineMode = true;

                /*if (Input.GetButton("Jump"))
                {
                    if (!isGliding)
                    {
                        jumpPressed = true;
                        //StartCoroutine("JumpInputTimer");
                    }
                    else
                    {
                        return;
                    }
                }*/
            }


        }
        else
        {
            jumpPressed = false;
        }

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canBounce)
        {
            if (jumpPressed)
            {
                if (collision.gameObject.CompareTag("Trampoline"))
                {
                    StartCoroutine("TrampolineJump");
                    collision.gameObject.GetComponent<Animator>().SetTrigger("Bounce");

                }
            }
            else
            {
                if (collision.gameObject.CompareTag("Trampoline"))
                {
                    collision.gameObject.GetComponent<Animator>().SetTrigger("Bounce");
                    countJump = 0;
                }
            }

        }



        if (collision.gameObject.CompareTag("Untagged"))
        {
            countJump = 0;
            playerController.trampolineMode = false;
            canBounce = false;
            jumpPressed = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Trampoline")
        {
            canBounce = true;

            if (countJump == 0)
            {
                StartCoroutine("DelayJumpInit");
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (!isGliding)
                    {
                        jumpPressed = true;
                        //StartCoroutine("JumpInputTimer");
                    }
                }
            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trampoline")
        {
            canBounce = true;
        }

    }
    */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trampoline")
        {
            canBounce = false;
            playerController.trampolineMode = false;
            jumpPressed = false;
        }
    }


    IEnumerator TrampolineJump()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upSpeed, 0));
        yield return new WaitForSeconds(0.01f);
        bounce = true;

    }
    IEnumerator DeactivateBounce()
    {
        yield return new WaitForSeconds(2f);
        bounce = false;

    }

    IEnumerator JumpCount()
    {
        yield return new WaitForSeconds(0.2f);
        countJump++;
    }

    IEnumerable JumpInputTimer()
    {
        jumpPressed = true;
        yield return new WaitForSeconds(0.3f);
        jumpPressed = false;
    }

    IEnumerator DelayJumpInit()
    {
        yield return new WaitForSeconds(8f);
        playerController.trampolineMode = false;
    }
}
