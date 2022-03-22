using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttaque : MonoBehaviour
{

    public GameObject sphere;
    public GameObject projectile;
    public Transform spherePosition;
    DroneDetecteur droneDetecteur;
    public bool isInsideDroneBeam;
    public bool PlayerIsDetected;
    private float elapsed;

    public float timeBtwShots;
    public float startTimeBtwShots;

    public bool isCreated;

    void Start()
    {
        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        isCreated = false;
    }


    void Update()
    {
        PlayerIsDetected = droneDetecteur.playerDetected;
        

        if (PlayerIsDetected)
        {
            StartCoroutine(LookAtPlayer());
            StartCoroutine(ShootPlayer());
        }
        else if (!PlayerIsDetected)
        {
            StopCoroutine(ShootPlayer());
            isCreated = false;
        }
        
    }

    IEnumerator LookAtPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(spherePosition);
    }
    IEnumerator ShootPlayer()
    {
        elapsed = 0;
        while(elapsed < 3f)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        if (!isCreated && PlayerIsDetected)
        {
            Instantiate(projectile, transform.position, this.gameObject.transform.rotation);
            isCreated = true;
        }
        /* yield return new WaitForSeconds(3f);

         if (!isCreated && PlayerIsDetected)
         { 
             Instantiate(projectile, transform.position, this.gameObject.transform.rotation);
             isCreated = true;
         }*/
    }
       
   
}



