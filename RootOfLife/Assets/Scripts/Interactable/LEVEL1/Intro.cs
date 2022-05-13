using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private Animator animator;
    public GameObject sac;

    private void Awake()
    {
        sac.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("TimerIntro");

        sac.SetActive(false);
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
