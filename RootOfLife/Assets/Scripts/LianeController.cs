using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeController : MonoBehaviour
{
    public bool canClimb;
    public Vector3 activeSectionPosition;
    public GameObject activeSection;
    

    public Rigidbody rb;
    private HingeJoint hj;

    public float pushForce = 10f;

    public bool attached = false;

    public float yInput;
    public float xInput;
    public bool movingUp;
    public bool movingDown;
    public GameObject upTarget;
    public GameObject bottomTarget;

    public Transform rayCastOrigin;

    public float speed;
    public bool jumpQueued;

    PlayerController playerController;
    public GameObject triggerActiveSection;
    CollisionLiane collisionLiane;
    

    public bool isClimbing;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        hj = gameObject.GetComponent<HingeJoint>();

        speed = 5f;

        playerController = GetComponent<PlayerController>();
        collisionLiane = triggerActiveSection.GetComponent<CollisionLiane>();


    }

    // Update is called once per frame
    void Update()
    {
        //le raycast verifie avec quel section de la liane le joueur est en ligne
        InteractRaycast();
        activeSection = collisionLiane.activeSection;
        activeSectionPosition = collisionLiane.activeSectionPosition;
        

        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
        if (yInput < 0)
        {
            movingUp = false;
            movingDown = true;
        }
        if (yInput > 0)
        {
            movingUp = true;
            movingDown = false;
        }
        if (yInput == 0)
        {
            movingUp = false;
            movingDown = false;
        }
        
        if(isClimbing)
        {
            upTarget = activeSection.transform.GetChild(1).gameObject;
            bottomTarget = activeSection.transform.GetChild(2).gameObject;
        }

        else
        {
            upTarget = null;
            bottomTarget = null;
        }

        
        

        if(canClimb)
        {
                if (Input.GetButtonDown("Fire3"))
                    {
                        rb.transform.position = new Vector3(activeSectionPosition.x, rb.transform.position.y, activeSectionPosition.z);
                    }

                if (Input.GetButton("Fire3"))
                {
                    GetComponent<PlayerController>().enabled = false;
                    isClimbing = true;
                //rb.transform.position = new Vector3 (activeSectionPosition.x, rb.transform.position.y, activeSectionPosition.z);
               

                if (Input.GetButtonDown("Jump"))
                        {
                            jumpQueued = true;
                            rb.velocity = new Vector3(transform.position.x * xInput, transform.position.y *2, 0);
                            rb.useGravity = true;
                            GetComponent<PlayerController>().fallMultiplier = 5;
                            Debug.Log("j'ai jump");
                            GetComponent<PlayerController>().enabled = true;
                            GetComponent<LianeController>().enabled = false;
                

                        }

                }
                if (Input.GetButtonUp("Fire3"))
                {
                    GetComponent<PlayerController>().enabled = true;
                    jumpQueued = false;
                    GetComponent<PlayerController>().fallMultiplier = 5;
                    rb.useGravity = true;
                }
        }
        
    }

    private void FixedUpdate()
    {
        if(canClimb)
        {
            if (Input.GetButton("Fire3"))
            {
                rb.useGravity = false;
                isClimbing = true;
                

                if (movingUp)
                {
                transform.position = Vector3.MoveTowards(transform.position, upTarget.transform.position, yInput * Time.deltaTime * speed);

                }
                if (movingDown)
                {
                    transform.position = Vector3.MoveTowards(transform.position, upTarget.transform.position, yInput * Time.deltaTime * speed);
                }
            }
           else
            {
                rb.useGravity = true;
            }
            if (jumpQueued)
            {
                jumpQueued = false;
                rb.useGravity = true; 
            }
        }

    }

    

  

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Ladder")
        {
            canClimb = true;
        }
        
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ladder")
        {
            canClimb = false;
        }
    }


    void InteractRaycast()
    {/*
        Ray ray = new Ray(rayCastOrigin.position, transform.right);
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 5.0f);

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            activeSectionPosition = hit.transform.gameObject.GetComponent<Transform>().position;
            activeSection = hit.transform.gameObject;
            //Debug.Log(hit.transform.gameObject.name);
        }
        else
        {
            //activeSectionPosition = new Vector3 (0, 0, 0);
            activeSection = null;
            //Debug.Log(hit.transform.gameObject.name);
        }
        */
    }
  
}
