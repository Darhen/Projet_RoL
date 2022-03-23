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
        isGrounded = playerController.isGrounded;
        velocityCheck = rb.velocity.y;

        if (velocityCheck <= velocityLimit)
        {
            bounceSpeedChecked = true;
        }
        else
        {
            bounceSpeedChecked = false;
        }

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Trampoline") && bounceSpeedChecked && isGrounded)
        {

            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upSpeed, 0));
            //jouer animation bounce feuille
            //collision.gameObject.GetComponent<Animator>().Play("trampoline_bounce");
            collision.gameObject.GetComponent<Animator>().SetTrigger("Bounce");
        }
        else
        {
           return;
        }
    }

}
