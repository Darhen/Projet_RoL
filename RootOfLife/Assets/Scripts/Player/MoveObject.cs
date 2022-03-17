using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool playerIsPushing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.P) || Input.GetButton("Fire3"))
        {
            playerIsPushing = true;
        }
        else
        {
            playerIsPushing = false;
        }



    }
}
