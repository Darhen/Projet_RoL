using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxIntensity : MonoBehaviour
{
    public float ambiantSkybox;
    //public bool canChange;

    void Update()
    {
        RenderSettings.ambientIntensity = ambiantSkybox;
        /*
        if (canChange)
        {
            float target = 1.0f;

            float delta = target - ambiantSkybox;
            delta *= Time.deltaTime;

            ambiantSkybox += delta;
        }
        */
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            ambiantSkybox = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        ambiantSkybox = v_end;
    }
}
