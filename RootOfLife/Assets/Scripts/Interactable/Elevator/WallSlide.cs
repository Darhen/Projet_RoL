using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public GameObject walls;
    public GameObject startPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Untagged")
        {
            Instantiate(walls, startPos.transform.position, Quaternion.identity);
        }
    }
}
