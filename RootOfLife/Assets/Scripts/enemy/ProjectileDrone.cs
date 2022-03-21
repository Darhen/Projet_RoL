using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDrone : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Vector3 target;
    //public Rigidbody projectileDrone;
    //public GameObject drone;
    //public GameObject instantiationPoint;
    //DroneAttaque droneAttaque;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
       
        //Vector3 relativePos = player.position - transform.position;
        //Quaternion.LookRotation(relativePos, Vector3.up);
        
        /*speed = 10f;
        droneAttaque = drone.GetComponent<DroneAttaque>();
        droneAttaque.isShooting = false;*/
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
    }

    void OnTriggerEnter ( Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }

    }
    /*
    void DestroyProjectile()
    {
        
    }
    */
}
