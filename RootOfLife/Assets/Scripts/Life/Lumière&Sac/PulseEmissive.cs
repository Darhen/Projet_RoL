using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEmissive : MonoBehaviour
{
    public GameObject Sac;
    public float maxIntensity = 5f;
    public float minIntensity = 0f;
    public float pulseSpeed = 20f; //here, a value of 0.5f would take 2 seconds and a value of 2f would take half a second
    public float targetIntensity = 5f;
    public float emissiveIntensity;

    void Start()
    {
        emissiveIntensity = Sac.GetComponent<CouleurEmmissiveSac>().emissiveIntensity;
    }
    void Update()
    {
        emissiveIntensity = Mathf.MoveTowards(Sac.GetComponent<CouleurEmmissiveSac>().emissiveIntensity, targetIntensity, Time.deltaTime * pulseSpeed);
        if (emissiveIntensity >= maxIntensity)
        {
            emissiveIntensity = maxIntensity;
            targetIntensity = minIntensity;
        }
        else if (emissiveIntensity <= minIntensity)
        {
            emissiveIntensity = minIntensity;
            targetIntensity = maxIntensity;
        }
        Sac.GetComponent<CouleurEmmissiveSac>().emissiveIntensity = emissiveIntensity;

    }
}
