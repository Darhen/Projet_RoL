using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target;

    public float smoothSpeed = 3.5f;
    public Vector3 offset;
    public int count;

    PlayerController playerController;
    GameObject player;
    private bool plantPlugged;

    private void Start()
    {
        count = 0;
        target = GameObject.FindWithTag("Player");

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        plantPlugged = playerController.plantIsPlugged;

        if (count == 0)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (count == 1)
        {
            target = GameObject.FindWithTag("FollowMe");

            if(target == null)
            {
                count++;
            }
        }

        if (plantPlugged && count == 0)
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