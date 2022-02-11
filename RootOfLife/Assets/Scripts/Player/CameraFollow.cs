using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target;

    public float smoothSpeed = 3.5f;
    public Vector3 offset;
    private int count;

    private void Start()
    {
        count = 0;
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (count == 0)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (count == 1)
        {
            target = GameObject.FindWithTag("FollowMe");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            count++;
        }

        if (count >= 2)
        {
            count = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}