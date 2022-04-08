using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTriggerCamPlantePlayer : MonoBehaviour
{
    CamTriggerPlayerPlante camTriggerPlayerPlante;

    // Start is called before the first frame update
    void Start()
    {
        camTriggerPlayerPlante = this.gameObject.GetComponentInChildren<CamTriggerPlayerPlante>();
        camTriggerPlayerPlante.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            camTriggerPlayerPlante.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camTriggerPlayerPlante.enabled = false;
        }
    }

}
