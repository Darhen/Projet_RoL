using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("TimerIntro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimerIntro()
    {
        yield return new WaitForSeconds(3.5f);
        animator.enabled = false;
    }
}
