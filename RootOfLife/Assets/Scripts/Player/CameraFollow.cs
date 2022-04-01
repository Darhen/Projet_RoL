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
    PlugPlant plugPlant;

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

    //camera boundaries
    public bool leftBoundary;
    public bool rightBoundary;
    private GameObject cameraBoundary;
    public bool inWall;
    private Vector3 boundaryPosition;
    private int lastDirection;
    public bool boundary;

    //offset cinematique
    public Vector3 cinematicOffset;
    public Vector3 walkThroughOffset;
    
    private void Start()
    {
        count = 0;
        target = GameObject.FindWithTag("Player");

        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        plane = player.GetComponent<Plane>();

        growthManager = player.GetComponentInChildren<GrowthManager>();
        plugPlant = player.GetComponent<PlugPlant>();

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
            target = player.gameObject;   
        }

        if (count == 1)
        {
            if (growthManager.lastChild.gameObject == null)
            {
                return;
            }
            target = growthManager.lastChild.gameObject;
            //target = plugPlant.cloneSac.gameObject;
        }

        if (growthManager.currentCap <= 2)
        {
            if (!plantPlugged)
            {
                count = 0;
            }
            else
            {
                count = 1;
            }
        }

        /*if (plantPlugged && count == 0)
        {
            if (growthManager.currentCap <= 1)
            {
                count++;
            }
        }*/

        if (count >= 2)
        {
            count = 0;
        }

        //declarer que si la cam est inWall on active le boundary
        if(inWall)
        {
            boundary = true;
        }
        else
        {
            boundary = false;
        }
    }

    private void FixedUpdate()
    {
        if (!boundary)
        {
            Vector3 desiredPosition = target.transform.position + offset + parachuteOffset + slopeOffset + forwardOffset + cinematicOffset + walkThroughOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            if (isGliding)
            {
                parachuteOffset = new Vector3(0, 0, parachuteOffsetZ);
            }
            else
            {
                parachuteOffset = new Vector3(0, 0, 0);
            }

            if (isSliding)
            {
                slopeOffset = new Vector3(0, 0, slopeOffsetZ);
            }
            else
            {
                slopeOffset = new Vector3(0, 0, 0);
            }
        }
        if (boundary)
        {
            if (leftBoundary && xInput <= 0)
            {
                Vector3 desiredPosition = new Vector3(boundaryPosition.x, target.transform.position.y + offset.y, transform.position.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
                transform.position = smoothedPosition;
                
            }
            else
            {
                Vector3 desiredPosition = target.transform.position + offset + parachuteOffset + slopeOffset + forwardOffset + cinematicOffset + walkThroughOffset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
                transform.position = smoothedPosition;

                if (isGliding)
                {
                    parachuteOffset = new Vector3(0, 0, parachuteOffsetZ);
                }
                else
                {
                    parachuteOffset = new Vector3(0, 0, 0);
                }

                if (isSliding)
                {
                    slopeOffset = new Vector3(0, 0, slopeOffsetZ);
                }
                else
                {
                    slopeOffset = new Vector3(0, 0, 0);
                }
            }
            if (rightBoundary && xInput >= 0)
            {
                Vector3 desiredPosition = new Vector3(boundaryPosition.x, target.transform.position.y + offset.y, transform.position.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
                transform.position = smoothedPosition;
            }
            else
            {
                Vector3 desiredPosition = target.transform.position + offset + parachuteOffset + slopeOffset + forwardOffset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
                transform.position = smoothedPosition;

                if (isGliding)
                {
                    parachuteOffset = new Vector3(0, 0, parachuteOffsetZ);
                }
                else
                {
                    parachuteOffset = new Vector3(0, 0, 0);
                }

                if (isSliding)
                {
                    slopeOffset = new Vector3(0, 0, slopeOffsetZ);
                }
                else
                {
                    slopeOffset = new Vector3(0, 0, 0);
                }
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CameraBound")
        {
            cameraBoundary = other.gameObject;
            leftBoundary = cameraBoundary.GetComponent<CameraBound>().leftBoundary;
            rightBoundary = cameraBoundary.GetComponent<CameraBound>().rightBoundary;
            boundaryPosition = other.gameObject.transform.position;
            inWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CameraBound")
        {
            cameraBoundary = null;
            inWall = false;
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