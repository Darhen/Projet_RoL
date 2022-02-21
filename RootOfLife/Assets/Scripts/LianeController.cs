using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeController : MonoBehaviour
{
    public bool canClimb;
    public Vector3 activeSection;

    public Rigidbody rb;
    private HingeJoint hj;

    public float pushForce = 10f;

    public bool attached = false;
    
   

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        hj = gameObject.GetComponent<HingeJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //le raycast verifie avec quel section de la liane le joueur est en ligne
        InteractRaycast();
       

    }

    private void FixedUpdate()
    {
        
    }

    

  

    void OnTriggerEnter(Collider collider)
    {/*
       if(!attached)
        {
            if(collider.gameObject.tag == "Ladder")
            {
                if(attachedTo != collider.gameObject.transform.parent.gameObject != disregard)
                {
                    Attach(collider.gameObject.GetComponent<Rigidbody>());
                }
            }
        }*/
    }


    void InteractRaycast()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 5.0f);

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            hit.transform.gameObject.GetComponent<Transform>().position = activeSection;
           // Debug.Log(hit.transform.gameObject.name);
        }
        
    }
  
}
