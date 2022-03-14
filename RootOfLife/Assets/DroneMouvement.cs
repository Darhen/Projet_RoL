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
        speed = 0.1f;
        isGoingBack = false;
        rotationSpeed = 0.25f;
        initialRotation = new Vector3(0, 0, 0);
        targetRotation = new Vector3 (0, 180, 0);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x > targetPosition.position.x && isGoingBack == false)
        {
            this.gameObject.transform.Translate(-speed, 0, 0);

            if (this.gameObject.transform.position.x <= targetPosition.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                /*
                speed = 0f;
                this.gameObject.transform.Rotate(targetRotation * rotationSpeed * Time.deltaTime);

                if (this.gameObject.transform.localEulerAngles.y >= 180f)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                    rotationSpeed = 0f;
                    speed = -0.25f;
                }*/

            }
        }

        else if (this.gameObject.transform.position.x <= initialPosition.position.x)
        {
            this.gameObject.transform.Translate(-speed, 0, 0);
            isGoingBack = true;

            if (this.gameObject.transform.position.x >= initialPosition.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
                /*
                  speed = 0f;
                  this.gameObject.transform.Rotate(targetRotation * rotationSpeed * Time.deltaTime);

                  if (this.gameObject.transform.localEulerAngles.y <= 0f)
                  {
                      transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
                      rotationSpeed = 0f;
                      Debug.Log("Allo");
                      speed = -0.25f;
                  }*/
            }
        }

        else
        {
            isGoingBack = false;
        }


    }
    /* private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.tag == "DronePos")
         {
             this.gameObject.transform.position = initialPosition.position;
         }
     }*/

}
