using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleExit : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject MenuCollectiblesUI;
    public GameObject CollectibleUI;
    public GameObject CollectibleUI2;
    public GameObject CollectibleUI3;
    public GameObject CollectibleUI4;
    public GameObject CollectibleUI5;
    public GameObject CollectibleUI6;
    public GameObject CollectibleUI7;
    public GameObject CollectibleUI8;
    public GameObject CollectibleUI9;

    // Update is called once per frame
    void Update()
    {
        //CollectibleUI.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else  
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {   
        MenuCollectiblesUI.SetActive(false);
        CollectibleUI.SetActive(false);
        CollectibleUI2.SetActive(false);
        CollectibleUI3.SetActive(false);
        CollectibleUI4.SetActive(false);
        CollectibleUI5.SetActive(false);
        CollectibleUI6.SetActive(false);
        CollectibleUI7.SetActive(false);
        CollectibleUI8.SetActive(false);
        CollectibleUI9.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        MenuCollectiblesUI.SetActive(true);
        //CollectibleUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /*
    public void LoadCollectible()
    {
        Debug.Log("Loading collectible...");
    }
    
    public void RestartGame()
    {
        Debug.Log("Loading RestartGame...");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("Restart");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    */
}
