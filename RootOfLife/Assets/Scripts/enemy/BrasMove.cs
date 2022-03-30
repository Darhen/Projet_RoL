using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasMove : MonoBehaviour
{

    public Transform target1;
    public float speed = 10;
    public bool isMoving;

    Animator MyAnim;

    private void Start()
    {
        MyAnim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            MyAnim.enabled = false;
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target1.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target1.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                transform.position = target1.transform.position;
                MyAnim.enabled = true;
                isMoving = false;
            }
        }
    }
}
