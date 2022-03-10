using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseActivation : MonoBehaviour
{
    public bool pulseActiv;
    public float variable;
    public GameObject Sphere;
    public Light myLight;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Pulse>().enabled = false;
        myLight = this.GetComponent<Light>();
        pulseActiv = false;

    }

    // Update is called once per frame
    void Update()
    {

        variable = Sphere.GetComponent<NewCheckIfIsInsideBeam>().variableT;

        if (variable >= 0.75f && pulseActiv == false)
        {
            Debug.Log("Allo");
            this.GetComponent<Pulse>().enabled = true;
            StartCoroutine("ChangeBoolPos");
        }

        if (variable < 0.75f && pulseActiv)
        {
            this.GetComponent<Pulse>().enabled = false;
            StartCoroutine("ChangeBoolNeg");
        }
    }

    IEnumerator ChangeBoolNeg()
    {
        yield return new WaitForSeconds(0.01f);
        pulseActiv = false;
        myLight.intensity = 4.5f;
    }
    IEnumerator ChangeBoolPos()
    {
        yield return new WaitForSeconds(0.01f);
        pulseActiv = true;
    }
}
