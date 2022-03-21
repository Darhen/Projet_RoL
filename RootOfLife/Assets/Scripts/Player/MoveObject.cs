using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool playerIsPushing;
    public bool canPush;
    public bool pushingController;
    public int direction;
    public float offsetX;
    public float xInput;
    public Vector3 playerPosition;
    public Vector3 edgeBox;
    public float speed;
    public Vector3 movementVector;
    private Rigidbody myRigidbody;
    public GameObject otherBox;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = 0.7f;
        playerController = GetComponent<PlayerController>();
        speed = 2f;
        myRigidbody = GetComponent<Rigidbody>();
        otherBox = null;
    }

    // Update is called once per frame
    void Update()
    {
        //position du player selon la box
        playerPosition = GetComponent<Transform>().position;

        //définir le input en x (direction a l'entrée dans le trigger)
        xInput = Input.GetAxis("Horizontal");

        //player controller en push (déplacement)
        movementVector = new Vector3(xInput * speed, myRigidbody.velocity.y, 0);

        //définir si le player utilise le input pour pousser
        if (Input.GetKey(KeyCode.P) || Input.GetButton("Fire3"))
        {
            playerIsPushing = true;
        }
        else
        {
            playerIsPushing = false;
        }

        //définir si le player est entrain de pousser (controller)
        if(canPush && playerIsPushing)
        {
            pushingController = true;
            //le player est placé a une distance fixe du edge de la box lorsqu'il est en is pushing
            //this.transform.position = new Vector3 (edgeBox.x, transform.position.y, transform.position.z) + new Vector3(offsetX * -direction, 0, 0);
            //desactiver le player controller quand on push
            playerController.enabled = false;
        }
        else
        {
            pushingController = false;
        }
        //réactiver le player controller lorsqu'on lâche le bouton push
        if (Input.GetKeyUp(KeyCode.P) || Input.GetButtonUp("Fire3"))
        {
            playerController.enabled = true;
        }
        if(otherBox = null)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        //Controller dédié aux box
        if (pushingController)
        {
            myRigidbody.velocity = movementVector;
            otherBox.transform.parent = this.gameObject.transform;
            otherBox.GetComponent<Rigidbody>().velocity = movementVector;
        }
       /*
        else
        {
            otherBox.transform.parent = null;
        }*/
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        //définir la direction a l,entrée dans le trigger
        if (xInput > 0)
        {
            direction = 1;
        }
        if (xInput < 0)
        {
            direction = -1;
        }

        //définir que le player peut push a l'intérieur du trigger
        if (collision.gameObject.tag == "Box")
        {
            canPush = true;
            edgeBox = collision.gameObject.transform.position;
            otherBox = collision.gameObject;
        }
    }
    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            canPush = true;
            edgeBox = collision.gameObject.transform.position;

        }
    }

}
