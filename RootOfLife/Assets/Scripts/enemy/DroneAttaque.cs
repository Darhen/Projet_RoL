using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttaque : MonoBehaviour
{

    public GameObject sphere;
    public GameObject drone;
    public Transform spherePosition;
    DroneDetecteur droneDetecteur;
    public bool isInsideDroneBeam;
    public bool PlayerIsDetected;

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
    }
}
