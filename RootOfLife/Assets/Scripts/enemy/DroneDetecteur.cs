using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(MeshRenderer))]
public class DroneDetecteur : MonoBehaviour
{
    public bool isInsideDroneBeam = false;
    public bool isInsideSolBeam = false;
    Collider m_Collider = null;
    Renderer _renderer;
    Animator animatorDrone;
    Animator animatorDetection;
    Animator animatorDetectionSol;
    Animator animatorSol;
    public GameObject drone;
    public GameObject ennemiSol;
    public GameObject droneDetector;
    public GameObject solDetector;
    public GameObject player;
    PlayerController playerController;
    enemy_sol_mouvement ennemiSolMouv;
    RespawnMerged respawn;
    public bool playerDetected = false;
    public bool playerDetectedSol = false;
    StopAnim stopAnim;


    void Start()
    {

        m_Collider = GetComponent<Collider>();
        Debug.Assert(m_Collider);
        _renderer = GetComponent<Renderer>();
        respawn = player.GetComponent<RespawnMerged>();
        playerController = player.GetComponent<PlayerController>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Permet que fonctionne si plusieurs drones dans meme scene
        if(other.gameObject.tag == "DetectionEnnemi")
        {
            drone = other.GetComponentInParent<StopAnim>().gameObject;
            droneDetector = drone.GetComponentInChildren<DroneAttaque>().gameObject;
            animatorDetection = droneDetector.GetComponent<Animator>();
            animatorDrone = drone.GetComponent<Animator>();
            stopAnim = drone.GetComponent<StopAnim>();
        }
        
        // Permet de fonctionner si plusieurs ennemis sol dans meme scene
        if (other.gameObject.tag == "DetectionEnnemiSol")
        {
            ennemiSol = other.GetComponentInParent<StopAnim>().gameObject;
            solDetector = ennemiSol.GetComponentInChildren<DroneAttaque>().gameObject;
            ennemiSolMouv = ennemiSol.GetComponent<enemy_sol_mouvement>();
            animatorDetectionSol = solDetector.GetComponent<Animator>();
            animatorSol = ennemiSol.GetComponent<Animator>();
            stopAnim = solDetector.GetComponent<StopAnim>();
            animatorSol.SetBool("IsCharging", false);
        }

    }
    
    void OnTriggerStay(Collider trigger)
    {
        var dynamicOcclusion = trigger.GetComponent<VLB.DynamicOcclusionRaycasting>();

        //Détection ennemi drone
        if (trigger.gameObject.tag == "DetectionEnnemi")
        {
            if (dynamicOcclusion)
            {
                isInsideDroneBeam = !dynamicOcclusion.IsColliderHiddenByDynamicOccluder(m_Collider);
                droneDetector.GetComponent<DroneAttaque>().PlayerIsDetected = isInsideDroneBeam;
            }
            else
            {
                isInsideDroneBeam = true;
                droneDetector.GetComponent<DroneAttaque>().PlayerIsDetected = isInsideDroneBeam;
            }
        }
        
        //Détection ennemi sol
        if (trigger.gameObject.tag == "DetectionEnnemiSol")
        {
            if (dynamicOcclusion)
            {
                isInsideSolBeam = !dynamicOcclusion.IsColliderHiddenByDynamicOccluder(m_Collider);
                solDetector.GetComponent<DroneAttaque>().PlayerIsDetectedSol = isInsideSolBeam;
            }
            else
            {
                isInsideSolBeam = true;
                solDetector.GetComponent<DroneAttaque>().PlayerIsDetectedSol = isInsideSolBeam;
            }
        }

    }

    
    private void OnTriggerExit(Collider trigger)
    {

        //Sort de la détection ennemi drone
        if (trigger.gameObject.tag == "DetectionEnnemi")
        {
            isInsideDroneBeam = false;
            droneDetector.GetComponent<DroneAttaque>().PlayerIsDetected = isInsideDroneBeam;
            if (isInsideDroneBeam == false)
            {
                playerController.speed = 10f;
                playerDetected = false;
                if (animatorDrone != null) animatorDrone.enabled = true;
                if (animatorDetection != null) animatorDetection.Play("RedToWhite");
            }
        }
        
        //Sort de la détection ennemi sol
        if (trigger.gameObject.tag == "DetectionEnnemiSol")
        {
            isInsideSolBeam = false;
            solDetector.GetComponent<DroneAttaque>().PlayerIsDetectedSol = isInsideSolBeam;

            if (isInsideSolBeam == false)
            {
                playerController.speed = 10f;
                playerDetectedSol = false;
                ennemiSolMouv.speed = 5f;
                if (animatorSol != null) animatorSol.enabled = true;
                animatorSol.SetBool("IsCharging", false);
                if (animatorDetectionSol != null) animatorDetectionSol.Play("RedToWhite");
                if (respawn.deadBySol == true)
                {
                    Debug.Log("T'es mort");
                    ennemiSolMouv.speed = 0f;
                    if (animatorSol != null) animatorSol.enabled = false;
                }
            }
        }

    }

    void Update()
    {
        
        if (isInsideDroneBeam || isInsideSolBeam || stopAnim.amDead == true)
        {
            // Détection ennemi drone
            if (isInsideDroneBeam)
            {
                playerController.speed = 7.5f;
                playerDetected = true;
                if (animatorDrone != null) animatorDrone.enabled = false;
                if (animatorDetection != null) animatorDetection.Play("WhiteToRed");
            }

            // Détection ennemi sol
            if (isInsideSolBeam)
            {
                
                Debug.Log("PlayerIsDetected!");
                playerController.speed = 7.5f;
                playerDetectedSol = true;
                ennemiSolMouv.speed = 15f;
                animatorSol.SetBool("IsCharging", true);
                if (animatorDetectionSol != null) animatorDetectionSol.Play("WhiteToRedSol");
                if (respawn.deadBySol == true)
                {
                    Debug.Log("T'es mort");
                    ennemiSolMouv.speed = 0f;
                    if (animatorSol != null) animatorSol.enabled = false;
                }

            }

        }

    }

}
