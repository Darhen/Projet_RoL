using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public Animator myAnimationController;
    public GameObject Sensor;
    public bool isOpen;



    void Update()
    {
        isOpen = Sensor.GetComponent<SensorTrigger>().isActive;

        if (isOpen)
        {
            myAnimationController.SetBool("OpenTrap", true);
            myAnimationController.SetBool("CloseTrap", false);
        }
        else
        {

            myAnimationController.SetBool("OpenTrap", false);
            myAnimationController.SetBool("CloseTrap", true);
        }
    }
}
