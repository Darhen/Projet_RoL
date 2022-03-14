using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    PlayerController playerController;
    LedgeClimb ledgeClimb;
    Plane plane;
    Rigidbody rbPlayer;
    Vector3 ladderPosition;

    public bool isJumping;
    public bool isClimbing;
    public float offsetY;
    public float yInput;
    public float climbSpeed;
    public float xInput;
    public float offsetX;
    private int directionX;
    public float jumpForce;
    public bool jumpingOff;
    public bool isGrounded;
    public bool isLedgeClimbing;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        ledgeClimb = GetComponent<LedgeClimb>();
        plane = GetComponent<Plane>();
        rbPlayer = GetComponent<Rigidbody>();
        climbSpeed = 1.5f;
        jumpForce = 10;
    }

    // Update is called once per frame
    void Update()
    {
        isJumping = playerController.isJumping;
        isGrounded = playerController.isGrounded;
        isLedgeClimbing = ledgeClimb.isLedgeClimbing;

        //calcul des inputs
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");

        //calcul direction
        if (xInput > 0)
        {
            directionX = 1;
        }
        if (xInput < 0)
        {
            directionX = -1;
        }

        //permettre la collision avec le ladder une fois grounded apres un jump
        if(isGrounded)
        {
            jumpingOff = false;
        }

        //activer jump
        if (isClimbing)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //decalre jumpingOff pour empecher une nouvelle collision avec le ladder
                jumpingOff = true;
                //enlever kinematic
                rbPlayer.isKinematic = false;
                //is climbing est false
                isClimbing = false;
                //ajout de velocity pour le jump
                rbPlayer.velocity += Vector3.up * jumpForce;
            }
        }
        if (isLedgeClimbing)
        {
            isClimbing = false;
        }
    }

    private void FixedUpdate()
    {
        //calcul de la position en y du joueur par rapport au input y
        offsetY = yInput * Time.deltaTime * climbSpeed;

        //lors de isClimbing, la position du joueur est en x,z la meme chose que le ladder et en y est un offset avec le input vertical
        if (isClimbing)
        {
            //calcul de la position en y du joueur par rapport au input y
            offsetY = yInput * Time.deltaTime;
            //positionnement du joueur
            transform.position = new Vector3(ladderPosition.x + offsetX, transform.position.y + offsetY, ladderPosition.z);
            //desactiver le script player controller
            playerController.enabled = false;
            
            //le player glisse plus rapidement en descendant
            if (yInput < 0)
            {
                transform.position = new Vector3(ladderPosition.x + offsetX, transform.position.y + offsetY * 4, ladderPosition.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder") && isJumping && jumpingOff == false)
        {
            //definir la cible ou positionner le perso
            ladderPosition = other.gameObject.transform.position;
            //rendre kinematic le player sur le ladder
            rbPlayer.isKinematic = true;
            //activer le bool isClimbing
            isClimbing = true;
            //calcul du offset en x
            offsetX = -directionX * 0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            //reactiver le script player controller a la sortie du ladder
            playerController.enabled = true;
            isClimbing = false;
            rbPlayer.isKinematic = false;
        }
        
    }
}
