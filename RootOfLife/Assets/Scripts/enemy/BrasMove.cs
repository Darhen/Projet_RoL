using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasMove : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    public Transform target3;

    public float speed = 10;
    public bool isMoving;

    public int movedTimes;
    Animator MyAnim;

    private void Start()
    {
        MyAnim = GetComponentInChildren<Animator>();

        movedTimes = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MyAnim.enabled = false;
            float step = speed * Time.deltaTime; // calculate distance to move

            if (movedTimes == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, target1.position, step);
                if (Vector3.Distance(transform.position, target1.position) < 0.001f)  // Check if the position of the cube and sphere are approximately equal.
                {
                    transform.position = target1.transform.position;
                    MyAnim.enabled = true;
                    isMoving = false;
                    movedTimes++;
                }
            }

            if (movedTimes == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
                if (Vector3.Distance(transform.position, target2.position) < 0.001f)  
                {
                    transform.position = target2.transform.position;
                    movedTimes++;
                }
            }

            if(movedTimes == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, target3.position, step);
                if (Vector3.Distance(transform.position, target2.position) < 0.001f)  
                {
                    transform.position = target3.transform.position;
                    MyAnim.enabled = true;
                    isMoving = false;
                    movedTimes++;
                }
            }
        }
    }
}
