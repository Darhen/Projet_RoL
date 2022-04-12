using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPorteConnecteur : MonoBehaviour
{
    private Animator porteAnimator;
    public bool switchActivated;
    public GameObject Porte;
    public GameObject player;

    RespawnMerged respawnMerged;
    SensorTrigger sensorTrigger;


    // Start is called before the first frame update
    void Start()
    {
        porteAnimator = Porte.GetComponent<Animator>();
        respawnMerged = player.GetComponent<RespawnMerged>();
        sensorTrigger = this.gameObject.GetComponent<SensorTrigger>();
        
    }
    void Update()
    {
        if (sensorTrigger.isActive)
        {
            switchActivated = true;
            porteAnimator.SetBool("Activated", true);
        }
        /*
        if (respawnMerged.estMort == true)
        {
            sensorTrigger.isActive = false;
            switchActivated = false;
            porteAnimator.SetBool("Activated", false);
        }*/
    }
}
