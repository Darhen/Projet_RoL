using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSac : MonoBehaviour
{
    public GameObject sacProp;
    public GameObject sacPlayer;

    public PlugPlant plugplant;
    public Plane plane;
    public GrowthManager growthManager;


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
            sacProp.SetActive(false);
            sacPlayer.SetActive(true);
            plugplant.enabled = true;
            plane.enabled = true;
            growthManager.enabled = true;
        }
    }
}
