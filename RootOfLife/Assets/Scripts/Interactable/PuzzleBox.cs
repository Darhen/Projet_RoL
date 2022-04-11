using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    public bool hittingObject;
    private Vector3 previous;
    public float realVelocityBoxX;
    public float frameVelocity;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        realVelocityBoxX = ((transform.position - previous).magnitude )/ Time.deltaTime;
        previous = transform.position;
        
        if(realVelocityBoxX != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        */
    }

    private void FixedUpdate()
    {
        realVelocityBoxX = ((transform.position - previous).magnitude) / Time.deltaTime;
        previous = transform.position;

        if (realVelocityBoxX != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
