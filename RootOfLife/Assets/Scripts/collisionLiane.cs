using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLiane : MonoBehaviour
{
    public Vector3 activeSectionPosition;
    public GameObject activeSection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            activeSectionPosition = other.gameObject.GetComponent<Transform>().position;
            activeSection = other.transform.gameObject;
        }
    }
}
