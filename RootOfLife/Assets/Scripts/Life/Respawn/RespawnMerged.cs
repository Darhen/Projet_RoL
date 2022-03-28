using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnMerged : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 respawnPoint;

    public GameObject FadeOutScreen;
    NewCheckIfIsInsideBeam newCheckIfIsInsideBeam;
    ActivateCheckIfIsInside activateCheckIfIsInside;
    CouleurEmmissiveSac couleurEmissiveSac;

    DroneDetecteur droneDetecteur;
    DroneAttaque droneAttaque;

    public GameObject sphere;
    public GameObject myLight;
    //public GameObject beamDetecteur;

    PlayerController playerController;
    public bool isDying = false;


    private void Start()
    {

        playerController = this.gameObject.GetComponent<PlayerController>();
        
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        activateCheckIfIsInside = sphere.GetComponent<ActivateCheckIfIsInside>();

        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        //beamDetecteur = GameObject.FindWithTag("DetectionEnnemi");
        //droneAttaque = beamDetecteur.GetComponent<DroneAttaque>();

        respawnPoint = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi") || other.CompareTag("EnnemiGround") || other.CompareTag("EnnemiDrone"))
        {
            //droneDetecteur.isInsideDroneBeam = false;
            isDead();
            droneAttaque.isCreated = false;
        }
        else if (other.CompareTag("Trou"))
        {
            isDead();
        }
        else if (other.gameObject.tag == "CheckPoint")
        {
            respawnPoint = player.transform.position;
        }
    }

    private void Update()
    {
        if (newCheckIfIsInsideBeam.variableT >= newCheckIfIsInsideBeam.maxT) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
        {
            isDead();
        }
    }

    public void isDead()
    {
        
        isDying = true;
        StartCoroutine(RespawnCollision());
        FadeOutScreen.SetActive(false);
        
    }

    IEnumerator RespawnCollision()
    {
        playerController.enabled = false;
        yield return new WaitForSeconds(1f);
        FadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        isDying = false;
        newCheckIfIsInsideBeam.variableT = newCheckIfIsInsideBeam.minT;
        newCheckIfIsInsideBeam.lerpedColor = newCheckIfIsInsideBeam.colorIni;
        //activateCheckIfIsInside.activated = false;
        //myLight.SetActive(false);
        player.transform.position = respawnPoint;
        
        playerController.enabled = true;
        Debug.Log("Test");
        // Physics.SyncTransforms();
    }

}
