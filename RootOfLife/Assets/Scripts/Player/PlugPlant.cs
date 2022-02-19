using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugPlant : MonoBehaviour
{

    public GameObject myPrefab;
    private GameObject myClone;
    Transform startPos;
    public GameObject spawnPos;
    public GameObject sac;
    public GameObject sacPlug;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        startPos = spawnPos.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


        if (count == 0)
        {
            sac.SetActive(true);
            sacPlug.SetActive(false);

            if (Input.GetKeyDown(KeyCode.G))
            {
                gameObject.GetComponent<PlayerController>().enabled = false;
                SpawnBranch();
                count++;
            }
        }
    }

    void SpawnBranch()
    {
        myClone = Instantiate(myPrefab, spawnPos.transform.position, Quaternion.identity);
        myClone.transform.SetParent(startPos);
        sac.SetActive(false);
        sacPlug.SetActive(true);
    }
}
