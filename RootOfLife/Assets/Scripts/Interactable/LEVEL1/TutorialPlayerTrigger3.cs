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
        oldCercleBlancAnimator.SetTrigger("off");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        oldObjectAnimator.SetTrigger("deactivate");
        yield return new WaitForSeconds(1f);
        oldObject.SetActive(false);
        nextObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        nextLight.SetActive(true);
        nextCercleBlancAnimator.SetTrigger("on");
    }
}
