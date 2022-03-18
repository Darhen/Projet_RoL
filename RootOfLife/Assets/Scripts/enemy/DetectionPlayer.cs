using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DetectionPlayer : MonoBehaviour
{
    public bool playerInside = false;
    public bool playerIsDetected;
    Collider m_Collider = null;
    public Animator animator;

    Animator animatorDrone;
    Animator animatorDetection;
    public GameObject bras;
    public GameObject brasDetector;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        animatorDrone = bras.GetComponent<Animator>();
        animatorDetection = brasDetector.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerInside = false;
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
                playerInside = !dynamicOcclusion.IsColliderHiddenByDynamicOccluder(m_Collider);
            }
            else
            {
                playerInside = true;
            }
        } 
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "DetectionEnnemi")
        {
            playerInside = false;
        }

    }
    void Update()
    {
        if (playerInside)
        {
            playerIsDetected = true;
            animator.Play("WhiteToRed");

        }
        else
        {
            playerIsDetected = false;
            animator.Play("RedToWhite");
        }
    }
}
