using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionLiane : MonoBehaviour
{
    public bool canClimb;

    // Start is called before the first frame update
    void Start()
    {
        canClimb = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimb = true;
            Debug.Log("CollisionLiane");
        }
        else
        {
            canClimb = false;
        }
    }
   
}
