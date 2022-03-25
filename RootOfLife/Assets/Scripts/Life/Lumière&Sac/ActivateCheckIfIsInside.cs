using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckIfIsInside : MonoBehaviour
{
    public bool activated;
    NewCheckIfIsInsideBeam newCheckIfIsInsideBeam;
    public GameObject sphere;
    public Color LerpedColor;
    public GameObject myLight;
    //public float VariableT;

    // Start is called before the first frame update
    void Start()
    {
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        this.GetComponent<NewCheckIfIsInsideBeam>().enabled = false;
        activated = false;
        myLight.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ActivationLight" && !activated)
        {
            this.GetComponent<NewCheckIfIsInsideBeam>().enabled = true;
            StartCoroutine("ChangeBoolPos");
            myLight.SetActive(true);
        }

        if (other.gameObject.tag == "ActivationLight" && activated)
        {
            
            this.GetComponent<NewCheckIfIsInsideBeam>().enabled = false;
            newCheckIfIsInsideBeam.variableT = 0f;
            newCheckIfIsInsideBeam.lerpedColor = newCheckIfIsInsideBeam.colorIni;
            StartCoroutine("ChangeBoolNeg");
            myLight.SetActive(false);
            Debug.Log("blabla");
        }

    }

    private void Update()
    {
        if(activated == true)
        {
            this.GetComponent<NewCheckIfIsInsideBeam>().enabled = true;
        }

        if(activated == false)
        {
            this.GetComponent<NewCheckIfIsInsideBeam>().enabled = false;
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
