using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public GameObject player;
    public bool onLadder;
    public bool playerPresent;
    
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          if (player != null && !onLadder)
            {
                playerPresent = true;
            }

        }
    }

    private void Update()
    {
        if (playerPresent && Input.GetKeyDown(KeyCode.E))
        {
           
        }
    }

    private void OnLadder()
    {
        
    }

}


