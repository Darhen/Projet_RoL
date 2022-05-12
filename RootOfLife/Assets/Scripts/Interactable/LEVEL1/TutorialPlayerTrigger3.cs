using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger3 : MonoBehaviour
{
    public GameObject player;
    public GameObject nextObject;
    public GameObject nextLight;
    public GameObject oldObject;
    public Animator oldObjectAnimator;
    public Animator oldCercleBlancAnimator;
    public Animator nextCercleBlancAnimator;
    public Animator plateforme2Animator;
    public GameObject oldCameraBoundary;
    public GameObject playerPosition;

    private bool plateformeMoving;
    //public GameObject cameraBoundaryPosition;
    //public GameObject nextCameraPosition;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plateformeMoving == true)
        {
            player.transform.position = playerPosition.transform.position;
        }

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
        plateformeMoving = true;
        player.GetComponent<PlayerController>().enabled = false;
        //player.transform.parent = this.gameObject.transform;
        plateforme2Animator.SetTrigger("phase2");
        oldCercleBlancAnimator.SetTrigger("off");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        oldObjectAnimator.SetTrigger("deactivate");
        yield return new WaitForSeconds(1f);
        //oldCameraBoundary.SetActive(false);
        //cameraBoundaryPosition.transform.position = Vector3.Lerp(cameraBoundaryPosition.transform.position, nextCameraPosition.transform.position, 6f);
        oldObject.SetActive(false);
        nextObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        nextLight.SetActive(true);
        nextCercleBlancAnimator.SetTrigger("on");
        player.GetComponent<PlayerController>().enabled = true;
        //player.transform.parent = null;
        plateformeMoving = false;
    }
}
