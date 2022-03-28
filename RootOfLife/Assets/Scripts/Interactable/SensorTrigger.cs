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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FollowMe") || other.CompareTag("OldRoot"))
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
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (!activateWithPlant && other.CompareTag("Player") || !activateWithPlant && other.CompareTag("Box") /*|| other.CompareTag("FollowMe") || other.CompareTag("OldRoot")*/)
        {
            isActive = false;
        }
    }
}

