using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugPlant : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject spawnPos;
    public GameObject sac;
    public GameObject sacPlug;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.GetComponent<PlayerController>().enabled = false;
            SpawnBranch();
        }
    }

    void SpawnBranch()
    {
        Instantiate(myPrefab, spawnPos.transform.position, Quaternion.identity);
        sac.SetActive(false);
        sacPlug.SetActive(true);
    }
}
