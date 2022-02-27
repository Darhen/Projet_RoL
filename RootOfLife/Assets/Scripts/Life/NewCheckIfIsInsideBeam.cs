using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(MeshRenderer))]
public class NewCheckIfIsInsideBeam : MonoBehaviour
{
    bool isInsideBeam = false;
   /* Material m_Material = null;*/
    Collider m_Collider = null;

    public Color colorIni = Color.green;
    public Color colorFin = Color.red;
    public float durationDown = 15f;
    public float durationUp = 10f;
    Color lerpedColor = Color.green;

    private float t = 0;
   /* private bool flag;*/

    Renderer _renderer;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();

        /* var meshRenderer = GetComponent<MeshRenderer>();
         if (meshRenderer)
             m_Material = meshRenderer.material;
         Debug.Assert(m_Material);*/
    }
    /*
    void Update()
    {
        if (m_Material)
        {
            m_Material.SetColor("_Color", isInsideBeam ? Color.green : Color.red);
        }
    }*/

    void FixedUpdate()
    {
        isInsideBeam = false;
    }

    void OnTriggerStay(Collider trigger)
    {
        var dynamicOcclusion = trigger.GetComponent<VLB.DynamicOcclusionRaycasting>();

        if (dynamicOcclusion)
        {
            // This GameObject is inside the beam's TriggerZone.
            // Make sure it's not hidden by an occluder
            isInsideBeam = !dynamicOcclusion.IsColliderHiddenByDynamicOccluder(m_Collider);
        }
        else
        {
            isInsideBeam = true;
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        isInsideBeam = false;
    }

    void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, t);
        _renderer.material.color = lerpedColor;

        if (isInsideBeam == true)
        {
            t -= Time.deltaTime / durationUp;
            if (t < 0.01f)
                durationUp = 1000000000f;
        }
        else if (isInsideBeam == false)
        {
            t += Time.deltaTime / durationDown;
            durationUp = 10f;
            /*if (t > 0.99f)
                durationDown = 10000f;*/
        }
      
    }
}
