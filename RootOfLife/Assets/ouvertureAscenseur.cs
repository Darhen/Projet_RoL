using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouvertureAscenseur : MonoBehaviour
{
    public GameObject porte1;
    public GameObject porte2;
    Animator animator1;
    Animator animator2;
    public bool Activated;

    // Start is called before the first frame update
    void Start()
    {
        animator1 = porte1.GetComponent<Animator>();
        animator2 = porte2.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Activated = true;
            animator1.SetBool("Activated", true);
            animator2.SetBool("Activated", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Activated = false;
            animator1.SetBool("Activated", false);
            animator2.SetBool("Activated", false);
        }
    }
}
