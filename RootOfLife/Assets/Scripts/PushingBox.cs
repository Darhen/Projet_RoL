using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBox : MonoBehaviour
{

    public Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.animator.SetBool("pushing", true);
        
    }

    private void OnCollisionExit(Collision collision)
    {
        this.animator.SetBool("pushing", false);
        
    }

}
