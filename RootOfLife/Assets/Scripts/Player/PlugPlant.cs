using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugPlant : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject spawnPos;
    public GameObject sac;
    public GameObject sacPlug;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && count == 0)
        {
            gameObject.GetComponent<PlayerController>().enabled = false;
            SpawnBranch();
            count++;
        }
    }

    void SpawnBranch()
    {
        Instantiate(myPrefab, spawnPos.transform.position, Quaternion.identity);
        sac.SetActive(false);
        sacPlug.SetActive(true);
    }
}
