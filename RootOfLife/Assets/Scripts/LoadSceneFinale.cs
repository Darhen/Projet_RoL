using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFinale : MonoBehaviour
{
    public GameObject fadeOut;

    private void Start()
    {
        fadeOut.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(GrotteATour());
        }
    }

    IEnumerator GrotteATour()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("AscenseurRobot");
    }
}
