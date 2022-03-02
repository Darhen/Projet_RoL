using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleExit : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject MenuCollectiblesUI;

    // Update is called once per frame
    void Update()
    {
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
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        MenuCollectiblesUI.SetActive(true);
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
