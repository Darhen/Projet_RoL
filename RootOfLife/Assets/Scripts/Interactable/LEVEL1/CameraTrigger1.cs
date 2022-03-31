using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger1 : MonoBehaviour
{
    public GameObject mainCamera;
    CameraFollow cameraFollow;
    public Vector3 cinematicOffset;
    public bool activeCinematique;
    public float cinematicDuration;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        cameraFollow = mainCamera.GetComponent<CameraFollow>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && activeCinematique)
        {
            StartCoroutine("Cinematique");
        }
        if (other.gameObject.tag == "Player" && !activeCinematique)
        {
            cameraFollow.cinematicOffset = cinematicOffset;
        }
    }

    IEnumerator Cinematique()
    {
        cameraFollow.cinematicOffset = cinematicOffset;
        playerController.enabled = false;
        yield return new WaitForSeconds(cinematicDuration);
        cinematicOffset = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        playerController.enabled = true;
    }
}
