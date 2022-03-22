using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDrone : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Vector3 target;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
    }

    void OnTriggerEnter ( Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }

    }

}
