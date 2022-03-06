using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{

    public float time = 30.0f;
    public float maxInterval = 1.2f;
    public float minInterval = 0.2f;

    private float interval = 1.0f;
    private float timer = 30.0f;

    void Start()
    {
        timer = time;
    }

    void Update()
    {
        interval = minInterval + timer / time * (maxInterval - minInterval);
        timer -= Time.deltaTime;
        if (timer < 0.0f) timer = 0.0f;
        GetComponent<Renderer>().enabled = Mathf.PingPong(Time.time, interval) > (interval / 2.0f);
    }
}
