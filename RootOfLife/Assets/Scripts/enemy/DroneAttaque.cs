using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttaque : MonoBehaviour
{

    public GameObject sphere;
    public GameObject projectile;
    public GameObject player;
    public Transform spherePosition;
    Animator animatorSol;
    DroneDetecteur droneDetecteur;
    enemy_sol_mouvement ennemiSolMouv;
    private GameObject ennemiSol;
    RespawnMerged respawn;
    //DroneDetecteur droneDetecteur;
    //RespawnMerged respawn;
    //public bool isInsideDroneBeam;
    public bool PlayerIsDetected;
    public bool PlayerIsDetectedSol;
    private float elapsed;

    public float timeBtwShots;
    public float startTimeBtwShots;

    public bool isCreated;

    void Start()
    {
        //droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        isCreated = false;
        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        ennemiSol = droneDetecteur.ennemiSol;
        ennemiSolMouv = ennemiSol.GetComponent<enemy_sol_mouvement>();
        respawn = player.GetComponent<RespawnMerged>();
        //animatorSol = droneDetecteur.GetComponent<Animator>.animatorSol;
        //respawn = player.GetComponent<RespawnMerged>();
    }


    void Update()
    {
        //PlayerIsDetected = droneDetecteur.isInsideDroneBeam;

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
        

        //Si détecté par ennemi sol
        if (PlayerIsDetectedSol)
        {
            Debug.Log("PlayerDetected");
            StartCoroutine(LookAtPlayer());
            //StartCoroutine(ChargePlayer());
        }

        if (!PlayerIsDetectedSol)
        {
            //StopCoroutine(ChargePlayer());
            StopCoroutine(LookAtPlayer());
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
/*
   IEnumerator ChargePlayer()
    {
        elapsed = 0;
        while (elapsed < 1f)
        {
            yield return null;
            elapsed += Time.deltaTime;
            
        }

        yield return new WaitForSeconds(0.1f);

       if (respawn.deadBySol == false)
        {
            ennemiSolMouv.speed = 20;
        }
    }*/

}



