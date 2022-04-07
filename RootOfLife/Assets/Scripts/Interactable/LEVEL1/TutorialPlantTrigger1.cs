using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlantTrigger1 : MonoBehaviour
{
    public SensorTrigger sensorTrigger;
    public Animator triggerAnimator;
    public bool isActive;
    public GameObject nextObject;
    public Animator nextCercleBlancAnimator;
    public Animator oldCercleBlancAnimator;

    // Start is called before the first frame update
    void Start()
    {
        triggerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isActive = sensorTrigger.isActive;

        if(isActive)
        {
            StartCoroutine("ActivateTrigger");
        }
    }

    IEnumerator ActivateTrigger()
    {
        triggerAnimator.SetTrigger("deactivate");
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        nextObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        oldCercleBlancAnimator.SetTrigger("off");
        yield return new WaitForSeconds(0.3f);
        nextCercleBlancAnimator.SetTrigger("on");
    }
}
