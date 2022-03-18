using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool PlayerDetected;
    public Transform sphere;
    public int speed = 10;
    

    //public Transform originPoint;
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
            PlayerDetected = false;
            StopCoroutine("PlayerDetection");
        }
    }
    IEnumerator PlayerDetection()
    {
        yield return new WaitForSeconds(0.75f);
        transform.LookAt(sphere);
        yield return new WaitForSeconds(8f);
    }
}
