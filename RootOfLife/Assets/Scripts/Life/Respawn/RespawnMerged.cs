using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnMerged : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 respawnPoint;

    public GameObject FadeOutScreen;
    NewCheckIfIsInsideBeam newCheckIfIsInsideBeam;
    ActivateCheckIfIsInside activateCheckIfIsInside;
    CouleurEmmissiveSac couleurEmissiveSac;
    public GameObject sphere;
    public GameObject myLight;
    PlayerController playerController;


    private void Start()
    {


        playerController = GetComponentInParent<PlayerController>();

        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
        activateCheckIfIsInside = sphere.GetComponent<ActivateCheckIfIsInside>();

        respawnPoint = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            StartCoroutine(RespawnCollision());
        }
        else if (other.CompareTag("Trou"))
        {
            StartCoroutine(RespawnCollision());
        }
        else if (other.gameObject.tag == "CheckPoint")
        {
            respawnPoint = player.transform.position;
        }
    }

    private void Update()
    {
        if (newCheckIfIsInsideBeam.variableT >= newCheckIfIsInsideBeam.maxT) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
        {
            StartCoroutine(RespawnCollision());
        }
    }
    /*
    public void FadingOut()
    {
        StartCoroutine(IsFading());
    }*/

    IEnumerator RespawnCollision()
    {
        yield return new WaitForSeconds(0.1f);
        //FadingOut();
        newCheckIfIsInsideBeam.variableT = newCheckIfIsInsideBeam.minT;
        newCheckIfIsInsideBeam.lerpedColor = newCheckIfIsInsideBeam.colorIni;
        activateCheckIfIsInside.activated = false;
        myLight.SetActive(false);
        player.transform.position = respawnPoint;
        Physics.SyncTransforms();
        FadeOutScreen.GetComponent<Animator>().Play("FadeOut");
    }
    /*
    IEnumerator IsFading()
    {
        yield return new WaitForSeconds(0.1f);
    }*/
 
}
