using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPont : MonoBehaviour
{

    Color currentColor;
    MeshRenderer myRenderer;

    public Color startColor, endColor;
    public float colorChangeTime;
    public int seconds;


    void Awake()
    {
        StartCoroutine("Countdown");
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = startColor;
        currentColor = startColor;
        colorChangeTime = 0.0035f;
    }

    private void FixedUpdate()
    {
        if (currentColor == startColor)
        {
            currentColor = endColor;
        }
        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentColor, colorChangeTime);
    }

    void DoStuff()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Countdown()
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        DoStuff();
    }
}
