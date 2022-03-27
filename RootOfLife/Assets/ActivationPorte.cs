using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPorte : MonoBehaviour
{

    public Animator porteAnimator;
    public bool switchActivated;
    public GameObject Porte;
    public GameObject player;
    RespawnMerged respawnMerged;

    // Start is called before the first frame update
    void Start()
    {
        porteAnimator = Porte.GetComponent<Animator>();
        respawnMerged = player.GetComponent<RespawnMerged>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider trigger)
    {
        if (trigger.CompareTag("Player")){
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Ca fonctionne");
                switchActivated = true;
                porteAnimator.SetBool("Activated", true);
            }
        }
    }
    void Update()
    {
        if (respawnMerged.isDying == true)
        {
            switchActivated = false;
            porteAnimator.SetBool("Activated", false);
        }
    }
}
