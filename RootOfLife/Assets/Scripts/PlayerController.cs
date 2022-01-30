using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody myRigidbody;

    public float xInput;
    //public float zInput;
    private Vector3 movementVector;
  

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //InputDetection();
        xInput = Input.GetAxis("Horizontal");
        //zInput = Input.GetAxis("Vertical");

        movementVector = new Vector3(xInput, 0, 0);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        myRigidbody.velocity = movementVector * speed;
    }

}
