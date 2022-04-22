using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxIntensity : MonoBehaviour
{
    public float ambiantSkybox;
    public bool canChange;

    void Update()
    {
        RenderSettings.ambientIntensity = ambiantSkybox;
        
        if (canChange)
        {
            StartCoroutine(ChangeSpeed(0.1f, 1f, 7f));
        }
        
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
