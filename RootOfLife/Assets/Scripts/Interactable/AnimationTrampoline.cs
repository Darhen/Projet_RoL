using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrampoline : MonoBehaviour
{
    Trampoline trampoline;
    public GameObject player;
    public Animator animatorTrampoline;

    // Start is called before the first frame update
    void Start()
    {
        animatorTrampoline = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            trampoline = player.GetComponent<Trampoline>();
            if(trampoline.bounce == true)
            {
                animatorTrampoline.SetTrigger("Bounce");
            }
        }
    }
}
