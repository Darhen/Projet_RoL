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
    public DroneAttaque droneDetectePlayer;
    public GameObject sphere;
    public GameObject myLight;
    public GameObject DroneDetecteur;
    PlayerController playerController;
    public bool isDying = false;


    private void Start()
    {

        playerController = this.gameObject.GetComponent<PlayerController>();
        
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        activateCheckIfIsInside = sphere.GetComponent<ActivateCheckIfIsInside>();
        droneDetectePlayer = DroneDetecteur.GetComponent<DroneAttaque>();
        respawnPoint = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi") || other.CompareTag("EnnemiGround") || other.CompareTag("EnnemiDrone"))
        {
            isDead();
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

    private void isDead()
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
        activateCheckIfIsInside.activated = false;
        myLight.SetActive(false);
        player.transform.position = respawnPoint;
        droneDetectePlayer.PlayerIsDetected = false;
        playerController.enabled = true;

        // Physics.SyncTransforms();
    }

}
