using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sol_mouvement : MonoBehaviour
{
   /* 
    Vector3 back = new Vector3(35.6f, 5.21f, 0.22f); //assign it whatever value you want one edge of the movement to be
    Vector3 forth = new Vector3(-33.19f, 5.21f, 0.22f); //again, assign whatever the other edge is supposed to be
    float phase = 0;
    float speed = 0.1f; //adjust to anything that results in the speed u want
    float phaseDirection = 1; //this is just to make the code less "ify" =D
    Spin spin;


    private void Start()
    {
        spin = GetComponent<spin>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(back, forth, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, 
        //so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction

        if (phase >=1) 
            { 
            spincode.SetActive(true);
            }

    }
    */
}
