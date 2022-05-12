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

    public AK.Wwise.Event BouncePlayerSFX;
    public AK.Wwise.Event BouncePlantSFX;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        plane = GetComponent<Plane>();
        bounce = false;
        canBounce = false;
        countJump = 0;
        upSpeed = 1400;
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
                    //jumpPressed = true;
                    countJump++;
                }
            }
            else if (countJump == 1)
            {
                playerController.trampolineMode = true;
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
        else
        {
            jumpPressed = false;
            countJump = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            //StartCoroutine("DelayJumpReinit");

            if (canBounce)
            {
                if (countJump == 1)
                {
                    if (jumpPressed)
                    {
                        collision.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play(true);
                        StartCoroutine("TrampolineJump");
                        StartCoroutine("DelayJumpReinit");
                        collision.gameObject.GetComponent<Animator>().SetTrigger("Bounce");
                        BouncePlantSFX.Post(gameObject);
                        Debug.Log(BouncePlantSFX);
                    }
                    else
                    {
                        collision.gameObject.GetComponent<Animator>().SetTrigger("Bounce");
                        countJump = 0;
                        BouncePlantSFX.Post(gameObject);
                        Debug.Log(BouncePlantSFX);
                    }
                }
                
            }
        }

        if (collision.gameObject.CompareTag("Untagged"))
        {
            countJump = 0;
            playerController.trampolineMode = false;
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            if (!canBounce)
            {
                countJump = 0;
            }
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Trampoline")
        {
            canBounce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trampoline")
        {
            canBounce = false;
            countJump = 0;
            //jumpPressed = false;

            /*if (!canBounce)
            {
                countJump = 0;
            }*/
        }
    }


    IEnumerator TrampolineJump()
    {
        BouncePlayerSFX.Post(gameObject);
        Debug.Log(BouncePlayerSFX);
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upSpeed, 0));
        yield return new WaitForSeconds(0.01f);
        bounce = true;

    }
    IEnumerator DeactivateBounce()
    {
        yield return new WaitForSeconds(2f);
        bounce = false;

    }
    /*
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
    
    */
    IEnumerator DelayJumpReinit()
    {
        countJump = 0;
        yield return new WaitForSeconds(0.5f);
        countJump = 1;
    }
    
}
