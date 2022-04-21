using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class menuStormFrei : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menuPauseUI;
    public GameObject player;
    public string menuPrincipal = "MenuPrincipal";

    public GameObject pauseFirstButton;


    MenuController_Paused pauseControl; // A reference to the MenuController for our pause menu
    public string myIndex; // A string which defines the index of this currently loaded canvas
    Canvas myCanvas; // A canvas which defines what the canvas is on the object this script is attached to

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == true)
            {
                Reprendre();
            }
            else
            {
                SurPause();
            }
        }
    }

    void Start()
    {
        myCanvas = gameObject.GetComponent<Canvas>(); // We set our canvas
        pauseControl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MenuController_Paused>(); // We define the pauseControl variable
    }

    public void Reprendre() //fonction pour le bouton "reprendre" aussi
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().enabled = true;
    }

    void SurPause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f; //met le jeu sur pause
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);    //clear les selection
        EventSystem.current.SetSelectedGameObject(pauseFirstButton); //cree nouvelle selection (pour manette)
        Cursor.lockState = CursorLockMode.None; //fait reapparaitre le curseur
        player.GetComponent<PlayerController>().enabled = false; //fait qu'on ne peut pas "dash" durant le menu
    }

    public void LoadMenu()
    {
        Debug.Log("loadingMenuPrincipal");
        SceneManager.LoadScene(menuPrincipal);
        Time.timeScale = 1f;
    }

    public void Quitter()
    {
        Debug.Log("Quitte le jeu");
        Application.Quit();
    }
}
