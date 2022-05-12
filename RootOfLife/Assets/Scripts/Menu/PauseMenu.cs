using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    //public GameObject RespawnPoint;
    RespawnMerged respawnMerged;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        respawnMerged = player.GetComponent<RespawnMerged>();

        /*if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else  
            {
                Pause();
            }
        }*/
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadCollectible()
    {
        Debug.Log("Loading collectible...");
    }
    
    public void RestartGame()
    {
        Debug.Log("Loading RestartGame...");

        Time.timeScale = 1f;
        respawnMerged.StartCoroutine("Respawn");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //référence future : https://www.youtube.com/watch?v=TVSLCZWYL_E
        //SceneManager.LoadScene("Demo_Preuve_techno");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
