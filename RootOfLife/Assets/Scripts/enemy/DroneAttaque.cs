using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttaque : MonoBehaviour
{

    public GameObject sphere;
    public GameObject projectile;
    public GameObject player;
    public Transform spherePosition;
    public bool PlayerIsDetected;
    public bool PlayerIsDetectedSol;
    public bool isCreated;
    private float elapsed;
    public float timeBtwShots;
    public float startTimeBtwShots;
    

    void Start()
    {
        isCreated = false;
    }


    void Update()
    {

        //Si détecté par ennemi drone
        if (PlayerIsDetected)
        {
            StartCoroutine(LookAtPlayer());
            StartCoroutine(ShootPlayer());
            
        }
        if (!PlayerIsDetected)
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
        while(elapsed < 2f)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        if (!isCreated && PlayerIsDetected)
        {
            Instantiate(projectile, transform.position, this.gameObject.transform.rotation);
            isCreated = true;
        }
    }

}



