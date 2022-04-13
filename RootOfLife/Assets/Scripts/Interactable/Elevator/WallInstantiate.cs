using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInstantiate : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject world;
    public GameObject ElevatorLight;

    public GameObject ElevatorEmissive;
    public Material Emissive1;
    public Material Emissive2;

    GameObject newWall;
    public GameObject startPos;
    public int count;

    private void Start()
    {
        ElevatorEmissive.GetComponent<MeshRenderer>().material = Emissive1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count < 3)
        {
            if (other.gameObject.tag == "Untagged")
            {
                newWall = Instantiate(wallPrefab, startPos.transform.position, Quaternion.identity);
                newWall.transform.SetParent(this.gameObject.transform);
                count++;
            }
        }
        else
        {
            world.GetComponent<WallSlide>().enabled = true;
            StartCoroutine("OffLamp");
        }
    }
    IEnumerator OffLamp()
    {
        yield return new WaitForSeconds(4f);
        ElevatorLight.SetActive(false);
        ElevatorEmissive.GetComponent<MeshRenderer>().material = Emissive2;
    }
}
