using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerelle : MonoBehaviour
{
    Rigidbody myRb;
    public GameObject stairs;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myRb.isKinematic = false;
            stairs.GetComponent<Rigidbody>().isKinematic = false;
            StartCoroutine("DelaiKinematic");
        }
    }

    IEnumerator DelaiKinematic()
    {
        yield return new WaitForSeconds(3f);
        myRb.isKinematic = true;
        stairs.GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Passerelle>().enabled = false;

    }
}
