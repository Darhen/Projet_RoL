using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : MonoBehaviour
{
    //Animator animator;
    //public GameObject drone;
    public bool amDead = false;
    enemy_sol_mouvement ennemiSolMouv;
    DroneDetecteur droneDetecteur;
    GameObject sphere;

    void Start()
    {
        sphere = GameObject.FindWithTag("LifeLight");
        ennemiSolMouv = this.gameObject.GetComponent<enemy_sol_mouvement>();
        droneDetecteur = sphere.GetComponent<DroneDetecteur>();
        //animator = this.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {

            amDead = true;
            StartCoroutine(StopDrone());
        }

    }

    IEnumerator StopDrone()
    {
        yield return new WaitForSeconds(3f);
        amDead = false;

    }

    private void Update()
    {
        if (this.gameObject.tag == "EnnemiGround" && !(this.gameObject.layer == 8))
        {
            if (amDead == false && droneDetecteur.isInsideSolBeam == false)
            {
                ennemiSolMouv.speed = 5f;
                this.gameObject.GetComponent<Animator>().enabled = true;

            }
        }
        
    }
}
