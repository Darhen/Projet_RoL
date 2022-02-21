using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CheckIfInsideBeam_ : MonoBehaviour
{
    public GameObject ball;
    public bool ombre = false;

    void Start()
    {
        ball.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (ombre == true)
        {
            ball.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Beam" && ombre == false)
        {
            ball.SetActive(true);
        }
        if  (other.gameObject.tag == "Ombre")
        {
            ombre = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            ball.SetActive(false);
        }
        if (other.gameObject.tag == "Ombre")
        {
            ombre = false;
        }
    }
}
