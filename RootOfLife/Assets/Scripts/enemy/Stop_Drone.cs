using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Drone : MonoBehaviour
{
    Animator animatorDrone;
    public GameObject drone;
    public bool amDead = false;

    void Start()
    {
        animatorDrone = drone.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            
            amDead = true;
            StartCoroutine(StopDrone());
        }
        
    }

    IEnumerator StopDrone()
    {
        yield return new WaitForSeconds(3f);
        amDead = false;
       
    }
}
