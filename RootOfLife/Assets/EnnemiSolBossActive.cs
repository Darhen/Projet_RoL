using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSolBossActive : MonoBehaviour
{
    public Transform player;
    Animator animatorBossSol;
    public float speed;
    Rigidbody rb;
    public bool isMoving;
    public bool isCollided;
    RespawnMerged respawn;

    void Start()
    {
        speed = 0f;
        rb = this.gameObject.GetComponent<Rigidbody>();
        animatorBossSol = this.gameObject.GetComponent<Animator>();
        isMoving = true;
        respawn = GameObject.FindWithTag("Player").GetComponent<RespawnMerged>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true && isCollided == false)
        {
            animatorBossSol.enabled = true;
            animatorBossSol.SetBool("IsCharging", true);
            speed = 14f;
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //rb.velocity = Vector3.forward * speed;
        }

        if (isMoving == true && isCollided == true)
        {
            speed = 0f;
        }

        if (isMoving == false)
        {
            speed = 0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mur")
        {
            isCollided = true;
        }
        /*else
        {
            isCollided = false;
            isMoving = true;
        }*/
    }

}
