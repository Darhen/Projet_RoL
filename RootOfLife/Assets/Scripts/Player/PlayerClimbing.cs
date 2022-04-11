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
    public Transform model;
    

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
        //isGrounded = playerController.isGrounded;
        isLedgeClimbing = ledgeClimb.isLedgeClimbing;


        //calcul des inputs
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
        

        //permettre la collision avec le ladder une fois grounded apres un jump
        if(isGrounded)
        {
            jumpingOff = false;
        }

        //activer jump
        if (isClimbing)
        {
            /*
            if (isGrounded && yInput < 0)
            {
                playerController.enabled = true;
                isClimbing = false;
                //enlever kinematic
                rbPlayer.isKinematic = false;
            }
            */
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
                //reactiver le player controller
                playerController.enabled = true;
            }
        }
        /*
        if(!isClimbing)
        {
            //calcul direction seulement lorsque le player ne climb pas
            if (xInput > 0)
            {
                directionX = 1;
            }
            if (xInput < 0)
            {
                directionX = -1;
            }
        }
        */
        if (isLedgeClimbing)
        {
            isClimbing = false;
        }
    }

    private void FixedUpdate()
    {
        //lors de isClimbing, la position du joueur est en x,z la meme chose que le ladder et en y est un offset avec le input vertical
        if (isClimbing)
        {
            //calcul de la position en y du joueur par rapport au input y
            offsetY = yInput * Time.deltaTime;

            //positionnement du joueur
            //transform.position = new Vector3(ladderPosition.x + offsetX, transform.position.y + offsetY, ladderPosition.z);
            transform.position = new Vector3 (ladderPosition.x + offsetX, transform.position.y, transform.position.z);
            
            //this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * Time.deltaTime * 2);

            if (yInput > 0)
            {
                rbPlayer.isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, yInput * Time.deltaTime * 100, 0);
            }

            if (yInput < 0)
            {
                rbPlayer.isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, yInput * Time.deltaTime * 200, 0);
            }

            if (yInput == 0)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                rbPlayer.isKinematic = true;
            }

            //desactiver le script player controller
            playerController.enabled = false;
            /*
            //le player glisse plus rapidement en descendant
            if (yInput < 0)
            {
                transform.position = new Vector3(ladderPosition.x + offsetX, transform.position.y + offsetY * 4, ladderPosition.z);
            }
            */
            /*
        if (yInput == 0)
            {
                rbPlayer.isKinematic = true;
            }
        if (yInput != 0)
            {
                rbPlayer.isKinematic = false;
            }
            */
        }
       


    }

    private void OnTriggerEnter(Collider other)
    {
        /*
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
            //desactiver le script player controller
            playerController.enabled = false;
        }
        */
        if (other.gameObject.CompareTag("Ladder") && isJumping && jumpingOff == false)
        {
            /*
            //definir la cible ou positionner le perso
            ladderPosition = other.gameObject.transform.position;
            //rendre kinematic le player sur le ladder
            //rbPlayer.isKinematic = true;
            //activer le bool isClimbing
            isClimbing = true;
            //calcul du offset en x
            offsetX = -directionX * 0.5f;
            //desactiver le script player controller
            playerController.enabled = false;
            */
            directionX = other.GetComponent<LadderPrefabScript>().ladderDirection;
            LadderClimb();
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Ladder") && jumpingOff == false)
        {
            //Le player peut monter dans un ladder en etant grounded
            if (isGrounded && yInput > 0)
            {
                //definir la cible ou positionner le perso
                ladderPosition = other.gameObject.transform.position;
                directionX = other.GetComponent<LadderPrefabScript>().ladderDirection;
                //fonction Ladder
                LadderClimb();
            }

            if (isGrounded && yInput < 0 && other.gameObject.CompareTag("Ledge"))
            {
                //definir la cible ou positionner le perso
                ladderPosition = other.gameObject.transform.position;
                directionX = other.GetComponent<LadderPrefabScript>().ladderDirection;
                //fonction Ladder
                LadderClimb();
            }

            if (isClimbing && yInput == 0)
            {
                //definir la cible ou positionner le perso
                ladderPosition = other.gameObject.transform.position;
                directionX = other.GetComponent<LadderPrefabScript>().ladderDirection;
                //fonction Ladder
                LadderClimb();
            }

            if (isClimbing && isGrounded && yInput < 0)
            {
                StopLadderClimb();
            }
            if (isLedgeClimbing)
            {
                StopLadderClimb();
            }
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        //Check Ground
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    private void LadderClimb()
    {
        //rendre kinematic le player sur le ladder
        isClimbing = true;
        //tourner le player avatar dans la bonne direction
        Quaternion turnModel = Quaternion.LookRotation(new Vector3(-directionX, 0, 0));
        model.rotation = turnModel;
        //calcul du offset en x
        offsetX = directionX * 0.5f;
        //desactiver le script player controller
        playerController.enabled = false;
    }

    private void StopLadderClimb()
    {
        //rendre kinematic le player sur le ladder
        isClimbing = false;
        //desactiver le script player controller
        playerController.enabled = true;
    }
}
