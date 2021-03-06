using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGymPlante : MonoBehaviour
{
    public GameObject triggerSocle;

    private GameObject player;
    private Vector3 playerPosition;
    public GameObject animationPosition;
    public Animator animatorWindow;
    public Animator animatorPlayer;
    public Animator cercleBlancAnimator;

    PlayerController playerController;
    private PlugPlant plugplant;
    private Plane plane;
    public GrowthManager growthManager;
    private MoveObject moveObject;

    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject lamp3;
    public GameObject lamp4;
    public GameObject pad;
    public ParticleSystem spark;

    public bool cameraSecurityOn;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        plugplant = player.GetComponent<PlugPlant>();
        plane = player.GetComponent<Plane>();
        moveObject = player.GetComponent<MoveObject>();
        cameraSecurityOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position;
    }

    /*
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
    */

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButton("Fire3"))
            {

                //positionnement du player pour animation
                playerPosition.x = animationPosition.transform.position.x;
                //animation du pickup de la plante
                StartCoroutine("ActivationGymPlante");
            }
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
        animatorPlayer.SetBool("cinematic", true);
        //animator.SetTrigger("switch");

        //activer le trigger permettant de reveler le sac
        triggerSocle.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        spark.Play();
        lamp3.SetActive(false);
        lamp4.SetActive(true);
        animatorWindow.SetTrigger("gymMode");
        animatorPlayer.SetBool("cinematic", false);
        //activer les cam?ras de s?curit?
        cameraSecurityOn = true;
        
        yield return new WaitForSeconds(1f);
        //reactiver le player controller et autres fonctions
        GameplayMode();
        //allumer les lampes apres la fermeture de la fenetre
        yield return new WaitForSeconds(5f);
        lamp1.gameObject.SetActive(true);
        lamp2.gameObject.SetActive(true);
        //pad.gameObject.SetActive(true);
        //cercleBlancAnimator.SetTrigger("on");
    }

    //desactiver le player controller et autres fonctions pour une cinematique
    void CinematicMode()
    {
        playerController.enabled = false;
        moveObject.enabled = false;
    }

    //reactiver le player controller et autres fonctions a la fin de la cinematique
    void GameplayMode()
    {
        playerController.enabled = true;
        moveObject.enabled = true;
    }
}
