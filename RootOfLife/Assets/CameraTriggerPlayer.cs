using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject spawnPos;
    CameraFollow cameraFollow;
    GrowthManager growthManager;
    public Vector3 walkThroughOffset;
    public bool playerInsideCollider;
    public bool planteSortDuCollider;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        growthManager = spawnPos.GetComponent<GrowthManager>();
        playerInsideCollider = false;
        planteSortDuCollider = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
            playerInsideCollider = false;
            if(planteSortDuCollider == true)
            {
                planteSortDuCollider = false;
            }
            
        }
        
        if((other.gameObject.tag == "FollowMe") || (other.gameObject.tag == "OldRoot"))
        {
            Debug.Log("Sort");
            planteSortDuCollider = true;
        }

    }
    private void Update()
    {
        if (growthManager.currentCap <= 2)
        {
            planteSortDuCollider = false;
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
        }

        if (playerInsideCollider == true)
        {
            cameraFollow.walkThroughOffset = walkThroughOffset;
        }

        if (planteSortDuCollider == true && playerInsideCollider == true)
        {
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
        }

    }
}
