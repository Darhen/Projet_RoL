using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingLiane : MonoBehaviour
{
    public GameObject triggerActiveSection;
    CollisionLiane collisionLiane;
    public GameObject activeSection;
    PlayerController playerController;
    Rigidbody rb;
    Transform activeSectionPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        collisionLiane = triggerActiveSection.GetComponent<CollisionLiane>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        activeSectionPosition = collisionLiane.activeSectionPosition;
    }

    // Update is called once per frame
    void Update()
    {
        activeSection = collisionLiane.activeSection;
        if (activeSection != null)
        {
            if (Input.GetButton("Fire3"))
            {
                transform.parent = activeSection.transform;
                //activeSectionPosition = GetComponentInParent<Transform>().position;
                transform.position = Vector3.MoveTowards(transform.position, activeSectionPosition.position, 10f);
                playerController.fallMultiplier = 0;
                rb.velocity = new Vector3(0, 0, 0);
                playerController.isMoving = false;
            }
             else
                {
                playerController.isMoving = true;
                playerController.fallMultiplier = 5;
                return;
                }
        }
        
    }

    
}
