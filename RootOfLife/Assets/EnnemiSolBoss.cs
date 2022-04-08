using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSolBoss : MonoBehaviour
{

    Transform player;
    Rigidbody rb_player;
  public GameObject robotSolBoss;
    public GameObject SpotLight;
    public GameObject mainCamera;
    public Vector3 cineOffset;

    Animator animatorLightSol;
    public Animator animatorPlayer;

    RespawnMerged respawn;
    EnnemiSolBossActive ennemiSolBossActive;
    CameraFollow cameraFollow;
    PlayerController playerController;
    PlugPlant plugplant;
    Plane plane;
    MoveObject moveObject;

    public Transform originalPosition;
    public Quaternion originalRotation;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb_player = player.GetComponent<Rigidbody>();
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        playerController = player.GetComponent<PlayerController>();
        plugplant = player.GetComponent<PlugPlant>();
        plane = player.GetComponent<Plane>();
        moveObject = player.GetComponent<MoveObject>();
        ennemiSolBossActive = robotSolBoss.GetComponent<EnnemiSolBossActive>();

        ennemiSolBossActive.speed = 0f;
        SpotLight.SetActive(false);
        animatorLightSol = SpotLight.GetComponent<Animator>();

        originalRotation = transform.rotation;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(AttaqueBossSol());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(AttaqueBossSol());
            ennemiSolBossActive.enabled = false;
            robotSolBoss.GetComponent<Animator>().enabled = false;
            robotSolBoss.GetComponent<Animator>().SetBool("IsCharging", false);
            ennemiSolBossActive.speed = 0f;

            if (respawn.estMort)
            {
                Debug.Log("ChuiTuMort");
                robotSolBoss.transform.position = new Vector3(0, 0, 2.44f);
                robotSolBoss.transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * 20);
            }
        }
    }

    IEnumerator AttaqueBossSol()
    {
        
        CinematicMode();

        SpotLight.SetActive(true);
        cameraFollow.walkThroughOffset = cineOffset;
        animatorLightSol.Play("WhiteToRedBossSol");
        yield return new WaitForSeconds(2f);
        cameraFollow.walkThroughOffset = new Vector3(0, 0, 0);
        animatorPlayer.SetBool("cinematic", false);
        GameplayMode();
        yield return new WaitForSeconds(0.5f);

        ChargeEnnemi();
    }


    void CinematicMode()
    {
        rb_player.constraints = RigidbodyConstraints.FreezePosition;
        animatorPlayer.enabled = false;
        playerController.enabled = false;
        plugplant.enabled = false;
        plane.enabled = false;
        moveObject.enabled = false;
    }
    void GameplayMode()
    {
        rb_player.constraints = RigidbodyConstraints.None;
        rb_player.constraints = RigidbodyConstraints.FreezePositionZ;
        rb_player.constraints = RigidbodyConstraints.FreezeRotation;
        animatorPlayer.enabled = true;
        playerController.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        moveObject.enabled = true;
    }
 
   void ChargeEnnemi()
    {
        ennemiSolBossActive.enabled = true;
    }
    /*
    private void Update()
    {
        if (respawn.estMort)
        {
            Debug.Log("ChuiTuMort");
            robotSolBoss.transform.position = new Vector3(0, 0, 2.44f);

        }
    }*/


}
