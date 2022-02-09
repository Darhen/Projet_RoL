using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public bool canClimb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        canClimb = true;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canClimb)
        {
            if (Input.GetAxis("Vertical")>0)
            {
                player.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                player.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
