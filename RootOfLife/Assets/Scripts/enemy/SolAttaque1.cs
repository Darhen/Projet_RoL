using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolAttaque1 : MonoBehaviour
{
    public GameObject sphere;
    public Transform spherePosition;
    DroneDetecteur droneDetecteur;
    public bool isInsideDroneBeam;
    public bool PlayerIsDetected;
    private float elapsed;
    new Vector3 playerPosition;
    new GameObject player;
    enemy_sol_mouvement mouvementEnnemi;

    void Start()
    {
        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        player = GameObject.FindWithTag("Player");
        mouvementEnnemi = this.gameObject.GetComponent<enemy_sol_mouvement>();
    }


    void Update()
    {
        PlayerIsDetected = droneDetecteur.playerDetected;

        playerPosition = player.transform.position;
        

        if (PlayerIsDetected)
        {
            Debug.Log("marchetu");
            StartCoroutine(LookAtPlayer());
            StartCoroutine(RamPlayer());
        }
        else if (!PlayerIsDetected)
        {
            StopCoroutine(RamPlayer());
        }
        
    }

    IEnumerator LookAtPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        transform.LookAt(spherePosition);
        mouvementEnnemi.speed = 0;
        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPosition, Time.deltaTime * 0.0001f);
    }
    IEnumerator RamPlayer()
    {
        elapsed = 0;
        while (elapsed < 1f)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        if (PlayerIsDetected)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPosition, Time.deltaTime * 40f);
        }
    }
       
}



