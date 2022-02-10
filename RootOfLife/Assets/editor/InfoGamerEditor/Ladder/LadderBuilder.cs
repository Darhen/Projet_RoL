using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LadderCreator))]
public class LadderBuilder : Editor
{

    LadderCreator creator;
    Object oldTarget;
    LadderCreator oldCreator;

    private void OnEnable()
    {
        creator = (LadderCreator)target;
        

    }

    private void OnSceneGUI()
    {
        
        if(creator.tag == "Ladder" && Event.current.type == EventType.Repaint)
        {
            creator.CreateLadder();
        }


    }

    

    [MenuItem("GameObject/InfoGamer/Ladder")]
    static void CreateLadder()
    {
        GameObject Ladder = new GameObject();

        Transform pos = SceneView.lastActiveSceneView.camera.transform;
        Ladder.transform.position = pos.position + pos.forward * 5;
        Ladder.AddComponent<LadderCreator>();
        BoxCollider collider = Ladder.AddComponent<BoxCollider>();
        //collider.isTrigger = true;
        collider.size = new Vector3(1, 1, .2f);
        collider.center = new Vector3(0, -.5f, 0);
        AddTag("Ladder");
        Ladder.name = "Ladder";
        Ladder.tag = "Ladder";

    }


    public static void AddTag(string tag)
    {
        UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        if ((asset != null) && (asset.Length > 0))
        {
            SerializedObject so = new SerializedObject(asset[0]);
            SerializedProperty tags = so.FindProperty("tags");

            for (int i = 0; i < tags.arraySize; ++i)
            {
                if (tags.GetArrayElementAtIndex(i).stringValue == tag)
                {
                    return;     // Tag already present, nothing to do.
                }
            }

            tags.InsertArrayElementAtIndex(0);
            tags.GetArrayElementAtIndex(0).stringValue = tag;
            so.ApplyModifiedProperties();
            so.Update();
        }
    }
}
