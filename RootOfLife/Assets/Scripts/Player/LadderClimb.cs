using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public bool playerCanClimb;
    public bool isJumping;
    public bool climbing;

    private float xInput;
    private float yInput;
    private float offsetX;

    public int directionX;

    public Vector3 ladderPosition;

    PlayerController playerController;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //ASSIGNER LES VARIABLES ET SCRIPTS AU START
        playerController = GetComponent<PlayerController>();
        rbPlayer = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        //CALCUL DES VARIABLES
        //calcul des inputs
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");

        //update des bool
        isJumping = playerController.isJumping;

        //definir si le player peut climb
        if (playerCanClimb)
        {
            offsetX = directionX * 0.5f;

            if (yInput > 0)
            {
                StartCoroutine("LadderClimbing");
            }
            else if (isJumping)
            {
                StartCoroutine("LadderClimbing");
            }
        }
    }

    private void FixedUpdate()
    {
       if (climbing)
        {
            if (yInput == 0)
            {
                rbPlayer.isKinematic = true;
            }
            if (yInput > 0)
            {
                rbPlayer.isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, yInput * Time.deltaTime * 80, 0);
                Debug.Log("Monte dans le ladder");
            }
            if (yInput < 0)
            {
                rbPlayer.isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, yInput * Time.deltaTime * 200, 0);
                Debug.Log("Descend dans le ladder");
            }
            if (!playerCanClimb)
            {
                climbing = false;
                playerController.enabled = true;
                Debug.Log("Debarque du ladder");
            }
        }
    }

    private void LadderClimbing()
    {
        climbing = true;
        playerController.enabled = false;
        transform.position = new Vector3(ladderPosition.x + offsetX, transform.position.y, transform.position.z);
        Debug.Log("LadderClimb");
    }
}


