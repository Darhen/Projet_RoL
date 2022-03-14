using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDetecteur : MonoBehaviour
{
    public Vector3 rotation1;
    public Vector3 rotation2;
    //public Vector3 actualRotation;
    public float rotationSpeed;
    public bool isRotatingBack;

    void Start()
    {
        //isRotatingBack = false;
        //actualRotation = new Vector3(90, 0, 0);
        //rotation1 = new Vector3(0, 120, 0);
        //rotation2 = new Vector3(0, 60, 0);
        rotationSpeed = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(Mathf.PingPong(rotationSpeed * Time.time, 60.0f), 0, 0);
        /* if (this.gameObject.transform.rotation.x <= rotation1.x && isRotatingBack == false)
        {
            this.gameObject.transform.Rotate(rotation1 * rotationSpeed * Time.deltaTime);
        }

        else if (this.gameObject.transform.rotation.x >= rotation2.x)
        {
            this.gameObject.transform.Rotate(rotation2 * rotationSpeed * Time.deltaTime);
            isRotatingBack = true;
        }

        else
        {
            isRotatingBack = false;
        }*/
    }
}
