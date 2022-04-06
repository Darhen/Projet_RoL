using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    CameraFollow cameraFollow;
    public Vector3 walkThroughOffset;
    public bool playerInsideCollider;
    public bool planteSortDuCollider;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        playerInsideCollider = false;
        planteSortDuCollider = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" /*|| other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot"*/)
        {
            playerInsideCollider = true;
        }
/*
        if (other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot")
        {
            planteGrimpanteInsideCollider = true;
        }
*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" /* other.gameObject.tag == "FollowMe" || other.gameObject.tag == "OldRoot"*/)
        {
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
            playerInsideCollider = false;
            planteSortDuCollider = false;
        }
        
        if((other.gameObject.tag == "FollowMe") || (other.gameObject.tag == "OldRoot"))
        {
            planteSortDuCollider = true;
        }
        else
        {
            planteSortDuCollider = false;
        }

    }
    private void Update()
    {
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
