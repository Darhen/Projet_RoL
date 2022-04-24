using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSoundTrigger : MonoBehaviour
{
    public string eventName = "default";

    private uint TitleSoundID;


    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
        AkSoundEngine.StopAll(gameObject);
    }


    public void PlaySound()
    {
        AkSoundEngine.PostEvent(eventName, gameObject);
    }
}
