using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerelle : MonoBehaviour
{
    //public Rigidbody myRb;
    public GameObject passerelle;
    public ParticleSystem sparks1;
    public ParticleSystem sparks2;
    public ParticleSystem sparks3;
    public ParticleSystem sparks4;
    public Animator animatorPasserelle;

    public PhysicMaterial glissant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            StartCoroutine("DelaiKinematic");
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator DelaiKinematic()
    {
        animatorPasserelle.SetTrigger("falling");
        passerelle.GetComponent<MeshCollider>().material = glissant;
        sparks1.Play();
        sparks2.Play();
        sparks3.Play();
        sparks4.Play();
        yield return new WaitForSeconds(3f);
        GetComponent<Passerelle>().enabled = false;

    }
}
