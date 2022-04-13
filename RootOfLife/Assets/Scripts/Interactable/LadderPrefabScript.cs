using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPrefabScript : MonoBehaviour
{
    public bool facingLeft;
    public bool facingRight;
    public int ladderDirection;
    public PlayerClimbing playerClimbing;


    // Start is called before the first frame update
    void Start()
    {
        //definir la direction du ladder
        if (facingLeft)
        {
            ladderDirection = 1;
        }
        if (facingRight)
        {
            ladderDirection = -1;
        }

        //assigner le script ladderClimb du player
        playerClimbing = GameObject.FindWithTag("Player").GetComponent<PlayerClimbing>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    private void OnTriggerStay(Collider other)
    {
        //si le ladder prefab detecte le player, indiquer au script ladderClimb playerCanClimb
        if (other.gameObject.tag == "Player")
        {
            playerClimbing.playerCanClimb = true;
            playerClimbing.ladderPosition.x = transform.position.x;
            playerClimbing.directionX = ladderDirection;
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        //si le ladder prefab detecte le player, indiquer au script ladderClimb playerCanClimb
        if (other.gameObject.tag == "Player")
        {
            playerClimbing.playerCanClimb = true;
            playerClimbing.ladderPosition.x = transform.position.x;
            playerClimbing.directionX = ladderDirection;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerClimbing.playerCanClimb = false;
        }
    }
}
