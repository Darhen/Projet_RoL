using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBound : MonoBehaviour
{
    public bool leftBoundary;
    public bool rightBoundary;
    public bool topBoundary;
    public Transform cameraBoundaryPosition;
    public Vector3 cameraTarget;
    public bool activeBoundary;
    public CameraFollow cameraFollow;
    public bool xFree;
    public bool yFree;
    public Vector3 extraOffset;
    public GameObject mainCamera;

    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        cameraFollow = mainCamera.GetComponent<CameraFollow>();
        cameraFollow.activeBoundary = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraTarget = cameraBoundaryPosition.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CameraBound")
        {
            cameraFollow.activeBoundary = true;
            //cameraFollow.boundCamPosition = cameraTarget + extraOffset;
            if (cameraFollow.boundCamPosition != cameraTarget + extraOffset)
            {
                cameraFollow.boundCamPosition = Vector3.Lerp(mainCamera.transform.position, cameraTarget + extraOffset, 8f + smooth);
            }
            else
            {
                cameraFollow.boundCamPosition = cameraTarget + extraOffset;
            }
            
            if (xFree)
            {
                cameraFollow.xFree = true;
            }
            if (yFree)
            {
                cameraFollow.yFree = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CameraBound")
        {
            cameraFollow.activeBoundary = false;

            StartCoroutine("SmoothChange");

            if (xFree)
            {
                cameraFollow.xFree = false;
            }
            if (yFree)
            {
                cameraFollow.yFree = false;
            }
        }
    }

    IEnumerator SmoothChange()
    {
        cameraFollow.smoothSpeed = 1.5f;
        yield return new WaitForSeconds(6f);
        cameraFollow.smoothSpeed = 3.5f;
    }
}
