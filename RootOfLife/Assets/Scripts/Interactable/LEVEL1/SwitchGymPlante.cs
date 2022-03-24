using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGymPlante : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    public GameObject animationPosition;
    public Animator animatorWindow;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //positionnement du player pour animation
            playerPosition.x = animationPosition.transform.position.x;
            //animation du pickup de la plante
            StartCoroutine("ActivationGymPlante");

        }
    }

    IEnumerator ActivationGymPlante()
    {
        //animator.SetTrigger("switch");
        yield return new WaitForSeconds(0.8f);
        animatorWindow.SetTrigger("gymMode");
    }
}
