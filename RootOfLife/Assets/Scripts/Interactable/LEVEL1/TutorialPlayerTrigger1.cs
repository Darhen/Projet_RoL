using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerTrigger1 : MonoBehaviour
{
    public GameObject player;
    public Animator brasAnimator;
    TutorielPartie1 tutorielPartie1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tutorielPartie1 = GetComponent<TutorielPartie1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("TutorialStart");
        }
    }

    IEnumerator TutorialStart()
    {
        player.GetComponent<Transform>().position = new Vector3 (transform.position.x, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
        player.GetComponent<Rigidbody>().isKinematic = true;
        brasAnimator.SetTrigger("activate");
        yield return new WaitForSeconds(0.02f);
        tutorielPartie1.enabled = true;
        this.gameObject.GetComponent<TutorialPlayerTrigger1>().enabled = false;
    }
}
