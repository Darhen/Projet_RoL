using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPontSafe : MonoBehaviour
{

    Color currentColor;
    MeshRenderer myRenderer;

    public Color startColor, endColor;
    public float colorChangeTime;

    public int seconds;
    public int counter;

    GameObject TrampolineParent;
    TrampolineManager trampo;

    void Awake()
    {
        StartCoroutine("Countdown");
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = startColor;
        currentColor = startColor;
        colorChangeTime = 1;
        TrampolineParent = GameObject.Find("TrampolineParent");
        trampo = TrampolineParent.GetComponent<TrampolineManager>();

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
        trampo.StartCoroutine("DestroyChildren");
    }

    IEnumerator Countdown()
    {
        counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        DoStuff();
    }
}
