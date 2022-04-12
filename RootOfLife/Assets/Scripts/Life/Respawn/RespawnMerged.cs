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

    PlayerController playerController;
    public bool isDying = false;
    public bool estMort = false;
    public bool deadBySol = false;


    private void Start()
    {

        playerController = this.gameObject.GetComponent<PlayerController>();
        
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        activateCheckIfIsInside = sphere.GetComponent<ActivateCheckIfIsInside>();

        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        ennemiSol = droneDetecteur.ennemiSol;
        ennemiSolMouv = ennemiSol.GetComponent<enemy_sol_mouvement>();

        respawnPoint = player.transform.position;
        FadeOutScreen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //Mort par ennemi robot
        if (other.CompareTag("Ennemi") || other.CompareTag("EnnemiGround") || other.CompareTag("EnnemiDrone"))
        {

            isDead();
            
            //Mort par ennemi sol
            if (other.CompareTag("EnnemiGround"))
            {
                Debug.Log("Allo");
                deadBySol = true;
                StartCoroutine(ResetEnnemiSol());
            }
               
        }
        
        //Mort par trou
        if (other.CompareTag("Trou"))
        {
            isDead();
        }
        
        //CheckPoint
        if (other.gameObject.tag == "CheckPoint")
        {
            Debug.Log("CheckPoint!");
            respawnPoint = player.transform.position;
        }
    }

    private void Update()
    {
        //Mort par manque de lumière
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
        player.transform.position = respawnPoint;
        estMort = false;
        yield return new WaitForSeconds(0.5f);
        newCheckIfIsInsideBeam.variableT = newCheckIfIsInsideBeam.minT;
        newCheckIfIsInsideBeam.lerpedColor = newCheckIfIsInsideBeam.colorIni;
        playerController.enabled = true;

    }

    IEnumerator ResetEnnemiSol()
    {
        yield return new WaitForSeconds(3f);
        deadBySol = false;
    }


}
