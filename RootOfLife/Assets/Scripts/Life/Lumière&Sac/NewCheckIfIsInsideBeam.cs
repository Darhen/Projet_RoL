using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;



[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(MeshRenderer))]
public class NewCheckIfIsInsideBeam : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    
    public bool isInsideBeam = false;
    Collider m_Collider = null;

    public Color colorIni;
    public Color colorMid;
    public Color colorFin;
    public float durationDown = 25f;
    public float durationUp = 5f;
    public Color lerpedColor;


    public float variableT = 0;
    public int maxT;
    public int minT;
    public float midT;
    /* private bool flag;*/

    
    Renderer _renderer;

    void Awake()
    {
        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();

        maxT = 1;
        midT = 0.5f;
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
       // isInsideBeam = false;
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
        if (variableT <= midT)
        {
            lerpedColor = Color.Lerp(colorIni, colorMid, variableT / 0.5f);
            _renderer.material.color = lerpedColor;
        }
        if (variableT > midT)
        {
            lerpedColor = Color.Lerp(colorMid, colorFin, (variableT - 0.5f) / 0.5f);
            _renderer.material.color = lerpedColor;
        }


        if (isInsideBeam)
        {
            
            Debug.Log("Coucou");
            if (variableT > minT)
            {
                variableT -= Time.deltaTime / durationUp;
            }
        }
        else if (!isInsideBeam)
        {
            durationUp = 5f;
            variableT += Time.deltaTime / durationDown ;
        }

        if (variableT < 0)
        {
            variableT = minT;
        }



        /*lerpedColor = Color.Lerp(colorIni, colorFin, variableT);
        _renderer.material.color = lerpedColor;

        if (isInsideBeam)
        {
            Debug.Log("Coucou");
            if(variableT > minT)
            {
                variableT -= Time.deltaTime / durationUp;

            }   
        }
        else if (!isInsideBeam)
        {
            variableT += Time.deltaTime / durationDown;
            durationUp = 5f;

        }

        if(variableT < 0)
        {
            variableT = minT;
        }*/
        /*
        //Respawn
        if (variableT >= maxT) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
       {
           StartCoroutine(Respawn());
           //_renderer.material.color = lerpedColor;
       }*/
    }
    /*  
     IEnumerator Respawn()
      {
          //animator.SetTrigger("LightDeath");
          yield return new WaitForSeconds(0.1f);
          variableT = minT;
          yield return new WaitForSeconds(0.1f);
          player.transform.position = respawnPoint.transform.position;
          //fadeOutMenuUI.SetActive(true);
          //Instantiate(player, checkPoint1.position, checkPoint1.rotation);
      }*/
}
