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
    public bool moving;
    public GameObject upTarget;

    public Transform rayCastOrigin;

    public float speed;
    public bool jumpQueued;

    PlayerController playerController;
    
   

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        hj = gameObject.GetComponent<HingeJoint>();

        speed = 5f;

        playerController = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //le raycast verifie avec quel section de la liane le joueur est en ligne
        InteractRaycast();

        

        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
        if (yInput != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        

        upTarget = activeSection.transform.GetChild(1).gameObject;

        if (upTarget == null)
        {
            return;
        }

        
        if (Input.GetButton("Fire3"))
        {
            GetComponent<PlayerController>().enabled = false;
            
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

    private void FixedUpdate()
    {
        if(canClimb)
        {
            if (Input.GetButton("Fire3"))
            {
                rb.useGravity = false;

                if (moving)
                {
                // GetComponent<Transform>().position = new Vector3(activeSectionPosition.x, activeSectionPosition.y * yInput ,activeSectionPosition.z) * Time.deltaTime;
                //rb.velocity = new Vector3(activeSectionPosition.x, activeSectionPosition.y + yInput * Time.deltaTime, activeSectionPosition.z) ;
                transform.position = Vector3.MoveTowards(transform.position, upTarget.transform.position, yInput * Time.deltaTime * speed);
                GetComponent<PlayerController>().fallMultiplier = 0;

                }

            }
           else
            {
                rb.useGravity = true;
                GetComponent<PlayerController>().fallMultiplier = 5;
                //GetComponent<PlayerController>().enabled = true;
            }
            if (jumpQueued)
            {
                //rb.velocity = new Vector3(transform.position.x * xInput, transform.position.y * 20 * yInput, 0);
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
    {
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
            activeSectionPosition = new Vector3 (0, 0, 0);
            activeSection = null;
            //Debug.Log(hit.transform.gameObject.name);
        }

    }
  
}
