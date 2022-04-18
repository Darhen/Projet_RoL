using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorielPartie1 : MonoBehaviour
{
    public GameObject player;
    public GameObject trigger1;

    public Animator brasAnimator1;
    public Animator brasAnimator2;
    public Animator brasAnimator3;

    public Animator spriteBras1;
    public Animator spriteBras2;
    public Animator spriteBras3;

    public SensorTrigger planteTrigger1;
    public SensorTrigger planteTrigger2;
    public SensorTrigger planteTrigger3;
    public TutorialPlayerTrigger2 triggerPlateforme1;
    public TutorialPlayerTrigger3 triggerPlateforme2;
    public TutorialPlayerTrigger4 triggerPlateforme3;
    public CameraBound cameraBound;

    public GameObject cameraBoundary;
    public GameObject boundaryPosition;
    public GameObject targetBoundary;

    public bool triggerStartTutorialActive;
    public bool cible1activated;
    public bool cible2activated;
    public bool cible3activated;


    public bool trigger2activated;
    public bool trigger3activated;
    public bool trigger4activated;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //premiere action du tuto: poser le sac
        if (!triggerStartTutorialActive)
        {
            if (Input.GetKeyDown(KeyCode.G) && !triggerStartTutorialActive || Input.GetButtonDown("Fire1"))
            {
                trigger1.SetActive(true);
                triggerStartTutorialActive = true;
                spriteBras1.SetTrigger("trigger1");
            }
        }

        //quand le trigger 1 est atteint, changer le sprite pour animation trigger 2
        if (!cible1activated && planteTrigger1.isActive == true)
        {
            spriteBras1.SetTrigger("trigger2");
            cible1activated = true;
        }

        //quand le trigger 2 est atteint, changer le sprite pour animation trigger 3
        if (!cible2activated && planteTrigger2.isActive == true)
        {
            spriteBras1.SetTrigger("trigger3");
            cible2activated = true;
        }

        //lorsque le dernier trigger de plante est active, on redonne le controle au player
        if (!cible3activated && planteTrigger3.isActive == true)
        {
            spriteBras1.SetTrigger("plateforme1");
            player.GetComponent<Rigidbody>().isKinematic = false;
            cible3activated = true;
        }

        //quand le player rejoint la plateforme 1, on active bras 2 et desactive bras 1
        if (triggerPlateforme1.isActive == true && !trigger2activated)
        {
            Debug.Log("deactivate bras 1");
            brasAnimator1.SetTrigger("deactivate");
            Debug.Log("activate bras 2");
            brasAnimator2.SetTrigger("activate");
            trigger2activated = true;
        }

        //quand le player rejoint la plateforme 2, on active bras 3 et desactive bras 2
        if (triggerPlateforme2.isActive == true && !trigger3activated)
        {
            Debug.Log("deactivate bras 2");
            brasAnimator2.SetTrigger("deactivate");
            Debug.Log("activate bras 3");
            brasAnimator3.SetTrigger("activate");
            trigger3activated = true;
        }

        //quand le player rejoint la plateforme 3, on monte le bras 3
        if (triggerPlateforme3.isActive == true && !trigger4activated)
        {
            Debug.Log("stage 2 - bras 3");
            brasAnimator3.SetTrigger("stage2");
            spriteBras3.SetTrigger("parachute");
            trigger4activated = true;

        }

        //gestion camera boundaries
        if (trigger3activated == true)
        {
            cameraBoundary.SetActive(true);
        }
        if (trigger4activated == true)
        {
            boundaryPosition.transform.position = targetBoundary.transform.position;
            cameraBound.xFree = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<TutorielPartie1>().enabled = false;
    }
}
