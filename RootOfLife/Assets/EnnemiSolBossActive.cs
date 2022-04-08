using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSolBossActive : MonoBehaviour
{
    public Transform player;
    Animator animatorBossSol;
    public float speed;
    Rigidbody rb;

    void Start()
    {
        speed = 0f;
        rb = this.gameObject.GetComponent<Rigidbody>();
        animatorBossSol = this.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animatorBossSol.enabled = true;
        animatorBossSol.SetBool("IsCharging", true);
        speed = 13f;
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
