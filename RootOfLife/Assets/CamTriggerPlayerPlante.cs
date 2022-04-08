using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriggerPlayerPlante : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject spawnPos;
    CameraFollow cameraFollow;
    GrowthManager growthManager;
    public Vector3 PlantPlayerOffset;
    public bool playerInsideCollider;
    public bool planteInsideCollider;


    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        cameraFollow.plantPlayerOffset = new Vector3(0, 0, 0);
        growthManager = spawnPos.GetComponent<GrowthManager>();
        playerInsideCollider = false;
        planteInsideCollider = false;
    }
/*
    private void Update()
    {
        if (growthManager.currentCap <= 2)
        {
            cameraFollow.cinematicOffset = new Vector3(0, 0, 0);
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInsideCollider = true;
        }
        if(other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot")
        {
            planteInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInsideCollider = false;
            
        }
       if(other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot")
        {
            Debug.Log("PlanteSort");
            planteInsideCollider = false;
        }
    }

    private void Update()
    { 
        if (planteInsideCollider == true && growthManager.currentCap <= 2)
        {
            planteInsideCollider = false;
        }

        if (playerInsideCollider == true && planteInsideCollider == true)
        {
            cameraFollow.plantPlayerOffset = PlantPlayerOffset;
        }

        if(playerInsideCollider == true && planteInsideCollider == false)
        {
            Debug.Log("activéCollider");
            cameraFollow.plantPlayerOffset = PlantPlayerOffset;
        }

        if(playerInsideCollider == false && planteInsideCollider == true)
        {
            cameraFollow.plantPlayerOffset = PlantPlayerOffset;
        }

        if(playerInsideCollider == false && planteInsideCollider == false)
        {
            cameraFollow.plantPlayerOffset = new Vector3(0, 0, 0);
        }
    }
}
