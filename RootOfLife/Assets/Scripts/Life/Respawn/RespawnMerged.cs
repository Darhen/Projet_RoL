using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMerged : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 respawnPoint;

    public GameObject fadeToBlack;
    NewCheckIfIsInsideBeam newCheckIfIsInsideBeam;
    public GameObject sphere;

    private void Start()
    {
        newCheckIfIsInsideBeam = sphere.GetComponent<NewCheckIfIsInsideBeam>();
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
        else if (other.CompareTag ("CheckPoint"))
        {
            respawnPoint = player.transform.position;
        }
    }

    private void Update()
    {
        if (newCheckIfIsInsideBeam.variableT >= newCheckIfIsInsideBeam.maxT) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
        {
            StartCoroutine(RespawnLight());
        }
    }

    IEnumerator RespawnCollision()
    {
        yield return new WaitForSeconds(0.1f);
        player.transform.position = respawnPoint;
        newCheckIfIsInsideBeam.variableT = newCheckIfIsInsideBeam.minT;
        Physics.SyncTransforms();
        fadeToBlack.GetComponent<Animation>().Play("fadeToBlack");
    }

    IEnumerator RespawnLight()
    {

        yield return new WaitForSeconds(0.1f);
        newCheckIfIsInsideBeam.variableT = newCheckIfIsInsideBeam.minT;
        yield return new WaitForSeconds(0.1f);
        player.transform.position = respawnPoint;
        fadeToBlack.GetComponent<Animation>().Play("fadeToBlack");

    }
 
}
