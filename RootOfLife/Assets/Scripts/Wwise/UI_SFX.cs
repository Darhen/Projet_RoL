using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SFX : MonoBehaviour
{
    void StartGame()
    {
        AkSoundEngine.PostEvent("StartGame", gameObject);
    }

    void ReturnToMainMenu()
    {
        AkSoundEngine.PostEvent("ReturnTo_MainMenu", gameObject);
    }

    void OthersClicks()
    {
        AkSoundEngine.PostEvent("SelectButton", gameObject);
    }
}
