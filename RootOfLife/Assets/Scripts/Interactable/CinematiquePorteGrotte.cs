using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiquePorteGrotte : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject cinematicCameraPorte;
    public GameObject cameraTrigger1;
    public GameObject connecteur;
    public GameObject ledgeClimb;
    public GameObject FadeOutScreen;
    Animator animatorFadeOut;
    PlayerController playerController;
    ActivationPorteConnecteur activationPorte;
    PlugPlant plugplant;
    Plane plane;
    MoveObject moveObject;
    public bool porteOuverte;


    // Start is called before the first frame update
    void Start()
    {
        activationPorte = connecteur.GetComponent<ActivationPorteConnecteur>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        plugplant = GameObject.FindWithTag("Player").GetComponent<PlugPlant>();
        plane = GameObject.FindWithTag("Player").GetComponent<Plane>();
        moveObject = GameObject.FindWithTag("Player").GetComponent<MoveObject>();
        cameraTrigger1.SetActive(true);
        cinematicCameraPorte.SetActive(false);
        ledgeClimb.SetActive(false);
        porteOuverte = false;
        animatorFadeOut = FadeOutScreen.GetComponent<Animator>();
        FadeOutScreen.SetActive(false);
        animatorFadeOut.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activationPorte.switchActivated == true && porteOuverte == false)
        {
            StartCoroutine (CinematiquePorte());
            ledgeClimb.SetActive(true);
            porteOuverte = true;
        }
    }

    IEnumerator CinematiquePorte()
    {
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
        cameraTrigger1.SetActive(false);
        plugplant.enabled = false;
        plane.enabled = false;
        moveObject.enabled = false;

    }

    void SwitchCamera()
    {
        FadeOutScreen.SetActive(true);
        animatorFadeOut.enabled = true;
        animatorFadeOut.Play("FadeToBlackCinematique");
        mainCamera.SetActive(false);
        cinematicCameraPorte.SetActive(true);
        animatorFadeOut.Play("FadeToGameCinematique");
        animatorFadeOut.enabled = false;
        FadeOutScreen.SetActive(false);
    }


    void EndCinematicMode()
    {
        playerController.enabled = true;
        //animatorPlayer.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        moveObject.enabled = true;
        cinematicCameraPorte.SetActive(false);
        cameraTrigger1.SetActive(true);
        mainCamera.SetActive(true);

    }
}
