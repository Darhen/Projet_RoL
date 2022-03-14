using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMouvement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Transform targetPosition;
    public Transform initialPosition;
    public bool isGoingBack;
    public Vector3 initialRotation;
    public Vector3 targetRotation;



    void Start()
    {
        speed = 0.5f;
        isGoingBack = false;
        rotationSpeed = 0.25f;
        initialRotation = new Vector3(0, 0, 0);
        targetRotation = new Vector3 (0, 180, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x > targetPosition.position.x && isGoingBack == false)
        {
            this.gameObject.transform.Translate(-speed, 0, 0);
        }

        else if(this.gameObject.transform.position.x <= initialPosition.position.x)
        {
            this.gameObject.transform.Translate(speed, 0, 0);
            isGoingBack = true;

        }
        else
        {
            isGoingBack = false;
        }


        if (this.gameObject.transform.position.x >= initialPosition.position.x)
        {
            speed = 0f;
            this.gameObject.transform.Rotate(targetRotation * -rotationSpeed * Time.deltaTime);
            //this.gameObject.transform.rotation = Quaternion.Lerp(targetRotation, initialRotation, rotationSpeed * Time.deltaTime);
            //this.gameObject.transform.Rotate(new Vector3(0, 0, 0), rotationSpeed * Time.deltaTime,Space.World);
            //this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), rotationSpeed * Time.deltaTime);

            if (this.gameObject.transform.localEulerAngles.y <= 0f)
            {
                rotationSpeed = 0f;
                speed = 0.5f;
            }
            
        }

        else if (this.gameObject.transform.position.x <= targetPosition.position.x)
        {
            speed = 0f;
            this.gameObject.transform.Rotate(targetRotation * rotationSpeed * Time.deltaTime);
            //this.gameObject.transform.rotation = Quaternion.Euler(targetRotation) * rotationSpeed * Time.deltaTime);
            //this.gameObject.transform.Rotate(new Vector3(0, 180, 0), rotationSpeed * Time.deltaTime, Space.World);
            //this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), rotationSpeed * Time.deltaTime);

            if (this.gameObject.transform.localEulerAngles.y >= 180f)
            {
                rotationSpeed = 0f;
                speed = -0.5f;
                
            }  
            
        }

    }

}
