using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFinale : MonoBehaviour
{
    public GameObject fadeOut;
    public bool LoadScene;

    private void Start()
    {
        fadeOut.SetActive(false);
        Physics.IgnoreLayerCollision(10, 0);
        LoadScene = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(GrotteATour());
        }
    }

    private void Update()
    {
        if (LoadScene == true)
        {
            SceneManager.LoadScene("Level4");
        }
    }

    IEnumerator GrotteATour()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        LoadScene = true;
        Debug.Log("Load scene");
    }
}
