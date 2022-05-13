using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class menuStormFrei : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menuPauseUI;
    GameObject player;
    public string menuPrincipal = "MenuPrincipal";
    public string Lvl_1 = "LEVEL  1";
    public string Lvl_2 = "LEVEL2";
    public string Lvl_3 = "LEVEL_GROTTE_OFFICIEL";
    public string Lvl_4 = "Level4";

    public GameObject pauseFirstButton;


    MenuController_Paused pauseControl; // A reference to the MenuController for our pause menu
    public string myIndex; // A string which defines the index of this currently loaded canvas
    Canvas myCanvas; // A canvas which defines what the canvas is on the object this script is attached to

    //SON ON OFF MENU
    public AK.Wwise.Event MenuOn;
    public AK.Wwise.Event MenuOff;


    void Start()
    {
        myCanvas = gameObject.GetComponent<Canvas>(); // We set our canvas
        pauseControl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MenuController_Paused>(); // We define the pauseControl variable
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == true)
            {
                Reprendre();
                MenuOff.Post(gameObject);
            }
            else
            {
                SurPause();
                MenuOn.Post(gameObject);
            }
        }

        // LOADSCENE MANUEL (TEMPORAIRE)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(Lvl_1);
            Debug.Log("loading1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(Lvl_2);
            Debug.Log("loading2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(Lvl_3);
            Debug.Log("loading3");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(Lvl_4);
            Debug.Log("loading4");
        }
    }


    public void Reprendre() //fonction pour le bouton "reprendre" aussi
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().enabled = true;
        //player.GetComponent<PlugPlant>().enabled = true;
        player.GetComponent<AnimationCharacter>().enabled = true;
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
        //player.GetComponent<PlugPlant>().enabled = false;
        player.GetComponent<AnimationCharacter>().enabled = false;
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
