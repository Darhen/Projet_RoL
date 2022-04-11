using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeClimb : MonoBehaviour
{
    PlayerController playerController;
    PlayerClimbing playerClimbing;
    Plane plane;
    Vector3 endPosition;
    Rigidbody rbPlayer;
    Trampoline trampoline;

    public float offset;
    public int direction;
    public bool isJumping;
    public bool isLedgeClimbing;
    public float timerAnimation;
    public bool isLadderClimbing;
    public int directionLedge;
    public Transform model;
    public bool bounce;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerClimbing = GetComponent<PlayerClimbing>();
        plane = GetComponent<Plane>();
        offset = 1f;
        timerAnimation = 1.2f;
        rbPlayer = GetComponent<Rigidbody>();
        directionLedge = 1;
        trampoline = GetComponent<Trampoline>();
    }

    // Update is called once per frame
    void Update()
    {
        isJumping = playerController.isJumping;
        isLadderClimbing = playerClimbing.isClimbing;
        bounce = trampoline.bounce;

        //On détermine la direction du joueur pour orienter son offset
        if (Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        }
        if (isLedgeClimbing)
        {
            rbPlayer.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge") && isJumping || other.gameObject.CompareTag("Ledge") && bounce || other.gameObject.CompareTag("Ledge") && isLadderClimbing)
        {
            Debug.Log("LedgeClimb");
            //Determiner la direction du ledge climb
            directionLedge = other.gameObject.GetComponent<LedgeClimbDirection>().direction;
            //Lors de la collision, on va chercher la position du endPoint enfant du ledge climb actif
            endPosition = other.gameObject.transform.GetChild(0).position;
            //On reset la position du player au endPoint, au sommet du ledgeClimb avec le offset dans la direction appropriée
            transform.position = endPosition + new Vector3(offset * directionLedge, 0, 0);
            //Départ de la coroutine pour desactiver le script PlayerController le temps de l'animation;
            StartCoroutine(Waiter());
            //Éliminer la vélocité du player
            rbPlayer.velocity = new Vector3 (0, 0, 0);
            //Déclarer que le player ledge climb pour l'animation
            isLedgeClimbing = true;
            //Tourner le player vers la direction du ledge
            /*Quaternion turnModel = Quaternion.LookRotation(new Vector3(directionLedge, 0, 0));
            model.rotation = turnModel;*/
        }
    }
    //Ce IEnumator desactive les contrôles du player pour la durée de l'animation
    IEnumerator Waiter()
    {
        //Tourner le player vers la direction du ledge
        Quaternion turnModel = Quaternion.LookRotation(new Vector3(directionLedge, 0, 0));
        model.rotation = turnModel;
        //Ledge Climb
        playerController.enabled = false;
        //plane.enabled = false;
        rbPlayer.isKinematic = true;
        Debug.Log("playerController enabled false");
        yield return new WaitForSeconds(timerAnimation);
        isLedgeClimbing = false;
        playerController.enabled = true;
        //plane.enabled = true;
        //Éliminer la vélocité du player
        rbPlayer.velocity = new Vector3(0, 0, 0);
        rbPlayer.isKinematic = false;
        Debug.Log("playerController enabled true");
    }
}
