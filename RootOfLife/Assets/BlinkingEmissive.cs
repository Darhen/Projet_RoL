using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEmissive : MonoBehaviour
{

    public GameObject Sac;
    public GameObject Light;
    public float emissiveIntensity;
    Pulse pulse;
    CouleurEmmissiveSac couleurEmissiveSac;

    void Start()
    {
        pulse = Light.GetComponent<Pulse>();
        //couleurEmissiveSac = Sac.GetComponent<CouleurEmmissiveSac>();
       // emissiveIntensity = Sac.GetComponent<CouleurEmmissiveSac>().emissiveIntensity;
        //Light.GetComponent<PulseActivation>().pulseActiv = false;
    }

    void Update()
    {
        //if(Light.GetComponent<PulseActivation>().pulseActiv == true)
        //{
            emissiveIntensity = Light.GetComponent­<Pulse>().currentIntensity;
        //}
        
        //if (Light.GetComponent<PulseActivation>().pulseActiv == false)
        //{
        //    emissiveIntensity = Sac.GetComponent<CouleurEmmissiveSac>().emissiveIntensity;
        //}
       // Sac.GetComponent<CouleurEmmissiveSac>().emissiveIntensity = emissiveIntensity;
    }
}
