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
    public bool isShooting = false;

    public float timeBtwShots;
    public float startTimeBtwShots;

    void Start()
    {
        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
    }


    void Update()
    {
        PlayerIsDetected = droneDetecteur.playerDetected;
        

        if (PlayerIsDetected)
        {
            StartCoroutine(PlayerDetected());
            
        }
        else 
        {
            PlayerIsDetected = false;
        }
        
    }
    
    IEnumerator PlayerDetected()
    {
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(spherePosition);
        yield return new WaitForSeconds(3f);
        isShooting = true;
        
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, this.gameObject.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}

