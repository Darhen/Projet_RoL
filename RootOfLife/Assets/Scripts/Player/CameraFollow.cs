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
    SlopeDetector slopeDetector;
    GameObject player;
    private bool plantPlugged;

    //Script du sac/plante
    GrowthManager growthManager;

    //script du parachute
    Plane plane;
    public bool isGliding;
    public Vector3 parachuteOffset;
    public int parachuteOffsetZ;
    public Vector3 slopeOffset;
    public int slopeOffsetZ;
    public bool isSliding;

    //offset de direction
    public int direction;
    public Vector3 xOffset;
    private Vector3 forwardOffset;
    private float xInput;
    PlayerClimbing playerClimbing;
    public bool isClimbing;

    
    private void Start()
    {
        count = 0;
        target = GameObject.FindWithTag("Player");

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        plane = player.GetComponent<Plane>();
        growthManager = player.GetComponentInChildren<GrowthManager>();
        slopeDetector = player.GetComponent<SlopeDetector>();

        //commencer le niveau avec le offset vers la droite
        direction = 1;
        playerClimbing = player.GetComponent<PlayerClimbing>();
    }


    private void Update()
    {
        //calcul du forward
        xInput = playerController.xInput;
        if(xInput > 0)
        {
            direction = 1;
        }
        if(xInput < 0)
        {
            direction = -1;
        }
        
        //actualiser le forward selon la direction----------

        //annulation du offset en X si climbing
        isClimbing = playerClimbing.isClimbing;
        if(isClimbing)
        {
            forwardOffset = new Vector3 (0, 0, 0);
        }
        else
        {
            forwardOffset = xOffset * direction;
        }

        //--------------------------------------------------

        plantPlugged = playerController.plantIsPlugged;

        isSliding = slopeDetector.sliding;
        isGliding = plane.isGliding;

        if (count == 0)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (count == 1)
        {
            if (growthManager.currentCap >= 1)
            {
                target = growthManager.lastChild.gameObject;
            }
            if (growthManager.currentCap < 1)
            {
                target = GameObject.FindWithTag("Player");
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

        Vector3 desiredPosition = target.transform.position + offset + parachuteOffset + slopeOffset + forwardOffset;
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

        if(isSliding)
        {
            slopeOffset = new Vector3(0, 0, slopeOffsetZ);
        }
        else
        {
            slopeOffset = new Vector3(0, 0, 0);
        }
    }
}