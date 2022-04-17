using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    SensorTrigger sensorTrigger;
    public GameObject connecteur;
    public Material activeMat;
    public Material notActiveMat;

    // Start is called before the first frame update
    void Start()
    {
        sensorTrigger = connecteur.GetComponent<SensorTrigger>();
    }

    private void Update()
    {
        if (sensorTrigger.isActive)
        {
            this.gameObject.GetComponent<Renderer>().material = activeMat;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = notActiveMat;
        }

    }
}
