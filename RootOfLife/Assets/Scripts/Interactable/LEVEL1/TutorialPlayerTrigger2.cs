using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger2 : MonoBehaviour
{
    public GameObject player;
    public GameObject nextObject;
    public Animator triggerAnimator;
    public GameObject oldLight;
    public Animator oldCercleBlancAnimator;
    public Animator nextCercleBlancAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        oldCercleBlancAnimator.SetTrigger("on");
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
        yield return new WaitForSeconds(1f);
        nextObject.SetActive(true);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        oldLight.gameObject.SetActive(false);
        nextCercleBlancAnimator.SetTrigger("on");
    }
}
