using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugPlant : MonoBehaviour
{

    public GameObject myPrefab;

    private GameObject myClone;
    public GameObject cloneSac;

    Transform startPos;
    public GameObject spawnPos;

    public GameObject sac;
    public GameObject sacPlug;
    public int count;

    PlayerController playerController;
    private bool plantPlugged;

    private float maxHeigthRay = 1f;

    GrowthManager growthManager;

    TimerPont timerPont;
    GameObject TrampolineParent;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        startPos = spawnPos.GetComponent<Transform>();
        playerController = GetComponentInParent<PlayerController>();

        growthManager = spawnPos.GetComponent<GrowthManager>();
        TrampolineParent = GameObject.Find("TrampolineParent");
        timerPont = TrampolineParent.GetComponent<TimerPont>();
    }

    // Update is called once per frame
    void Update()
    {
        plantPlugged = playerController.plantIsPlugged; // on stock l'information du "pressage de l'input

        RaycastHit hit;
        Ray landingRay = new Ray(spawnPos.transform.position, Vector3.down);

        //if (count <= 0)
        if(plantPlugged)
        {
            if(count <= 0)
            {
                if (Physics.Raycast(landingRay, out hit, maxHeigthRay))
                {
                    if (hit.collider.gameObject.layer == 6) // si le rayon tape le layer "Ground"
                    {
                        sac.SetActive(false);
                        cloneSac = Instantiate(sacPlug, hit.point, startPos.transform.rotation); // créer un sac au sol sur la position de la collision du raycast
                        cloneSac.transform.SetParent(startPos);
                        playerController.enabled = false;
                        SpawnBranch();
                        count++; 
                    }
                }
                else // si le rayon ne tape rien alors on "reset" la situation / Player retrouve ses controls
                {
                    growthManager.playerIsActif = true;
                    playerController.plantIsPlugged = false;

                    // **INSERT ANIMATION DE CANCEL DE POSAGE DE SAC ICI**
                }
            }
            else
            {
                if (growthManager.currentCap > 0)
                {
                    spawnPos.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
                }
            }
                
        }

        if (!plantPlugged && count == 0)
        {
            sac.SetActive(true);
            if(growthManager.currentCap > 0)
            {
                spawnPos.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
            }
            
            /*if(spawnPos.GetComponent<Transform>().childCount > 1)
            {
                spawnPos.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
            }*/
            //sacPlug.SetActive(false);

        }

    }

    void SpawnBranch()
    {
        var offsetBranche = new Vector3(0, 0.5f, 0);
        myClone = Instantiate(myPrefab, cloneSac.transform.position + offsetBranche, Quaternion.identity); //Instantie une "branche" pour la pousse (voir growBehaviour)
        myClone.transform.SetParent(startPos);
        Destroy(spawnPos.GetComponent<Transform>().GetChild(0).gameObject); //détruit l'ancien sac au sol

        if(timerPont.currentCap > 0)
        {
            timerPont.StartCoroutine("DestroyChildren"); // détruit trampoline & branches (s'il y en as)
        }
    }
}
