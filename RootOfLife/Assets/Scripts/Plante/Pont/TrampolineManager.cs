using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineManager : MonoBehaviour
{
    public int seconds;
    public Transform lastChild;
    public int currentCap;


    private void Update()
    {
        currentCap = this.gameObject.transform.childCount;

        if (currentCap <= 0 )
        {
            StopCoroutine("DestroyChildren");
        }
    }

    IEnumerator DestroyChildren()
    {
        Destroy(transform.GetChild(0).gameObject);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
