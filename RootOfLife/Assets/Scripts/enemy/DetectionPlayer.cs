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
            animator.Play("WhiteToRed");

            /* Vector3 direction = sphere.position - transform.position;
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
             transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);*/

            //robot.transform.rotation = Quaternion.Euler(new Vector3(0, sphere.transform.rotation.y, 0));
        }
        else
        {
            playerIsDetected = false;
            animator.Play("RedToWhite");
        }
    }
}
