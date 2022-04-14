using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    PlayerController playerController;
    public bool isGrounded;
    Rigidbody rb;
    public float upSpeed;
    public float velocityCheck;
    public float velocityLimit;
    public bool bounceSpeedChecked;
    public bool bounce;
    private GameObject trampoline;
    public bool bounceTriggered;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        bounce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        velocityCheck = rb.velocity.y;

        /*
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
        */

        if (isGrounded && bounceSpeedChecked)
        {
            StartCoroutine("TrampolineJump");
            //this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upSpeed, 0));
            //jouer animation bounce feuille
            //collision.gameObject.GetComponent<Animator>().Play("trampoline_bounce");
            trampoline.GetComponent<Animator>().SetTrigger("Bounce");
            //bounce = true;
        }
        else
        {
            return;
        }
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }

        /*
        if(collision.gameObject.CompareTag("Trampoline") && bounceSpeedChecked)
        {
            StartCoroutine("TrampolineJump");
            //this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upSpeed, 0));
            //jouer animation bounce feuille
            //collision.gameObject.GetComponent<Animator>().Play("trampoline_bounce");
            collision.gameObject.GetComponent<Animator>().SetTrigger("Bounce");
            //bounce = true;
        }
        else
        {
           return;
        }
        */
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGrounded && other.gameObject.tag== "Trampoline")
        {

            if(Input.GetButtonDown(" Jump"))
            {
                bounceSpeedChecked = true;
                bounceTriggered = true;
            }
        }
        else
        {

            return;
        }
        if (other.gameObject.tag == "Trampoline")
        {
            trampoline = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trampoline")
        {
            bounceSpeedChecked = false;
            StartCoroutine("DeactivateBounce");
        }
    }

    IEnumerator TrampolineJump()
    {
        //indique au script PlayerController que le bounce actuel est un trampolineBounce
        playerController.trampolineBounce = true;

        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upSpeed, 0));
        yield return new WaitForSeconds(0.01f);
        bounce = true;
    }
    IEnumerator DeactivateBounce()
    {
        //indique au script PlayerController que le bounce n'est pas un trampoline bounce
        playerController.trampolineBounce = false;

        bounceTriggered = false;
        yield return new WaitForSeconds(2f);
        bounce = false;
    }
}
