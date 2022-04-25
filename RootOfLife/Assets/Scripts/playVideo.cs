using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVideo : MonoBehaviour
{

    public GameObject videoPlayer;
    public int timeToStop;
    public bool generiqueActive;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
        generiqueActive = false;
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            generiqueActive = true;
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
        }

    }
}
