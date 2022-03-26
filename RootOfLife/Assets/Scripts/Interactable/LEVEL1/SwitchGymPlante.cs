using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGymPlante : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    public GameObject animationPosition;
    public Animator animatorWindow;
    public Animator animatorPlayer;

    PlayerController playerController;
    private PlugPlant plugplant;
    private Plane plane;
    public GrowthManager growthManager;
    private MoveObject moveObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        plugplant = player.GetComponent<PlugPlant>();
        plane = player.GetComponent<Plane>();
        moveObject = player.GetComponent<MoveObject>();
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
        Debug.Log("cinematique");
        //desactiver le player controller et autres fonctions
        CinematicMode();
        //desactiver le trigger apres le contact
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //jouer animation player
        animatorPlayer.SetTrigger("powerSwitch");
        //animator.SetTrigger("switch");
        yield return new WaitForSeconds(1.2f);
        animatorWindow.SetTrigger("gymMode");
        //reactiver le player controller et autres fonctions
        GameplayMode();
       
    }

    //desactiver le player controller et autres fonctions pour une cinematique
    void CinematicMode()
    {
        playerController.enabled = false;
        plugplant.enabled = false;
        plane.enabled = false;
        growthManager.enabled = false;
        moveObject.enabled = false;
    }

    //reactiver le player controller et autres fonctions a la fin de la cinematique
    void GameplayMode()
    {
        playerController.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        growthManager.enabled = true;
        moveObject.enabled = true;
    }
}
