using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrampoline : MonoBehaviour
{
    PlayerController playerController;
    Trampoline trampoline;

    public bool canBounce;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        trampoline = GetComponent<Trampoline>();
        playerController = GetComponent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trampoline.canBounce = true;
            canBounce = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trampoline.canBounce = false;
            canBounce = false;
        }
    }
}
