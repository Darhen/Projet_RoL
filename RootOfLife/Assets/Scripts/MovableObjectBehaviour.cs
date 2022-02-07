using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public bool playerTouching;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
            playerTouching = true;
            StartCoroutine("Timeleft");
        }
        else
        {
            playerTouching = false;
        }
    }

    IEnumerator Timeleft()
    {
        yield return new WaitForSeconds(1f);
        if (!playerTouching)
        {
            rb.isKinematic = true;
            StopCoroutine("Timeleft");
        }
        else

            StopCoroutine("Timeleft");

    }
    
}
