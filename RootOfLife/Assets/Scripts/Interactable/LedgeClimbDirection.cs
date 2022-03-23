using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeClimbDirection : MonoBehaviour
{
    public bool facingRight;
    public bool facingLeft;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            direction = 1;
        }
        if (facingLeft)
        {
            direction = -1;
        }
    }
}
