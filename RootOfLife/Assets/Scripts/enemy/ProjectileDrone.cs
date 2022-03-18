using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDrone : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector3 target;
    public bool isThrowing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);

        isThrowing = false;
    }

    void Update()
    {
        
    }
}
