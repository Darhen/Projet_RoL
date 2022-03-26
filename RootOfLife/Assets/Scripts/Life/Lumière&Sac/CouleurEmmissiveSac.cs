using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouleurEmmissiveSac : MonoBehaviour
{
    public Material EmissiveMaterial;
    //public GameObject Sac;
    private GameObject sphere;
    public float emissiveIntensity;
    public Color emissiveColor;

    void Start()
    {
        sphere = GameObject.Find("Sphere");
        emissiveIntensity = 4f;
        EmissiveMaterial = this.gameObject.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        emissiveColor = sphere.GetComponent<NewCheckIfIsInsideBeam>().lerpedColor;
        EmissiveMaterial.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
    }
}
