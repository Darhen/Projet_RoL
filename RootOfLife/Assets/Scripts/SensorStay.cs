using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorStay : MonoBehaviour
{ 

public bool isActive;
public Material activeMat;
public Material notActiveMat;
public Animator porte1Animator;
public Animator porte2Animator;
public GameObject Porte1;
public GameObject Porte2;
private GameObject player;
RespawnMerged respawn;
SensorTrigger sensorTrigger;

private void start()
{
    isActive = false;
    porte1Animator = Porte1.GetComponent<Animator>();
    porte2Animator = Porte2.GetComponent<Animator>();
    player = GameObject.FindWithTag("Player");
    respawn = player.GetComponent<RespawnMerged>();
    sensorTrigger = this.gameObject.GetComponent<SensorTrigger>();
}


    private void Update()
    {
        if (isActive)
        {
            this.gameObject.GetComponent<Renderer>().material = activeMat;
            porte1Animator.SetBool("Activated", true);
            porte2Animator.SetBool("Activated", true);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = notActiveMat;
            porte1Animator.SetBool("Activated", false);
            porte2Animator.SetBool("Activated", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (/*other.CompareTag("FollowMe") || other.CompareTag("OldRoot") ||*/ other.CompareTag("Box"))
        {
            isActive = true;
            Debug.Log("activelight");
        }
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box") /*|| other.CompareTag("FollowMe") || other.CompareTag("OldRoot")*/)
        {
            isActive = true;
        }

        /*else if (!activateWithPlant)
        {
            isActive = false;
            spark.Stop();
            redLight.enabled = true;
            greenLight.enabled = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box")/*|| other.CompareTag("FollowMe") || other.CompareTag("OldRoot")*/)
        {
            isActive = false;
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OUVRETABARNAK");
        if ((other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot")) && !isActive)
        {
            StartCoroutine("SensorPos");
        }  
    }

        private void OnTriggerExit(Collider other)
        {
            if ((other.CompareTag("Player") || other.CompareTag("Box") || other.CompareTag("FollowMe") || other.CompareTag("OldRoot")) && isActive)
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
        yield return new WaitForSeconds(0.01f);
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
