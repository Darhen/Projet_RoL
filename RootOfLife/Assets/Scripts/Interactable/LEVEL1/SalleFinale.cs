using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalleFinale : MonoBehaviour
{
    public Animator salleFinaleAnimator;
    private GameObject player;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            salleFinaleAnimator.enabled = true;
            playerRb.isKinematic = true;
            StartCoroutine("LoadingNextScene");
        }
    }

    IEnumerator LoadingNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LEVEL2");
    }
}
