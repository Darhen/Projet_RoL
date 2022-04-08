using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInstantiate : MonoBehaviour
{
    public GameObject wallPrefab;
    GameObject newWall;
    public GameObject startPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Untagged")
        {
           newWall = Instantiate(wallPrefab, startPos.transform.position, Quaternion.identity);
        }
    }
}
