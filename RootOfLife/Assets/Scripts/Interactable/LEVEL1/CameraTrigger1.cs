using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger1 : MonoBehaviour
{
    public GameObject mainCamera;
    CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cameraFollow.cinematicOffset = new Vector3(0, 0, -7f);
        }
    }
}
