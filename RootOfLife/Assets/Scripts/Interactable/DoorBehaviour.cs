using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Animator myAnimationController;
    public GameObject Sensor;
    public bool isOpen;



    void Update()
    {
        isOpen = Sensor.GetComponent<SensorTrigger>().isActive;      

        if (isOpen)
        {
            myAnimationController.SetBool("OpenDoor", true);
            myAnimationController.SetBool("CloseDoor", false);
        }
        else
        {

            myAnimationController.SetBool("OpenDoor", false);
            myAnimationController.SetBool("CloseDoor", true);
        }
    }
}
