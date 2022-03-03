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

    //script du parachute
    Plane plane;
    public bool isGliding;
    public Vector3 parachuteOffset;
    public int parachuteOffsetZ;

    private void Start()
    {
        count = 0;
        target = GameObject.FindWithTag("Player");

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        plane = player.GetComponent<Plane>();

    }

    private void Update()
    {
        plantPlugged = playerController.plantIsPlugged;

        isGliding = plane.isGliding;

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
        Vector3 desiredPosition = target.transform.position + offset + parachuteOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if(isGliding)
        {
            parachuteOffset = new Vector3(0, 0, parachuteOffsetZ);
        }
        else
        {
            parachuteOffset = new Vector3(0, 0, 0);
        }
    }
}