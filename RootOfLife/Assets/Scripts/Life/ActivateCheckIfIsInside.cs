using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckIfIsInside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<NewCheckIfIsInsideBeam>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
