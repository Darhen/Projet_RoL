using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{

    public bool isActive;
    public Material activeMat;
    public Material notActiveMat;


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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot"))
        {
            isActive = true;
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot"))
        {
            isActive = false;
        }
    }
}

