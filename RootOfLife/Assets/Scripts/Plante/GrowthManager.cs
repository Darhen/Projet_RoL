using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{

    public int maxCap = 12;
    public int currentCap;
    //GameObject lastChild;
    Transform lastChild;
    GrowBehaviour growthBehaviour;
    CameraFollow cameraFollow;
    GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera");
        cameraFollow = cam.GetComponent<CameraFollow>();
    }
    private void Update()
    {
        currentCap = this.gameObject.transform.childCount;
        lastChild = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1);

        if (currentCap >= maxCap)
        {
            growthBehaviour = lastChild.GetComponentInChildren<GrowBehaviour>();
            growthBehaviour.canClone = false;

            //Chope le dernier child et d�sactive son script et le d�tag.
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine("DestroyRoots");
            //Lance une coroutine de destruction de child
        }

        if (currentCap != maxCap)
        {
            if (!Input.GetKey(KeyCode.G))
            {
                Debug.Log("yolo");
                //Ici on d�tecte le relachement de l'input

                //Code:On instancie le pont et on lance la coroutine de destruction des capsules? 
            }
        }

        if (currentCap == 1)
        {
            StopCoroutine("DestroyRoots");
            //Quand le bool est strictement �gale � 1 on stop la coroutine (SacPlug est le 1er enfant de l'objet et on ne veut pas le d�truire)
        }
    }

    //Coroutine de destruction de child
    //Prend le dernier child (le + r�cent) et le d�truit, puis au bout de 0.1 sec d�truit le prochain child
    IEnumerator DestroyRoots()
    {
        cameraFollow.count = 0; //On r�attribut le player comme target de la cam�ra
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(lastChild.gameObject);
        }
    }
}
