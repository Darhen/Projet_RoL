using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiquePorteGrotteInterrupteur : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject cinematicCameraPorte;
    public GameObject interrupteur;
    public GameObject player;
    //public GameObject FadeOutScreen;
    Animator animatorFadeOut;
    PlayerController playerController;
    ActivationPorte activationPorte;
    PlugPlant plugplant;
    Plane plane;
    MoveObject moveObject;
    public bool porteOuverte;


    // Start is called before the first frame update
    void Start()
    {
        activationPorte = interrupteur.GetComponent<ActivationPorte>();
        playerController = player.GetComponent<PlayerController>();
        plugplant = player.GetComponent<PlugPlant>();
        plane = player.GetComponent<Plane>();
        moveObject = player.GetComponent<MoveObject>();
        cinematicCameraPorte.SetActive(false);
        porteOuverte = false;
        //animatorFadeOut = FadeOutScreen.GetComponent<Animator>();
        //FadeOutScreen.SetActive(false);
        animatorFadeOut.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activationPorte.switchActivated == true && porteOuverte == false)
        {
            StartCoroutine(CinematiquePorte());
            porteOuverte = true;
        }
    }

    IEnumerator CinematiquePorte()
    {
        Debug.Log("Bonjouuuuur");
        CinematicMode();
        yield return new WaitForSeconds(0.5f);
        SwitchCamera();
        yield return new WaitForSeconds(3f);
        EndCinematicMode();
        Debug.Log("EnnemiFall");

    }

    void CinematicMode()
    {

        playerController.enabled = false;
        //animatorPlayer.enabled = false;
        plugplant.enabled = false;
        plane.enabled = false;
        moveObject.enabled = false;

    }

    void SwitchCamera()
    {
        //FadeOutScreen.SetActive(true);
        //animatorFadeOut.enabled = true;
        //animatorFadeOut.Play("FadeToBlackCinematique");
        mainCamera.SetActive(false);
        cinematicCameraPorte.SetActive(true);
        //animatorFadeOut.Play("FadeToGameCinematique");
        //animatorFadeOut.enabled = false;
        //FadeOutScreen.SetActive(false);
    }


    void EndCinematicMode()
    {
        playerController.enabled = true;
        //animatorPlayer.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        moveObject.enabled = true;
        cinematicCameraPorte.SetActive(false);
        mainCamera.SetActive(true);

    }
}
