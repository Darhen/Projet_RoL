using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class checkIfIsInsideBeam2_ : MonoBehaviour
{
    bool m_IsInsideBeam = false;
    Collider m_Collider = null;

    [SerializeField] private Material colorMaterial;

    public Renderer colorRenderer;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);

        
        colorRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (m_IsInsideBeam)
        {
            Debug.Log("Ca marche");
            //colorMaterial.color = colorMaterial.SetColor("red",Color.red);
        }
        // Do whatever you want with the m_IsInsideBeam property here
    }

    void FixedUpdate()
    {
        m_IsInsideBeam = false;
    }

    void OnTriggerStay(Collider trigger)
    {
        var dynamicOcclusion = trigger.GetComponent<VLB.DynamicOcclusionRaycasting>();

        if (dynamicOcclusion)
        {
            // This GameObject is inside the beam's TriggerZone.
            // Make sure it's not hidden by an occluder
            m_IsInsideBeam = false;
            //colorMaterial.color = colorMaterial.red;
        }
        else
        {
            m_IsInsideBeam = true;
        }
    }
}
