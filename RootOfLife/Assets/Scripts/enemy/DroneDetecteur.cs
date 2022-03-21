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
    public bool playerDetected = false;
    RespawnMerged respawn;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();
        animatorDrone = drone.GetComponent<Animator>();
        animatorDetection = droneDetector.GetComponent<Animator>();
        respawn = player.GetComponent<RespawnMerged>();
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
            }
            else
            {
                isInsideDroneBeam = true;
            }
        }
        
    }

    
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "DetectionEnnemi")
        {
            isInsideDroneBeam = false;
            
        }
            
    }

    void Update()
    {
        if (isInsideDroneBeam)
        {
            playerDetected = true;
            animatorDrone.enabled = false;
            animatorDetection.Play("WhiteToRed");
        }
        else
        {
            playerDetected = false;
            animatorDrone.enabled = true;
            animatorDetection.Play("RedToWhite");
        }

    }


}
