using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorOnOff : MonoBehaviour
{

    public bool isActive;
    public Material activeMat;
    public Material notActiveMat;

    void start()
    {
        isActive = false; 
    }

    private void Update()
    {
        if (isActive)
        {
            this.gameObject.GetComponent<Renderer>().material = activeMat;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = notActiveMat;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || /*other.CompareTag("Box") ||*/ other.CompareTag("FollowMe") || other.CompareTag("OldRoot")) && isActive == false)
        {
            isActive = true;
        }

        if((other.CompareTag("Player") || /*other.CompareTag("Box") ||*/ other.CompareTag("FollowMe") || other.CompareTag("OldRoot")) && isActive == true)
        {
            isActive = false;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot"))
        {
            isActive = false;
        }
    }*/
}
