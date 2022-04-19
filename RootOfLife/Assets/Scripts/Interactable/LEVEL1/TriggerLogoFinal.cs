using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLogoFinal : MonoBehaviour
{
    public GameObject sprite;
    public Animator gateAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sprite.SetActive(true);
            gateAnimator.SetTrigger("close");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
