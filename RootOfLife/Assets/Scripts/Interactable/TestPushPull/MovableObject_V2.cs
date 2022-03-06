using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject_V2 : MonoBehaviour
{
    private Rigidbody rb;
    public Animator animator;

    PlayerController playerController;
    GameObject player;
    private bool buttonIsPressed;
    public float xInput;
    public bool playerIsTouching;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        xInput = playerController.xInput;
        buttonIsPressed = playerController.playerIsPushing;

        if (playerIsTouching)
        {
            if (buttonIsPressed)
            {
                //MERGE POS PLAYER ET BOX / Parenting?

                if (xInput > 0) //Push
                {
                    rb.isKinematic = false;
                    this.animator.SetBool("pushing", true);
                }
                else
                {
                    this.animator.SetBool("pushing", false);
                }

                if (xInput < 0) //Pull
                {
                    // IS PULLING ---> trouver un moyen de merge les position du bloc et du player
                }
                else
                {

                }

                if (xInput == 0) // Static
                {
                    rb.isKinematic = true;
                }
            }
            else // Demerge des position du player et de la box / deparenting?
            {
                rb.isKinematic = true;
                this.animator.SetBool("pushing", false);
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsTouching = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsTouching = false;
        }
    }
}
