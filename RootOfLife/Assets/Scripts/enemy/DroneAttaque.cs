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
    public bool PlayerIsDetectedBras;
    public bool PlayerIsDetectedSol;
    public bool isCreated;
    public bool isCreatedBras;
    private float elapsed;
    public float timeBtwShots;
    public float startTimeBtwShots;

    public bool lookingAtYou = false;
    public Vector3 target;


    void Start()
    {
        isCreated = false;
    }


    void Update()
    {
        target = player.transform.position;

        //Si détecté par ennemi drone
        if (PlayerIsDetected)
        {
            
            StartCoroutine(LookAtPlayer());
            StartCoroutine(ShootPlayer());
            
        }
        if (!PlayerIsDetected)
        {
            StopCoroutine(LookAtPlayer());
            StopCoroutine(ShootPlayer());
            isCreated = false;
            lookingAtYou = false;
        }
        /*
        //Si détecté par ennemi bras
        if (PlayerIsDetectedBras)
        {
            
            StartCoroutine(LookAtPlayerBras());
            StartCoroutine(ShootPlayerBras());

        }
        if (!PlayerIsDetected)
        {
            StopCoroutine(ShootPlayerBras());
            isCreatedBras = false;
        }*/

    }

    IEnumerator LookAtPlayer()
    {
        
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(player.transform);
        Debug.Log("Ca rentre!");
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

    IEnumerator LookAtPlayerBras()
    {

        yield return new WaitForSeconds(0.5f);
        transform.LookAt(player.transform);
        Debug.Log("Ca rentre!");
    }
    IEnumerator ShootPlayerBras()
    {
        elapsed = 0;
        while (elapsed < 2f)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        if (!isCreatedBras && PlayerIsDetectedBras)
        {
            Instantiate(projectile, transform.position, this.gameObject.transform.rotation);
            isCreatedBras = true;
        }
    }

}



