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
    public float durationDown = 40f;
    public float durationUp = 5f;
    public Color lerpedColor;


    public float variableT = 0;
    public int maxT;
    public int minT;
    public float midT;
    
    Renderer _renderer;

    //SON LIGHT
    public AK.Wwise.Event Recharge;
    public AK.Wwise.Event GreenLight;
    public AK.Wwise.Event YellowLight;
    public AK.Wwise.Event RedLight;

    public bool greenPlayed;
    public bool yellowPlayed;
    public bool redPlayed;


    void Awake()
    {
        m_Collider = GetComponent<CapsuleCollider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();
        Physics.IgnoreLayerCollision(0, 9);
        Physics.IgnoreLayerCollision(6, 9);
        Physics.IgnoreLayerCollision(10, 9);

        maxT = 1;
        midT = 0.5f;
        minT = 0;

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

        if (!trigger.CompareTag("LumiereVolu"))
        {
            isInsideBeam = false;
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
                Recharge.Post(gameObject);
            }
        }
        else if (!isInsideBeam)
        {
            durationUp = 5f;
            variableT += Time.deltaTime / durationDown;
        }

        if (variableT < 0)
        {
            variableT = minT;
        }


        //SON VIE DE LA PLANTE

        if (variableT <= 0.20f)
        {
            if (!greenPlayed)
            {
                GreenLight.Post(gameObject);
                Debug.Log(GreenLight);
                greenPlayed = true;
            }
        }

        if (variableT >= 0.45f)
        {
            if(!yellowPlayed)
            {
                YellowLight.Post(gameObject);
                Debug.Log(YellowLight);
                yellowPlayed = true;
                greenPlayed = false;
                redPlayed = false;
            }
        }

        if (variableT >= 0.70f)
        {
            if(!redPlayed)
            {
                RedLight.Post(gameObject);
                Debug.Log(RedLight);
                redPlayed = true;
                yellowPlayed = false;
            }
        }
    }

}
