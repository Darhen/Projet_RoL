using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecurity : MonoBehaviour
{
    public Transform player;
    public SwitchGymPlante switchGymPlante;
    public bool cameraSecurityOn;
    public GameObject redLight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraSecurityOn = switchGymPlante.cameraSecurityOn;

        if (cameraSecurityOn == true)
        {
            redLight.SetActive(true);
            transform.LookAt(player);
        }
        
    }
}
