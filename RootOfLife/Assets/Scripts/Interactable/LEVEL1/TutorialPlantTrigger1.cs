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
            isActive = false;
        }
    }

    IEnumerator ActivateTrigger()
    {
        triggerAnimator.SetTrigger("deactivate");
        yield return new WaitForSeconds(2f);
        nextObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
