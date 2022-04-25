using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivationGenerique : MonoBehaviour
{
    public GameObject fondBlanc;
    public GameObject defilementGenerique;
    playVideo PlayVideo;
    public bool jeuFini;

    // Start is called before the first frame update
    void Start()
    {
        fondBlanc.SetActive(false);
        defilementGenerique.SetActive(false);
        PlayVideo = this.gameObject.GetComponent<playVideo>();
        jeuFini = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(PlayVideo.generiqueActive == true)
        {
            StartCoroutine(Generique());
        }

        if (jeuFini == true)
        {
            SceneManager.LoadScene("gym_menu");
        }
    }

    IEnumerator Generique()
    {
        yield return new WaitForSeconds(20f);
        fondBlanc.SetActive(true);
        yield return new WaitForSeconds(2f);
        defilementGenerique.SetActive(true);
        yield return new WaitForSeconds(25f);
        jeuFini = true;
    }
}
