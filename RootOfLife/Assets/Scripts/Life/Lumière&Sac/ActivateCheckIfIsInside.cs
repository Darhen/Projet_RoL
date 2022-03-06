using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckIfIsInside : MonoBehaviour
{
    public bool activated;
    NewCheckIfIsInsideBeam newCheckIfIsInsideBeam;
    public GameObject sphere;
    public Color LerpedColor;
    //public float VariableT;

    // Start is called before the first frame update
    void Start()
    {
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        this.GetComponent<NewCheckIfIsInsideBeam>().enabled = false;
        activated = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ActivationLight" && !activated)
        {
            this.GetComponent<NewCheckIfIsInsideBeam>().enabled = true;
            StartCoroutine("ChangeBoolPos");
        }

        if (other.gameObject.tag == "ActivationLight" && activated)
        {
            
            this.GetComponent<NewCheckIfIsInsideBeam>().enabled = false;
            newCheckIfIsInsideBeam.variableT = 0f;
            newCheckIfIsInsideBeam.lerpedColor = newCheckIfIsInsideBeam.colorIni;
            StartCoroutine("ChangeBoolNeg");
        }
    }


    IEnumerator ChangeBoolNeg()
    {
        yield return new WaitForSeconds(0.1f);
        activated = false;
    }

    IEnumerator ChangeBoolPos()
    {
        yield return new WaitForSeconds(0.1f);
        activated = true;
    }
}
