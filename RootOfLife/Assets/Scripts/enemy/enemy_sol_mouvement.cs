using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sol_mouvement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;

    private int waypointIndex;
    private float dist;

    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        speed = 5f;
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(dist < 1f)
        {
            IncreaseIndex();
        }
        patrol();
    }

    void patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0; 
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }




    /*
    Vector3 back = new Vector3(35.6f, 5.21f, 0.22f); //assign it whatever value you want one edge of the movement to be
    Vector3 forth = new Vector3(-33.19f, 5.21f, 0.22f); //again, assign whatever the other edge is supposed to be
    float phase = 0;
    float speed = 0.1f; //adjust to anything that results in the speed u want
    float phaseDirection = 1; //this is just to make the code less "ify" =D

    void Update()
    {
        transform.position = Vector3.Lerp(back, forth, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, 
        //so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction

        if (phase >= 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90, 90, 0), 30f * Time.deltaTime);
        }

        if (phase <= 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90, -90, 0), 30f * Time.deltaTime);
        }


    }
    */
}
