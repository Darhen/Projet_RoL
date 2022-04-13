using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksOff : MonoBehaviour
{
    public GameObject Sparks;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Pont")
        {
            Sparks.SetActive(false);
        }
    }
}
