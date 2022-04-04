using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger4 : MonoBehaviour
{
    public GameObject player;
    public GameObject nextLight;
    public GameObject wallLights;

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
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        wallLights.SetActive(true);
        yield return new WaitForSeconds(1f);
        nextLight.SetActive(true);
    }
}
