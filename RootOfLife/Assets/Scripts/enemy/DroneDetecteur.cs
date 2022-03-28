using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(MeshRenderer))]
public class DroneDetecteur : MonoBehaviour
{
    public bool isInsideDroneBeam = false;
    Collider m_Collider = null;
    Renderer _renderer;
    Animator animatorDrone;
    Animator animatorDetection;
    public GameObject drone;
    public GameObject droneDetector;
    public GameObject player;
    PlayerController playerController;
    RespawnMerged respawn;
    public bool playerDetected = false;
    private Stop_Drone stop_drone;


    void Start()
    {
        //drone = GameObject.FindWithTag("EnnemiDrone");
        //droneDetector = GameObject.FindWithTag("DetectionEnnemi");
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();

        respawn = player.GetComponent<RespawnMerged>();
        playerController = player.GetComponent<PlayerController>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DetectionEnnemi")
        {
            drone = other.GetComponentInParent<Stop_Drone>().gameObject;
            droneDetector = drone.GetComponentInChildren<DroneAttaque>().gameObject;
            animatorDetection = droneDetector.GetComponent<Animator>();
            animatorDrone = drone.GetComponent<Animator>();
            stop_drone = drone.GetComponent<Stop_Drone>();
        }
        
        //drone;
    }
    
    void OnTriggerStay(Collider trigger)
    {
        var dynamicOcclusion = trigger.GetComponent<VLB.DynamicOcclusionRaycasting>();

        if (trigger.gameObject.tag == "DetectionEnnemi")
        {
            if (dynamicOcclusion)
            {
                // This GameObject is inside the beam's TriggerZone.
                // Make sure it's not hidden by an occluder
                isInsideDroneBeam = !dynamicOcclusion.IsColliderHiddenByDynamicOccluder(m_Collider);
                droneDetector.GetComponent<DroneAttaque>().PlayerIsDetected = isInsideDroneBeam;
            }
            else
            {
                isInsideDroneBeam = true;
                droneDetector.GetComponent<DroneAttaque>().PlayerIsDetected = isInsideDroneBeam;
            }
        }
        
    }

    
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "DetectionEnnemi")
        {
            isInsideDroneBeam = false;
            droneDetector.GetComponent<DroneAttaque>().PlayerIsDetected = isInsideDroneBeam;
        }
            
    }

    void Update()
    {

        if (isInsideDroneBeam || stop_drone.amDead == true)
        {
            playerController.speed = 7.5f;
            playerDetected = true;
            if (animatorDrone != null) animatorDrone.enabled = false;
            if (animatorDetection != null) animatorDetection.Play("WhiteToRed");
        }
        else
        {
            if (respawn.isDying == true)
            {
                isInsideDroneBeam = false;
            }

            playerController.speed = 10f;
            playerDetected = false;
            if(animatorDrone != null)animatorDrone.enabled = true;
            if(animatorDetection != null)animatorDetection.Play("RedToWhite");
        }

        

    }



}
