using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{

    public int maxCap = 12;
    public int currentCap;
    //GameObject lastChild;

    GrowBehaviour test;

    void Start()
    {

    }

    void Update()
    {
        currentCap = this.gameObject.transform.childCount;
        Transform lastChild = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1);

        if (currentCap >= maxCap)
        {
            test = lastChild.GetComponentInChildren<GrowBehaviour>();
            test.canClone = false;

            //Chope le dernier child et d�sactive son script et le d�tag.
            //Lance une coroutine de destruction de child
        }

        if(Input.GetKeyDown(KeyCode.H))
            Destroy(lastChild.gameObject);
    }

    //Coroutine de destruction de child
    //Prend le dernier child (le + r�cent) et le d�truit, puis au bout de 0.1 sec d�truit le prochain child
}
