using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCube : MonoBehaviour
{
    public GameObject box;
    public Vector3 offsetBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = box.transform.position + offsetBox;
    }
}
