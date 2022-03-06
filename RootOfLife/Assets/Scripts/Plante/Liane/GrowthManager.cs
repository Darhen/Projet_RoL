using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{

    public int maxCap = 12;
    public int currentCap;

    public GameObject pont;

    Transform lastChild;
    GrowBehaviour growthBehaviour;

    CameraFollow cameraFollow;
    GameObject cam;

    PlugPlant plugPlant;
    PlayerController playerController;

    public bool cr_Running;

    private void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera");
        cameraFollow = cam.GetComponent<CameraFollow>();

        plugPlant = GetComponentInParent<PlugPlant>();

        playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
    {
        currentCap = this.gameObject.transform.childCount;
        lastChild = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1);
        growthBehaviour = lastChild.GetComponentInChildren<GrowBehaviour>();
         
        if (currentCap >= maxCap)
        {
            growthBehaviour.canClone = false;
            //Chope le dernier child et désactive son script et le détag.
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine("DestroyRoots");
            //Lance une coroutine de destruction de child
        }

        if (currentCap >= maxCap)
        {
            StartCoroutine("DestroyRoots");
            SpawnPont();
        }

        if (currentCap == 1)
        {
            StopCoroutine("DestroyRoots");
            cr_Running = false;
            playerController.enabled = true;
            plugPlant.count = 0;
            plugPlant.sacPlug.tag = "Untagged";
            //Quand le bool est strictement égale à 1 on stop la coroutine (SacPlug est le 1er enfant de l'objet et on ne veut pas le détruire)
        }

        if(cr_Running)
        {
            lastChild.tag = "FollowMe";
        }
    }

    //Coroutine de destruction de child
    //Prend le dernier child (le + récent) et le détruit, puis au bout de 0.1 sec détruit le prochain child
    IEnumerator DestroyRoots()
    {
        cr_Running = true;
        playerController.plantIsPlugged = false; // on repasse en false le bool pour permettre la "repose" de la plante

        Destroy(lastChild.gameObject);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            //lastChild.gameObject.tag = "FollowMe";
            Destroy(lastChild.gameObject);
        }
    }

    public void OnCollisionEnterChild(Collision other)
    {
        StartCoroutine("DestroyRoots");
    }

    private void SpawnPont()
    {
        Instantiate(pont, lastChild.transform.position, Quaternion.identity);
        
    }
}