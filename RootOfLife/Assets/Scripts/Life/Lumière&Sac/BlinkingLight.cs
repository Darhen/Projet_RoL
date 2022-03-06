using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public GameObject Sphere;
    public Color SphereColor;
    public Light spotLight;



    private void Start()
    {
        spotLight = GetComponent<Light>();
        
    }

    private void Update()
    {
        SphereColor = Sphere.GetComponent<NewCheckIfIsInsideBeam>().lerpedColor;
        spotLight.color = SphereColor;

    }

}