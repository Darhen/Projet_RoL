using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeDetector : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody rbPlayer;
    slopeOrientation SlopeOrientation;

    public bool sliding;
    public Vector3 slidingSpeed;
    public float jumpForce;
    private bool jump;
    private int direction;
    public Transform model;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rbPlayer = GetComponent<Rigidbody>();

        slidingSpeed = new Vector3(10, -10, 0);
        jumpForce = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            jump = true;
        }

       
        if (sliding)
        {
            // if(rbPlayer.velocity.x > 0)
           // {
                direction = 1;
           // }
           // if(rbPlayer.velocity.x < 0)
           // {
            //    direction = -1;
            //}
            Quaternion turnModel = Quaternion.LookRotation(new Vector3(direction, 0, 0));
            model.rotation = turnModel;
        }
    }

    private void FixedUpdate()
    {
        if (sliding /*&& SlopeOrientation.slidingRight == true*/)
        {
            rbPlayer.velocity = slidingSpeed;

            if(jump)
            {
                rbPlayer.velocity += Vector3.up * jumpForce;
                jump = false;
            }
        }
/*
        if (sliding && SlopeOrientation.slidingLeft == true)
        {
            rbPlayer.velocity = -slidingSpeed;

            if (jump)
            {
                rbPlayer.velocity += Vector3.up * jumpForce;
                jump = false;
            }
        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Slope") /*&& SlopeOrientation.slidingRight == true*/)
        {
            playerController.enabled = false;
            sliding = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slope"))
        {
            playerController.enabled = true;
            sliding = false;
        }
    }
}
