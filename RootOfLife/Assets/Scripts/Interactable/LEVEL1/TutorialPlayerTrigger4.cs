using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger4 : MonoBehaviour
{
    public GameObject player;
    public GameObject nextLight;
    public GameObject nextLight2;
    public GameObject oldLight;
    public GameObject wallLights;
    public GameObject ciblesParachute;
    public Animator oldCercleBlancAnimator;
    public Animator nextCercleBlancAnimator; 
    public Animator nextCercleBlancAnimator2;
    public GameObject oldCameraBoundary;
    public GameObject ledgeClimbFinal;
    public Animator gateAnimator;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("ActivateTrigger");
        }
    }
    IEnumerator ActivateTrigger()
    {
        isActive = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        oldCercleBlancAnimator.SetTrigger("off");
        oldLight.SetActive(false);
        oldCameraBoundary.SetActive(false);
        yield return new WaitForSeconds(1f);
        ciblesParachute.SetActive(true);
        wallLights.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        nextCercleBlancAnimator.SetTrigger("on");
        nextCercleBlancAnimator2.SetTrigger("on");
        yield return new WaitForSeconds(0.5f);
        nextLight.SetActive(true);
        nextLight2.SetActive(true);
        ledgeClimbFinal.SetActive(true);
        gateAnimator.SetTrigger("open");
    }
}
