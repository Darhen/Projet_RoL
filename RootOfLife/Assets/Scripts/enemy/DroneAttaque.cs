using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttaque : MonoBehaviour
{

    public GameObject sphere;
    public Transform spherePosition;
    DroneDetecteur droneDetecteur;
    public bool isInsideDroneBeam;
    public bool PlayerIsDetected;
    public bool isShooting = false;

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
/*
        if (isShooting == true)
        {
            blabla
        }
        */
    }
    
    IEnumerator PlayerDetected()
    {
        yield return new WaitForSeconds(0.75f);
        transform.LookAt(spherePosition);
        yield return new WaitForSeconds(8f);
        isShooting = true;

    }
}
