using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    CameraFollow cameraFollow;
    public Vector3 walkThroughOffset;


    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" /*|| other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot"*/)
        {
            cameraFollow.walkThroughOffset = walkThroughOffset;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" /* other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot"*/)
        {
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
        }

    }
}
