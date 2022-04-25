using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoAlternatif : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timeToStop;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerstay(Collider player)
    {
        if (Input.GetButtonDown("Fire3"))
            
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
             
        }

    }
}
