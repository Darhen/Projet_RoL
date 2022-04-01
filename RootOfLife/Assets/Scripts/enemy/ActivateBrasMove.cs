using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBrasMove : MonoBehaviour
{

    BrasMove brasMove;
    public GameObject bras;


    void Start()
    {
        brasMove = bras.GetComponent<BrasMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (brasMove.transform.position == brasMove.target1.transform.position)
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            brasMove.isMoving = true;
            Destroy(this.gameObject);
        }
    }
}
