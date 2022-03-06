using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public GameObject Sphere;
    public Color SphereColor;
    public Light light;



    private void Start()
    {
        light = GetComponent<Light>();
        
    }

    private void Update()
    {
        SphereColor = Sphere.GetComponent<NewCheckIfIsInsideBeam>().lerpedColor;
        light.color = SphereColor;

    }

}