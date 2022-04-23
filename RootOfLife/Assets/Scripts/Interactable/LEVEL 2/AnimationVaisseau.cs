using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationVaisseau : MonoBehaviour
{
    public GameObject vaisseau;
    public GameObject sable;

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
        if (other.gameObject.tag == "Player")
        {
            vaisseau.SetActive(true);
            sable.SetActive(true);
        }
    }
}
