using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LadderCreator : MonoBehaviour
{


    public void CreateLadder()
    {
        GameObject temp = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/InfoGamerAssets/LadderCreator/LadderSeg.prefab", typeof(GameObject));

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            //Debug.Log(i + " " + transform.GetChild(i));
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        int scaleY = (int)transform.localScale.y;
        

        //Debug.Log(scaleY);

        for (int i = 0; i < scaleY; i++)
        {
            //Debug.Log(i + " current");
            
            GameObject clone = PrefabUtility.InstantiatePrefab(temp) as GameObject;
            clone.transform.localPosition = transform.position + Vector3.down * i;
            clone.transform.rotation = transform.rotation;
            clone.transform.parent = transform;
            //Debug.Log(clone);
            clone = PrefabUtility.InstantiatePrefab(temp) as GameObject;
            clone.transform.localPosition = transform.position + Vector3.down * i + Vector3.down*.5f;
            clone.transform.rotation = transform.rotation;
            clone.transform.parent = transform;
            //Debug.Log(clone);
        }

        float remained = transform.localScale.y - scaleY;

        if(0 < remained)
        {
            
            GameObject clone = PrefabUtility.InstantiatePrefab(temp) as GameObject;
            clone.transform.localPosition = transform.position + Vector3.down * scaleY;
            clone.transform.rotation = transform.rotation;
            clone.transform.parent = transform;
            //Debug.Log(clone);
        }
        if(.5f < remained)
        {
           
            GameObject clone = PrefabUtility.InstantiatePrefab(temp) as GameObject;
            clone.transform.localPosition = transform.position + Vector3.down * scaleY + Vector3.down*.5f;
            clone.transform.rotation = transform.rotation;
            clone.transform.parent = transform;
            //Debug.Log(clone);
        }
    }
}
