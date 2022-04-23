using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationAscenseur : MonoBehaviour
{
    public GameObject wall;
    public GameObject Particules;
    WallSlide wallSlide;
    public bool switchActivated;
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
    //WallSlide wallSlide;

    // Start is called before the first frame update
    void Start()
    {
        wallSlide = wall.GetComponent<WallSlide>();
        wallSlide.enabled = false;
        Particules.SetActive(false);
    }

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.CompareTag("Player"))
        {

            if (Input.GetButton("Fire3"))
            {
                SwitchActivate.Post(gameObject);
                switchActivated = true;

                //positionnement du player pour animation
                playerPosition.x = animationPosition.transform.position.x;
                StartCoroutine("ActivationGymPlante");
                wallSlide.enabled = true;
                Particules.SetActive(true);
            }
        }
    }

    IEnumerator ActivationGymPlante()
    {
        //desactiver le player controller et autres fonctions
        CinematicMode();

        //jouer animation player
        animatorPlayer.SetTrigger("powerSwitch");
        animatorPlayer.SetBool("cinematic", true);
        yield return new WaitForSeconds(1.4f);
        spark.Play();

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
        playerController.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        moveObject.enabled = true;
    }
}

