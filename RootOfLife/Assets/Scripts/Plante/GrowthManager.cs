using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{

    public int maxCap = 12;
    public int currentCap;
    //GameObject lastChild;
    Transform lastChild;
    GrowBehaviour test;

    void Update()
    {
        currentCap = this.gameObject.transform.childCount;
        lastChild = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1);

        if (currentCap >= maxCap)
        {
            test = lastChild.GetComponentInChildren<GrowBehaviour>();
            test.canClone = false;

            //Chope le dernier child et désactive son script et le détag.
            //Lance une coroutine de destruction de child
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine("DestroyRoots");
        } 

        if (currentCap != maxCap)
        {
            if (!Input.GetKey(KeyCode.G))
            {
                Debug.Log("yolo");
                //Ici on instancie le pont et on lance la coroutine de destruction des capsules? 
            }
        }

        if (currentCap == 1)
        {
            StopCoroutine("DestroyRoots");
        }
    }

    //Coroutine de destruction de child
    //Prend le dernier child (le + récent) et le détruit, puis au bout de 0.1 sec détruit le prochain child
    IEnumerator DestroyRoots()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(lastChild.gameObject);
        }
    }
}
