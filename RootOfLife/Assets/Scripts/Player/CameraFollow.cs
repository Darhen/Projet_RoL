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
    private int lastDirection;

    
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
            StartCoroutine("CheckDirectionChange");
        }
        if(xInput < 0)
        {
            direction = -1;
            StartCoroutine("CheckDirectionChange");
        }
        if (direction != lastDirection)
        {
            StartCoroutine("XOffsetSmooth");
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
            target = GameObject.FindWithTag("FollowMe");

            if(GameObject.FindWithTag("FollowMe") == null)
            {
                count++;
            }
        }

        if (plantPlugged && count == 0)
        {
            if (growthManager.currentCap == 1)
            {
                count++;
            }
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
    
    IEnumerator CheckDirectionChange()
    {
        yield return new WaitForSeconds(0.5f);
        lastDirection = direction;
    }
    
    IEnumerator XOffsetSmooth()
    {
        smoothSpeed = 2f;
        yield return new WaitForSeconds(0.3f);
        smoothSpeed = 2.8f;
        yield return new WaitForSeconds(0.4f);
        smoothSpeed = 3.5f;
    }
    
}