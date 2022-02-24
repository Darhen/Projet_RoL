using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    PlayerController playerController;
    public int fallMultiplier;
    public int initialFallMultiplier;
    public bool isGrounded;
    public bool jumQueued;
    public int parachuteMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        initialFallMultiplier = GetComponent<PlayerController>().fallMultiplier;
        playerController = GetComponent<PlayerController>();
        parachuteMultiplier = -4;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GetComponent<PlayerController>().isGrounded;
        jumQueued = GetComponent<PlayerController>().jumpQueued;

        if (jumQueued && !isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                GetComponent<PlayerController>().fallMultiplier = 1;
                //GetComponent<Rigidbody>().mass = 0.5f;
                GetComponent<Rigidbody>().velocity = new Vector3(0, parachuteMultiplier, 0);
            }
            if (Input.GetButtonUp("Jump"))
            {
                GetComponent<PlayerController>().fallMultiplier = initialFallMultiplier;
                //GetComponent<Rigidbody>().mass = 1f;
            }
        }
        else
        {
            GetComponent<PlayerController>().fallMultiplier = initialFallMultiplier;
            //GetComponent<Rigidbody>().mass = 1f;
        }
    }
}
