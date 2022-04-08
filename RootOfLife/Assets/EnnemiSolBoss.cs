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

    public Transform initialPosition;


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
        respawn = player.GetComponent<RespawnMerged>();

        ennemiSolBossActive.speed = 0f;
        SpotLight.SetActive(false);
        animatorLightSol = SpotLight.GetComponent<Animator>();
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

    IEnumerator AttaqueBossSol()
    {
        
        CinematicMode();

        SpotLight.SetActive(true);
        cameraFollow.walkThroughOffset = cineOffset;
        animatorLightSol.Play("WhiteToRedBossSol");
        yield return new WaitForSeconds(2f);
        cameraFollow.walkThroughOffset = new Vector3(-2f, 0, -3.56f);
        animatorPlayer.SetBool("cinematic", false);
        GameplayMode();
        yield return new WaitForSeconds(0.5f);

        ChargeEnnemi();
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
    
    


}
