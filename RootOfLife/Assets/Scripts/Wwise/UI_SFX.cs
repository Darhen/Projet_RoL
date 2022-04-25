using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SFX : MonoBehaviour
{
    public void StartGame()
    {
        AkSoundEngine.PostEvent("StartGame", gameObject);
    }

    public void ReturnToMainMenu()
    {
        AkSoundEngine.PostEvent("ReturnTo_MainMenu", gameObject);
    }

    public void OthersClicks()
    {
        AkSoundEngine.PostEvent("SelectButton", gameObject);
    }
}
