using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeController : MonoBehaviour
{
    public bool canClimb;
    public GameObject activeSection;
   

    // Start is called before the first frame update
    void Start()
    {
        //Collider servant a autoriser le grab avec la liane
        
    }

    // Update is called once per frame
    void Update()
    {
        //le raycast verifie avec quel section de la liane le joueur est en ligne
        InteractRaycast();


    }

    void InteractRaycast()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 5.0f);

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
           // Debug.Log(hit.transform.gameObject.name);
        }
        
    }

}
