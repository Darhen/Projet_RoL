using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool PlayerDetected;
    public Transform sphere;

    DetectionPlayer detectionPlayer;

    void Start()
    {
        detectionPlayer = sphere.GetComponent<DetectionPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetected = detectionPlayer.playerIsDetected;

        if (PlayerDetected)
        {
            StartCoroutine("PlayerDetection");
        }
        else
        {
            StopCoroutine("PlayerDetection");
        }
    }

    IEnumerator PlayerDetection()
    {
        yield return new WaitForSeconds(0.75f);
        transform.LookAt(sphere);
        yield return new WaitForSeconds(1f);
    }
}
