using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTriggerPlayer : MonoBehaviour
{
    CameraTriggerPlayer cameraTriggerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cameraTriggerPlayer = this.gameObject.GetComponentInChildren<CameraTriggerPlayer>();
        cameraTriggerPlayer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraTriggerPlayer.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraTriggerPlayer.enabled = false;
        }
    }

}
