using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool PlayerDetected;
    public Transform sphere;
    public bool isAttacking;

    DetectionPlayer detectionPlayer;
    RespawnMerged respawnMerged;

    void Start()
    {
        detectionPlayer = sphere.GetComponent<DetectionPlayer>();
        isAttacking = false;
        respawnMerged = sphere.GetComponentInParent<RespawnMerged>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetected = detectionPlayer.playerIsDetected;

        if (PlayerDetected)
        {
            StartCoroutine("PlayerDetection");
            StartCoroutine("AttackPlayer");
        }
        else
        {
            StopCoroutine("PlayerDetection");
            isAttacking = false;
        }
    }

    IEnumerator PlayerDetection()
    {
        yield return new WaitForSeconds(0.75f);
        transform.LookAt(sphere);
    }

    IEnumerator AttackPlayer()
    {
        float elapsed = 0;
        while (elapsed < 2f)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        if (!isAttacking && PlayerDetected)
        {
            //LANCER ANIMATION BRAS ATTACK
            Debug.Log("Anim BrasAttack");
            isAttacking = true;
            respawnMerged.isDead(); // On call la mort du player
            StopCoroutine("PlayerDetection");
        }
    }
}
