using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger3 : MonoBehaviour
{
    public GameObject player;
    public GameObject nextObject;

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
        nextObject.SetActive(true);
    }
}
