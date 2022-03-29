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
    enemy_sol_mouvement ennemiSolMouv;
    private GameObject ennemiSol;

    public GameObject sphere;
    public GameObject myLight;
    //public GameObject beamDetecteur;

    PlayerController playerController;
    public bool isDying = false;
    public bool estMort = false;


    private void Start()
    {

        playerController = this.gameObject.GetComponent<PlayerController>();
        
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        activateCheckIfIsInside = sphere.GetComponent<ActivateCheckIfIsInside>();

        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        ennemiSol = droneDetecteur.ennemiSol;
        ennemiSolMouv = ennemiSol.GetComponent<enemy_sol_mouvement>();
        //beamDetecteur = GameObject.FindWithTag("DetectionEnnemi");
        //droneAttaque = beamDetecteur.GetComponent<DroneAttaque>();

        respawnPoint = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi") || other.CompareTag("EnnemiGround") || other.CompareTag("EnnemiDrone"))
        {
            //droneDetecteur.isInsideDroneBeam = false;
            /*if (other.gameObject.tag == "EnnemiGround")
            {
                ennemiSolMouv.speed = 0;
            }*/

            isDead();
            
            if (other.CompareTag("EnnemiGround"))
            {
                ennemiSolMouv.speed = 0;
                StartCoroutine(ResetEnnemiSol());
            }
               
        }
        
        if (other.CompareTag("Trou"))
        {
            isDead();
        }
        
        if (other.gameObject.tag == "CheckPoint")
        {
            Debug.Log("CheckPoint!");
            respawnPoint = player.transform.position;
        }
    }

    private void Update()
    {
        if (newCheckIfIsInsideBeam.variableT >= newCheckIfIsInsideBeam.maxT) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
        {
            isDying = true;
            isDead();
        }
    }

    public void isDead()
    {

        estMort = true;
        StartCoroutine(Respawn());
        FadeOutScreen.SetActive(false);
        
    }

    IEnumerator Respawn()
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
        estMort = false;
        playerController.enabled = true;
        Debug.Log("Test");
        
        // Physics.SyncTransforms();
    }

    IEnumerator ResetEnnemiSol()
    {
        Debug.Log("ALLO!");
        yield return new WaitForSeconds(3f);
        ennemiSolMouv.speed = 5;
    }


}
