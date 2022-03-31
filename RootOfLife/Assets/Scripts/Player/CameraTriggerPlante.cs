using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerPlante : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject spawnPos;
    CameraFollow cameraFollow;
    GrowthManager growthManager;
    public Vector3 cinematicOffset;


    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        growthManager = spawnPos.GetComponent<GrowthManager>();

    }

    private void Update()
    {
        if(growthManager.currentCap <= 2)
        {
            cameraFollow.cinematicOffset = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot")
        {
            cameraFollow.cinematicOffset = cinematicOffset;
        }

    }

}
