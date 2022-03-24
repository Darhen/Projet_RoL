using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{

    public int maxCap = 12;
    public int currentCap;

    public GameObject pont;

    public Transform lastChild;
    GrowBehaviour growthBehaviour;

    PlugPlant plugPlant;
    PlayerController playerController;

    public bool cr_Running;
    public bool playerIsActif;

    private void Awake()
    {

        plugPlant = GetComponentInParent<PlugPlant>();

        playerController = GetComponentInParent<PlayerController>();
        playerIsActif = false;
    }
    private void Update()
    {
        currentCap = this.gameObject.transform.childCount;// on stock le nb d'enfants de l'objet dans l'int

        if (currentCap > 0) // "Filtre" pour éviter les erreurs quand l'objet n'a pas d'enfants
        {
            lastChild = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1); // stock l'info de l'enfant le + récent

            growthBehaviour = lastChild.GetComponentInChildren<GrowBehaviour>(); // on get le script du dernier enfant
        }

        
         
        if (currentCap >= maxCap)
        {
            growthBehaviour.canClone = false; 
            //Chope le dernier child et désactive son script et le détag.
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (currentCap > 1)
            {
                StartCoroutine("DestroyRoots");
            }
            //Lance une coroutine de destruction de child
        }

        if (currentCap >= maxCap)
        {
            StartCoroutine("DestroyRoots");
            SpawnPont();
        }

        if (currentCap <= 1)
        {
            StopCoroutine("DestroyRoots");
            cr_Running = false;
            plugPlant.count = 0;
            //Quand le bool est strictement égale à 1 on stop la coroutine (SacPlug est le 1er enfant de l'objet et on ne veut pas le détruire)
            if (playerIsActif)
            {
                playerController.enabled = true;
                playerIsActif = false;
            }
        }

        if(cr_Running)
        {
            lastChild.tag = "FollowMe";
        }
    }

    //Coroutine de destruction de child
    //Prend le dernier child (le + récent) et le détruit, puis au bout de 0.05 sec détruit le prochain child
    IEnumerator DestroyRoots()
    {
        cr_Running = true;
        playerController.plantIsPlugged = false; // on repasse en false le bool pour permettre la "re-pose" du sac
        playerIsActif = true;
        Destroy(lastChild.gameObject);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            Destroy(lastChild.gameObject);
        }
    }

    public void OnCollisionEnterChild(Collision other)
    {
        if (currentCap >= 2)
            StartCoroutine("DestroyRoots");
    }


    private void SpawnPont()
    {
        Instantiate(pont, lastChild.transform.position, Quaternion.identity);
    }

}