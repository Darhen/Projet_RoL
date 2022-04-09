using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSolBossDesactiv : MonoBehaviour
{
    Transform player;
    Rigidbody rb_player;
    public GameObject robotSolBoss;
    public GameObject SpotLight;
    public GameObject mainCamera;

    Animator animatorLightSol;
    public Animator animatorPlayer;

    RespawnMerged respawn;
    EnnemiSolBossActive ennemiSolBossActive;
    CameraFollowGrotte cameraFollow;

    public Transform initialPosition;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb_player = player.GetComponent<Rigidbody>();
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollowGrotte>();
        respawn = player.GetComponent<RespawnMerged>();

        //ennemiSolBossActive.speed = 0f;
        //SpotLight.SetActive(false);
        animatorLightSol = SpotLight.GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
            ennemiSolBossActive.enabled = false;
            robotSolBoss.GetComponent<Animator>().enabled = false;
            robotSolBoss.GetComponent<Animator>().SetBool("IsCharging", false);
            ennemiSolBossActive.speed = 0f;
            SpotLight.SetActive(false);

        }
    }

    private void Update()
    {
        if (respawn.estMort == true)
        {
            StartCoroutine(MortParBossSol());
        }
    }


    IEnumerator MortParBossSol()
    {
        ennemiSolBossActive.enabled = false;
        robotSolBoss.GetComponent<Animator>().enabled = false;
        robotSolBoss.GetComponent<Animator>().SetBool("IsCharging", false);
        ennemiSolBossActive.speed = 0f;

        yield return new WaitForSeconds(2f);

        robotSolBoss.transform.position = initialPosition.position;
        SpotLight.SetActive(false);
    }

}