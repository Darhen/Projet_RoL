using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{

    public bool isActive;
    public Material activeMat;
    public Material notActiveMat;
    public ParticleSystem spark;
    public Light redLight;
    public Light greenLight;
    public bool uniqueActif;

    //bool a cocher si on veut que ce trigger fonctionne avec la plante
    public bool activateWithPlant;

    private void Update()
    {
        if (isActive)
        {
            this.gameObject.GetComponent<Renderer>().material = activeMat;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = notActiveMat;
            redLight.enabled = true;
            greenLight.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FollowMe") || other.CompareTag("OldRoot") || other.CompareTag("Box"))
        {
            isActive = true;
            spark.Play();
            redLight.enabled = false;
            greenLight.enabled = true;
            Debug.Log("activelight");
        }
        if(other.CompareTag("Player"))
        {
            isActive = true;
            spark.Play();
            redLight.enabled = false;
            greenLight.enabled = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (!activateWithPlant && other.CompareTag("Player") || !activateWithPlant && other.CompareTag("Box") /*|| other.CompareTag("FollowMe") || other.CompareTag("OldRoot")*/)
        {
            isActive = true;
            spark.Play();
            redLight.enabled = false;
            greenLight.enabled = true;
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
        if (!activateWithPlant && other.CompareTag("Player") && !uniqueActif || !activateWithPlant && other.CompareTag("Box") && !uniqueActif/*|| other.CompareTag("FollowMe") || other.CompareTag("OldRoot")*/)
        {
            isActive = false;
        }
    }
}

