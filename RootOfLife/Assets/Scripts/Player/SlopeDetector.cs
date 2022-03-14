using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeDetector : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody rbPlayer;

    public bool sliding;
    public Vector3 slidingSpeed;
    public float jumpForce;
    private bool jump;

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
    }

    private void FixedUpdate()
    {
        if (sliding)
        {
            rbPlayer.velocity = slidingSpeed;

            if(jump)
            {
                rbPlayer.velocity += Vector3.up * jumpForce;
                jump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Slope"))
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
