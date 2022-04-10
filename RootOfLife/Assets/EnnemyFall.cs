using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFall : MonoBehaviour
{
    Collider holeCollider;
    public GameObject porte;
    public GameObject interrupteur;
    public GameObject wayPoint;
    public GameObject ennemiSol;
    public Transform initialPosition;
    public GameObject mainCamera;
    CameraFollowGrotte cameraFollow;
    PlayerController playerController;
    Rigidbody ennemiRB;
    enemy_sol_mouvement enemiSolMouvement;
    ActivationPorteConnecteur activationPorte;
    CollisionFall_ collisionFall;
    RespawnMerged respawn;
    public Vector3 cinematicOffset;

    // Start is called before the first frame update
    void Start()
    {
        holeCollider = this.gameObject.GetComponent<Collider>();
        holeCollider.enabled = false;
        activationPorte = interrupteur.GetComponent<ActivationPorteConnecteur>();
        collisionFall = wayPoint.GetComponent<CollisionFall_>();
        collisionFall.enabled = false;
        wayPoint.SetActive(false);
        enemiSolMouvement = ennemiSol.GetComponent<enemy_sol_mouvement>();
        enemiSolMouvement.enabled = true;
        ennemiRB = ennemiSol.GetComponent<Rigidbody>();
        respawn = GameObject.FindWithTag("Player").GetComponent<RespawnMerged>();
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollowGrotte>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activationPorte.switchActivated == true)
        {
            holeCollider.enabled = true;
            wayPoint.SetActive(true);
            collisionFall.enabled = true;
            StartCoroutine(CinematiqueFall());
            Debug.Log("Se réactive!");
            cameraFollow.walkThroughOffset = new Vector3(0, 0, 0) ;
           // playerController.enabled = true;

        }
        if(activationPorte.switchActivated == false)
        {
            holeCollider.enabled = false;
            wayPoint.SetActive(false);
            collisionFall.enabled = false;
        }   

        if(respawn.estMort == true && activationPorte.switchActivated == true)
        {
            enemiSolMouvement.enabled = true;
            ennemiRB.isKinematic = true;
            ennemiSol.transform.position = initialPosition.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag =="EnnemiGround" && collisionFall.isFalling == true)
        {
            enemiSolMouvement.enabled = false;
            ennemiRB.isKinematic = false;
        }
    }

    IEnumerator CinematiqueFall()
    {
        Debug.Log("EnnemiFall");
       // playerController.enabled = false;
        cameraFollow.walkThroughOffset = cinematicOffset;
        yield return new WaitForSeconds(3f);
    }

}
