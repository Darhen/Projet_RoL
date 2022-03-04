using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(MeshRenderer))]
public class NewCheckIfIsInsideBeam : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    bool isInsideBeam = false;
   /* Material m_Material = null;*/
    Collider m_Collider = null;

    public Color colorIni = Color.green;
    public Color colorFin = Color.red;
    public float durationDown = 15f;
    public float durationUp = 10f;
    Color lerpedColor = Color.green;


    public float t = 0;
    public int maxT;
    public int minT;
   /* private bool flag;*/

    Renderer _renderer;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();

        maxT = 1;
        minT = 0;

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

        if (isInsideBeam)
        {
            if(t > minT)
            {
                t -= Time.deltaTime / durationUp;

            }   
        }
        else if (!isInsideBeam)
        {
            t += Time.deltaTime / durationDown;
            durationUp = 10f;

        }

        if(t < 0)
        {
            t = minT;
        }

        //Respawn
        if (t >= maxT) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
        {
           StartCoroutine(Respawn());
           //_renderer.material.color = lerpedColor;
        }
    }
    
    IEnumerator Respawn()
    {
        //animator.SetTrigger("LightDeath");
        yield return new WaitForSeconds(0.1f);
        t = minT;
        yield return new WaitForSeconds(0.1f);
        player.transform.position = respawnPoint.transform.position;
        //fadeOutMenuUI.SetActive(true);
        //Instantiate(player, checkPoint1.position, checkPoint1.rotation);
    }
}
