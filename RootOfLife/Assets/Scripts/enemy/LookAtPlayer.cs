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
            /*Vector3 directionToFace = sphere.position - this.transform.position;
            transform.rotation = Quaternion.LookRotation(directionToFace);*/

            /*originPoint.rotation = Quaternion.LookRotation(sphere.position, Vector3.forward);
            Debug.DrawLine(originPoint.position, originPoint.position + originPoint.forward * 15, Color.blue);
            Debug.DrawLine(originPoint.position, originPoint.position + originPoint.up * 15, Color.green);*/

            //transform.rotation = Quaternion.Euler(new Vector3(0, sphere.transform.position.y, 0));

            /*var lookPos = sphere.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);*/

            transform.LookAt(sphere);
        }
        else
        {
            
        }
    }
}
