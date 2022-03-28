using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSac : MonoBehaviour
{
    public GameObject sacProp;
    public GameObject sacPlayer;
    private GameObject player;
    private Vector3 playerPosition;
    public Vector3 animationPosition;


    private PlugPlant plugplant;
    private Plane plane;
    public GrowthManager growthManager;
    private PlayerController playerController;
    public Animator animatorPlayer;
    private GameObject mainDroitePlayer;
    private Vector3 positionMainDroitePlayer;
    private MoveObject moveObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        plugplant = player.GetComponent<PlugPlant>();
        plane = player.GetComponent<Plane>();
        animatorPlayer = GameObject.Find("TestCharacter27_janvier").GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        mainDroitePlayer = GameObject.Find("mixamorig:RightHand");
        moveObject = player.GetComponent<MoveObject>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        positionMainDroitePlayer = mainDroitePlayer.GetComponent<Transform>().position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //positionnement du player pour animation
            playerPosition.x = animationPosition.x;
            //animation du pickup de la plante
            StartCoroutine("PickupSacTutoriel");
            
        }
    }

    IEnumerator PickupSacTutoriel()
    {
        //desactive le playercontroller le temps de la sequence
        playerController.enabled = false;
        moveObject.enabled = false;
        //animation du pickup de sac
        animatorPlayer.SetTrigger("PickupObject");
        animatorPlayer.SetBool("cinematic", true);
        //transfert du sac prop dans la main
        yield return new WaitForSeconds(0.5f);
        sacProp.GetComponent<Transform>().position = positionMainDroitePlayer;
        sacProp.transform.parent = mainDroitePlayer.transform;
        //reset du sac dans le dos
        yield return new WaitForSeconds(2f);
        //desactivation du sac prop
        sacProp.SetActive(false);
        sacProp.transform.parent = null;
        //activation du sac dans le dos du player
        sacPlayer.SetActive(true);
        //activation des scripts lies a la plante
        plugplant.enabled = true;
        plane.enabled = true;
        growthManager.enabled = true;
        //reactivation du playerController
        playerController.enabled = true;
        moveObject.enabled = true;
        animatorPlayer.SetBool("cinematic", false);
        //desactiver le trigger
        this.gameObject.SetActive(false);
    }
}
