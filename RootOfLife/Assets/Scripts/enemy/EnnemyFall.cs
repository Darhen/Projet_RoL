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
    public GameObject cinematicCamera;
    public GameObject cameraTrigger1;
    public GameObject cameraTrigger2;
    public bool ennemiDead;
    //CameraFollowGrotte cameraFollow;
    PlayerController playerController;
    Rigidbody ennemiRB;
    enemy_sol_mouvement enemiSolMouvement;
    ActivationPorteConnecteur activationPorte;
    CollisionFall_ collisionFall;
    RespawnMerged respawn;
    PlugPlant plugplant;
    Plane plane;
    MoveObject moveObject;
    //public Vector3 cinematicOffset;

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
        //cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollowGrotte>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        plugplant = GameObject.FindWithTag("Player").GetComponent<PlugPlant>();
        plane = GameObject.FindWithTag("Player").GetComponent<Plane>();
        moveObject = GameObject.FindWithTag("Player").GetComponent<MoveObject>();
        cinematicCamera.SetActive(false);
        ennemiDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activationPorte.switchActivated == true && ennemiDead == false)
        {
            holeCollider.enabled = true;
            wayPoint.SetActive(true);
            collisionFall.enabled = true;
            StartCoroutine(CinematiqueFall());
            // Debug.Log("Se réactive!");
            //cameraFollow.walkThroughOffset = new Vector3(0, 0, 0) ;
            // playerController.enabled = true;
            ennemiDead = true;
        }

        if(activationPorte.switchActivated == false)
        {

            holeCollider.enabled = false;
            wayPoint.SetActive(false);
            collisionFall.enabled = false;
        }   
        /*
        if(respawn.estMort == true && activationPorte.switchActivated == true)
        {
            enemiSolMouvement.enabled = true;
            ennemiRB.isKinematic = true;
            ennemiSol.transform.position = initialPosition.position;
            ennemiDead = false;
        }*/
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
        CinematicMode();
        yield return new WaitForSeconds(5f);
        EndCinematicMode();
        Debug.Log("EnnemiFall");
        
    }

    void CinematicMode()
    {
        playerController.enabled = false;
        //animatorPlayer.enabled = false;
        cameraTrigger1.SetActive(false);
        cameraTrigger2.SetActive(false);
        plugplant.enabled = false;
        plane.enabled = false;
        moveObject.enabled = false;
        mainCamera.SetActive(false);
        cinematicCamera.SetActive(true);
        
    }

    void EndCinematicMode()
    {
        playerController.enabled = true;
        //animatorPlayer.enabled = true;
        plugplant.enabled = true;
        plane.enabled = true;
        moveObject.enabled = true;
        cameraTrigger1.SetActive(true);
        cameraTrigger2.SetActive(true);
        cinematicCamera.SetActive(false);
        mainCamera.SetActive(true);
        
    }

}
