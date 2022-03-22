using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugPlant : MonoBehaviour
{

    public GameObject myPrefab;
    private GameObject myClone;
    private GameObject cloneSac;
    Transform startPos;
    public GameObject spawnPos;
    public GameObject sac;
    public GameObject sacPlug;
    public int count;

    PlayerController playerController;
    private bool plantPlugged;

    private float maxHeigthRay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        startPos = spawnPos.GetComponent<Transform>();
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        plantPlugged = playerController.plantIsPlugged;

        RaycastHit hit;
        Ray landingRay = new Ray(spawnPos.transform.position, Vector3.down);


        if (count == 0)
        {
            sac.SetActive(true);
            sacPlug.SetActive(false);
            if(Physics.Raycast(landingRay, out hit, maxHeigthRay))
            {
                if (hit.collider == null)
                {
                    return;
                }

                if (hit.collider.gameObject.layer == 6)
                {
                    if(plantPlugged)
                    {
                        cloneSac = Instantiate(sacPlug, hit.point, startPos.transform.rotation);
                        cloneSac.transform.SetParent(startPos);
                        playerController.enabled = false;
                        SpawnBranch();
                        count++;
                    }
                }
            }
        }
    }

    void SpawnBranch()
    {
        myClone = Instantiate(myPrefab, spawnPos.transform.position, Quaternion.identity);
        myClone.transform.SetParent(startPos);
        sac.SetActive(false);
        Destroy(GameObject.FindWithTag("Trampoline"));
    }
}
