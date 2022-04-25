using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicWait : MonoBehaviour
{
    public GameObject player;
    public GameObject endPoint;
    public Vector3 cinematicEndPosition;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        cinematicEndPosition = endPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            StartCoroutine("PlayerKinematic");
        }
    }

    IEnumerator PlayerKinematic()
    {
        yield return new WaitForSeconds(11f);
        player.transform.position = cinematicEndPosition;
        playerRb.isKinematic = true;
        yield return new WaitForSeconds(18f);
        playerRb.isKinematic = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
