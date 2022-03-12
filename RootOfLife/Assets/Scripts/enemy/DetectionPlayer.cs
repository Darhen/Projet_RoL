using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DetectionPlayer : MonoBehaviour
{
    public bool playerInside = false;
    public bool playerIsDetected;
    Collider m_Collider = null;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);

    }

    void FixedUpdate()
    {
        playerInside = false;
    }

    void OnTriggerStay(Collider trigger)
    {
        var dynamicOcclusion = trigger.GetComponent<VLB.DynamicOcclusionRaycasting>();

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

    void Update()
    {
        if (playerInside)
        {
            playerIsDetected = true;
        }
        else
        {
            playerIsDetected = false;
        }
    }
}
