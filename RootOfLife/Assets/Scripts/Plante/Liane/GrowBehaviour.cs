using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBehaviour : MonoBehaviour
{
    public float xInput;

    public float rotSpeed = 350;
    public float damping = 15;

    private float desiredRot;

    public GameObject myPrefab;
    private GameObject prefabClone;
    public GameObject endPoint;
    GameObject spawnPoint;
    Transform startPos;

    GrowthManager growthManager;
    /*PlugPlant plugPlant;
    PlayerController playerController;
    CameraFollow cameraFollow;
    GameObject cam;*/

    public bool canClone;
    public bool keyIsReleased;

    public GameObject pont;

    public bool isTouchingGround;
    public Transform groundCheck;
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        canClone = true;
        spawnPoint = GameObject.Find("SpawnPos");
        startPos = spawnPoint.GetComponent<Transform>();
        keyIsReleased = false;

        growthManager = transform.parent.GetComponent<GrowthManager>();

       /* plugPlant = GetComponentInParent<PlugPlant>();
        playerController = GetComponentInParent<PlayerController>();
        cam = GameObject.FindWithTag("MainCamera");
        cameraFollow = cam.GetComponent<CameraFollow>();*/
    }

    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.z;
        Vector3 desiredPos = endPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        isTouchingGround = Physics.CheckSphere(groundCheck.position, 4f, groundLayer);

        if (this.transform.localScale.y <= 0.2f)
        {
            if (Input.GetKey(KeyCode.F) || Input.GetButton("Fire2"))
            {
                this.transform.localScale = this.transform.localScale + (new Vector3(0f, 1f, 0f) * Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.F) || Input.GetButtonUp("Fire2"))
            {
                
                growthManager.StartCoroutine("DestroyRoots"); // à remplacer pour permettre au branches de rester pour le trampoline
                this.gameObject.tag = "FollowMe";

                if (!isTouchingGround)
                {
                    Instantiate(pont, endPoint.transform.position, Quaternion.identity);
                }
                //
                /*plugPlant.count = 0;
                playerController.enabled = true;
                cameraFollow.count = 0;*/
            }

            if (xInput >= 0)//(Input.GetKey(KeyCode.RightArrow))
            {
                desiredRot -= rotSpeed * Time.deltaTime;
            }

            if (xInput <= 0)//(Input.GetKey(KeyCode.LeftArrow))
            {
                desiredRot += rotSpeed * Time.deltaTime;
            }
            var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
        }

        if (canClone)
        {
            if (this.transform.localScale.y >= 0.2f)
            {
                SpawnClone();
            }
        }
        else if (!canClone)
        {
            this.gameObject.tag = "OldRoot";
            this.enabled = false;
        }
    }
        
    void SpawnClone()
    {
        prefabClone = Instantiate(myPrefab, endPoint.transform.position, endPoint.transform.rotation) as GameObject;
        prefabClone.transform.SetParent(startPos);
        canClone = false;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Box" || other.gameObject.tag == "Untagged" || other.gameObject.tag == "Slope" || other.gameObject.tag == "Switch")
        {
            Debug.Log("PlanteHitObject");
            growthManager.OnCollisionEnterChild(other);
        }
    }
}

