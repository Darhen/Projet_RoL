using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLogoFinal : MonoBehaviour
{
    public GameObject sprite;
    public GameObject sprite2;
    public GameObject sprite3;
    public GameObject sprite4;
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
            sprite2.SetActive(true);
            sprite3.SetActive(true);
            sprite4.SetActive(true);
            gateAnimator.SetTrigger("close");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
