using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public Animator myAnimationController;
    public GameObject Sensor;
    public bool isOpen;
    SensorOnOff sensorOnOff; 

    //void Start()
    /*{
        sensorOnOff = Sensor.GetComponent<SensorOnOff>();
    }*/

    void Update()
    {
        isOpen = Sensor.GetComponent<SensorOnOff>().isActive;
        /*isOpen = sensorOnOff.isActive;*/

        if (isOpen)
        {
            myAnimationController.SetBool("TrapSlide", true);
            myAnimationController.SetBool("TrapClose", false);
        }
        else
        {

            myAnimationController.SetBool("TrapSlide", false);
            myAnimationController.SetBool("TrapClose", true);
        }
    }
}
