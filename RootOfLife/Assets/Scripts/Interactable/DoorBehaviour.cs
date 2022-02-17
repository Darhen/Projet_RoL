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
            myAnimationController.SetBool("DoorSlide", true);
            myAnimationController.SetBool("ClosingDoor", false);
        }
        else
        {
            myAnimationController.SetBool("DoorSlide", false);
            myAnimationController.SetBool("ClosingDoor", true);
        }
    }
}
