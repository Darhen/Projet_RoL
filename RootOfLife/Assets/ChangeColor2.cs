using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor2 : MonoBehaviour
{

    ActivationPorte activationPorte;
    public GameObject interrupteur;
    public Material activeMat;
    public Material notActiveMat;

    // Start is called before the first frame update
    void Start()
    {
        activationPorte = interrupteur.GetComponent<ActivationPorte>();
    }

    private void Update()
    {
        if (activationPorte.switchActivated)
        {
            this.gameObject.GetComponent<Renderer>().material = activeMat;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = notActiveMat;
        }

    }
}