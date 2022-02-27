using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientColor : MonoBehaviour
{
    public Color colorIni = Color.green;
    public Color colorFin = Color.red;
    public float duration = 15f;
    Color lerpedColor = Color.green;

    private float t = 0;
    private bool flag;

    Renderer _renderer;
    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(colorIni, colorFin, t);
        _renderer.material.color = lerpedColor;

        if (flag == true)
        {
            t -= Time.deltaTime / duration;
            if (t < 0.01f)
                flag = false;
        }
        else
        {
            t += Time.deltaTime / duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}
