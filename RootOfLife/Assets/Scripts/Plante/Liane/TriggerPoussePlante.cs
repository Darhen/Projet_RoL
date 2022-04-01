using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoussePlante : MonoBehaviour
{
    GrowthManager growthManager;
    public int maxCap;
    public GameObject spawnPos;

    private void Start()
    {
        growthManager = spawnPos.GetComponent<GrowthManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Peut pousser plus long");
            growthManager.maxCap = maxCap;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            growthManager.maxCap = 35;
        }
    }
}
