using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool playerIsPushing;
    public bool canPush;
    public bool pushingController;
    public int direction;
    public Vector3 edgeBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //d�finir le input en x (direction a l'entr�e dans le trigger)
        if(Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        }

        //d�finir si le player utilise le input pour pousser
        if (Input.GetKey(KeyCode.P) || Input.GetButton("Fire3"))
        {
            playerIsPushing = true;
        }
        else
        {
            playerIsPushing = false;
        }

        //d�finir si le player est entrain de pousser (controller)
        if(canPush && playerIsPushing)
        {
            pushingController = true;
        }

    }

    private void FixedUpdate()
    {
        //Controller d�di� aux box
        if (pushingController)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "box")
        {
            canPush = true;
            edgeBox = other.gameObject.transform.position;
        }
        else
        {
            canPush = false;
        }
    }
}
