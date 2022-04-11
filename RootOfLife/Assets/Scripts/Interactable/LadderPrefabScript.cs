using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPrefabScript : MonoBehaviour
{
    public bool facingLeft;
    public bool facingRight;
    public int ladderDirection;

    // Start is called before the first frame update
    void Start()
    {
        if (facingLeft)
        {
            ladderDirection = 1;
        }
        if (facingRight)
        {
            ladderDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
