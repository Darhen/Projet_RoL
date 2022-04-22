using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPorte : MonoBehaviour
{

    public Animator porteAnimator;
    public bool switchActivated;
    public GameObject Porte;
    public GameObject player;
    RespawnMerged respawnMerged;

    private Vector3 playerPosition;
    public GameObject animationPosition;
    public Animator animatorPlayer;

    PlayerController playerController;
    private PlugPlant plugplant;
    private Plane plane;
    private MoveObject moveObject;
    public ParticleSystem spark;

    public AK.Wwise.Event SwitchActivate;
    

    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        porteAnimator = Porte.GetComponent<Animator>();
        respawnMerged = player.GetComponent<RespawnMerged>();

        playerController = player.GetComponent<PlayerController>();
        plugplant = player.GetComponent<PlugPlant>();
        plane = player.GetComponent<Plane>();
        moveObject = player.GetComponent<MoveObject>();
    }

    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position;
        /*
        if (respawnMerged.estMort == true)
        {
            switchActivated = false;
            porteAnimator.SetBool("Activated", false);
        }*/
    }


    // Update is called once per frame
    void OnTriggerStay(Collider trigger)
    {
        if (trigger.CompareTag("Player")){
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchActivate.Post(gameObject);
                switchActivated = true;

                //positionnement du player pour animation
                playerPosition.x = animationPosition.transform.position.x;
                StartCoroutine("ActivationGymPlante");
            }
        }
    }


    IEnumerator ActivationGymPlante()
    {

        //desactiver le player controller et autres fonctions
        CinematicMode();

        //desactiver le trigger apres le contact
        //this.gameObject.GetComponent<BoxCollider>().enabled = false;

        //jouer animation player
        animatorPlayer.SetTrigger("powerSwitch");
        animatorPlayer.SetBool("cinematic", true);
        yield return new WaitForSeconds(1.4f);
        spark.Play();
        porteAnimator.SetBool("Activated", true);

        yield return new WaitForSeconds(2f);
        //reactiver le player controller et autres fonctions
        animatorPlayer.SetBool("cinematic", false);
        GameplayMode();
    }

    //desactiver le player controller et autres fonctions pour une cinematique
    void CinematicMode()
    {
        playerController.enabled = false;
        plugplant.enabled = false;
        plane.enabled = false;
        moveObject.enabled = false;
    }

    //reactiver le player controller et autres fonctions a la fin de la cinematique
    void GameplayMode()
    {
        Debug.Log("Hola!");
        playerController.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        moveObject.enabled = true;
    }
}
