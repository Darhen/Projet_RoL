using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouleurEmmissiveSac : MonoBehaviour
{
    public Material EmissiveMaterial;
    public GameObject Sac;
    public GameObject Sphere;
    public float emissiveIntensity;
    public Color emissiveColor;

    void Start()
    {
        emissiveIntensity = 4f;
        EmissiveMaterial = Sac.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        emissiveColor = Sphere.GetComponent<NewCheckIfIsInsideBeam>().lerpedColor;
        EmissiveMaterial.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
    }
}
