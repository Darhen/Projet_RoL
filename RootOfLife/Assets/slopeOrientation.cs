using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slopeOrientation : MonoBehaviour
{
    
    public bool slidingLeft;
    public bool slidingRight;
    SlopeDetector slopeDetector;

    private void Start()
    {
        slopeDetector = GameObject.FindWithTag("Player").GetComponent<SlopeDetector>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slopeDetector.sliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slopeDetector.sliding = false;
        }
    }
    private void Update()
    {/*
        if (slidingLeft)
        {
            slopeDetector.direction = -1;
        }

        if (slidingRight)
        {
            slopeDetector.direction = 1;
        }*/
    }
}

