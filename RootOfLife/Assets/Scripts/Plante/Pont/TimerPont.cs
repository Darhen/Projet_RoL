using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPont : MonoBehaviour
{


    public int seconds;

    GrowthManager growthManager;
    GameObject player;

    public Transform lastChild;

    public int currentCap;


    void Awake()
    {
        
        player = GameObject.FindWithTag("Player");
        growthManager = player.GetComponentInChildren<GrowthManager>();
    }

    private void Update()
    {
        currentCap = this.gameObject.transform.childCount;

        if(currentCap >= 1)
        {
            StartCoroutine("Countdown");
        }

        if(currentCap <= 0)
        {
            StopCoroutine("CountDown");
        }
    }

    void DoStuff()
    {
        StartCoroutine("DestroyChildren");
        //Destroy(.gameObject);
        //growthManager.StartCoroutine("DestroyRoots");
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

    IEnumerator DestroyChildren()
    {
        Destroy(transform.GetChild(0).gameObject);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
