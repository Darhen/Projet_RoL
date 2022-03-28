using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger1 : MonoBehaviour
{
    public GameObject player;
    public GameObject trigger1;
    public Animator triggerAnimator;

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
            trigger1.SetActive(true);
        }
    }
}
