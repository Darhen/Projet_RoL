using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontBehaviour : MonoBehaviour
{
  
    public Animator myAnimationController;
    public GameObject Sensor;
    public bool isOpen;

    void Update()
    {
        isOpen = Sensor.GetComponent<SensorTrigger>().isActive;

        if (isOpen)
        {
            myAnimationController.SetBool("PontSlide", true);
            myAnimationController.SetBool("PontClosing", false);
        }
        else
        {
            myAnimationController.SetBool("PontSlide", false);
            myAnimationController.SetBool("PontClosing", true);
        }
    }
}
