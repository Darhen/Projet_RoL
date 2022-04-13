using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFall_ : MonoBehaviour
{

    public bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        isFalling = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnnemiGround")
        {
            isFalling = true;
        }
    }
}
