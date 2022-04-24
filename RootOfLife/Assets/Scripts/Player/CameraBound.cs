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
        if (other.tag == "Player")
        {
            cameraFollow.activeBoundary = true;
            //cameraFollow.boundCamPosition = cameraTarget + extraOffset;
            cameraFollow.boundCamPosition = Vector3.Lerp(mainCamera.transform.position, cameraTarget + extraOffset, 8f);
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
        if (other.tag == "Player")
        {
            cameraFollow.activeBoundary = false;
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
}
