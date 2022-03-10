using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeClimb : MonoBehaviour
{
    PlayerController playerController;
    Plane plane;
    Vector3 endPosition;

    public float offset;
    public float realOffset;
    public int direction;
    public bool isJumping;

    public float timerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        plane = GetComponent<Plane>();
        offset = 1f;
        timerAnimation = 10f;//1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        realOffset = offset * direction;
        isJumping = playerController.isJumping;

        //On détermine la direction du joueur pour orienter son offset
        if (Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ledge") && isJumping)
        {
            //Lors de la collision, on va chercher la position du endPoint enfant du ledge climb actif
            endPosition = other.gameObject.transform.GetChild(0).position;
            //On reset la position du player au endPoint, au sommet du ledgeClimb avec le offset dans la direction appropriée
            transform.position = endPosition + new Vector3 (realOffset, 0, 0);
            //Départ de la coroutine pour desactiver le script PlayerController le temps de l'animation;
            StartCoroutine(Waiter());
        }
    }
    //Ce IEnumator desactive les contrôles du player pour la durée de l'animation
    IEnumerator Waiter()
    {
        playerController.enabled = false;
        plane.enabled = false;
        Debug.Log("playerController enabled false");
        yield return new WaitForSeconds(timerAnimation);
        playerController.enabled = true;
        plane.enabled = true;
        Debug.Log("playerController enabled true");
    }
}
