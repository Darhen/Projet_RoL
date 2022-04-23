using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2CameraTriggers : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public CameraFollow cameraFollow;

    public bool passage1;
    public bool xModif;
    public bool yModif;
    public bool zModif;

    public float xNewOffset;
    public float yNewOffset;
    public float zNewOffset;

    public float xRotate;

    public Vector3 initialOffset;
    public Vector3 newOffset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
        cameraFollow = mainCamera.GetComponent<CameraFollow>();
        initialOffset = cameraFollow.offset;
        newOffset = new Vector3(xNewOffset, yNewOffset, zNewOffset);

        if (xModif == false)
        {
            xNewOffset = initialOffset.x;
        }
        if (yModif == false)
        {
            yNewOffset = initialOffset.y;
        }
        if (zModif == false)
        {
            zNewOffset = initialOffset.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (passage1 == false)
            {
                initialOffset = cameraFollow.offset;
                StartCoroutine("ChangementCamOffset");
            }
            if (passage1 == true)
            {
                StartCoroutine("RetourInitialCamOffset");
            }
        }
    }

    IEnumerator ChangementCamOffset()
    {
        cameraFollow.offset = Vector3.Lerp(initialOffset, newOffset, 6f);
        mainCamera.transform.Rotate(xRotate * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        yield return new WaitForSeconds(6f);
        passage1 = true;
    }
    IEnumerator RetourInitialCamOffset()
    {
        cameraFollow.offset = Vector3.Lerp(cameraFollow.offset, initialOffset, 6f);
        yield return new WaitForSeconds(6f);
        passage1 = false;
    }
}
