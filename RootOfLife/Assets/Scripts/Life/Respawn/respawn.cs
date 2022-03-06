using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public GameObject fadeToBlack;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            fadeToBlack.GetComponent<Animation>().Play("fadeToBlack");
        }
    }
    /*
    public void FadingOut()
    {
        fadeToBlack.GetComponent<Animation>().Play("fadeToBlack");
    }
    */
}
