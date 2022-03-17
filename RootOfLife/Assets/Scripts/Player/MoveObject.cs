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
    public Vector3 playerPosition;
    public Vector3 edgeBox;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        //position du player selon la box
        playerPosition = GetComponent<Transform>().position;

        //définir le input en x (direction a l'entrée dans le trigger)
        if(Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        }

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
            this.transform.position = new Vector3 (edgeBox.x, transform.position.y, transform.position.z) + new Vector3(offsetX * -direction, 0, 0);
        }

    }

    private void FixedUpdate()
    {
        //Controller dédié aux box
        if (pushingController)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            canPush = true;
            edgeBox = other.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            canPush = false;
        }
    }
}
