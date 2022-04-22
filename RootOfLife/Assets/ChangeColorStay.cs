using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorStay : MonoBehaviour
{
    SensorStay sensorStay;
    public GameObject connecteur;
    public Material activeMat;
    public Material notActiveMat;

    // Start is called before the first frame update
    void Start()
    {
        sensorStay = connecteur.GetComponent<SensorStay>();
    }

    private void Update()
    {
        if (sensorStay.isActive)
        {
            this.gameObject.GetComponent<Renderer>().material = activeMat;
        }
        else if (sensorStay.isActive == false) 
        {
            this.gameObject.GetComponent<Renderer>().material = notActiveMat;
        }

    }
}
