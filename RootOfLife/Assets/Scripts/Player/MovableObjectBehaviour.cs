using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour
{

    private Rigidbody rb;
    public Animator animator;
    private bool isPushing;

    PlayerController playerController;
    GameObject player;
    private bool buttonIsPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        buttonIsPressed = playerController.playerIsPushing;

        if (buttonIsPressed)
        {
            isPushing = true;
        }
        else
        {
            isPushing = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(isPushing)
            {
                rb.isKinematic = false;
                this.animator.SetBool("pushing", true);
            }
            else if (!isPushing)
            {
                rb.isKinematic = true;
                this.animator.SetBool("pushing", false);
            }
        }
    }
}
