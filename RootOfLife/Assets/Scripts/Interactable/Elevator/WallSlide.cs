using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    GameObject target;
    public float speed;

    private void Awake()
    {
        speed = 15f;
        target = GameObject.Find("WallTarget");
    }
    private void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
