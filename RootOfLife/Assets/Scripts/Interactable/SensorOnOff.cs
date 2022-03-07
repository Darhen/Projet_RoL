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
        Debug.Log("OUVRETABARNAK");
        if ((other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot"))  && !isActive)
        {
            StartCoroutine("SensorPos");
        }

        if((other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot")) && isActive)
        {
            StartCoroutine("SensorNeg");
        }

    }

    IEnumerator SensorPos()
    {
        yield return new WaitForSeconds(0.1f);
        isActive = true;
    }

    IEnumerator SensorNeg()
    {
        yield return new WaitForSeconds(0.1f);
        isActive = false;
    }
    /* private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot"))
         {
             isActive = false;
         }
     }*/
}
