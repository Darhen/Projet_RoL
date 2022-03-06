using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEmissiveActivation : MonoBehaviour
{
    public bool pulseActiv;
    public float variable;
    public GameObject Sphere;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<PulseEmissive>().enabled = false;
        pulseActiv = false;

    }

    // Update is called once per frame
    void Update()
    {

        variable = Sphere.GetComponent<NewCheckIfIsInsideBeam>().variableT;

        if (variable >= 0.7 && pulseActiv == false)
        {
            Debug.Log("Allo");
            this.GetComponent<PulseEmissive>().enabled = true;
            StartCoroutine("ChangeBoolPos");
        }

        if (variable < 0.7 && pulseActiv)
        {
            this.GetComponent<PulseEmissive>().enabled = false;
            StartCoroutine("ChangeBoolNeg");
        }
    }

    IEnumerator ChangeBoolNeg()
    {
        yield return new WaitForSeconds(0.01f);
        pulseActiv = false;
    }
    IEnumerator ChangeBoolPos()
    {
        yield return new WaitForSeconds(0.01f);
        pulseActiv = true;
    }
}
