using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBehaviour : MonoBehaviour
{
    public float rotSpeed = 350;
    public float damping = 15;

    private float desiredRot;

    public GameObject myPrefab;
    private GameObject prefabClone;
    public GameObject endPoint;
    GameObject spawnPoint;
    Transform startPos;

    public bool canClone;

    // Start is called before the first frame update
    void Start()
    {
        canClone = true;
        spawnPoint = GameObject.Find("SpawnPos");
        startPos = spawnPoint.GetComponent<Transform>();
    }

    private void OnEnable()
    {
        desiredRot = transform.eulerAngles.z;
        Vector3 desiredPos = endPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.y <= 0.2f)
        {
            if (Input.GetKey(KeyCode.F))
            {
                this.transform.localScale = this.transform.localScale + (new Vector3(0f, 0.5f, 0f)  * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                desiredRot -= rotSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
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
            this.gameObject.tag = "Untagged";
        }
    }
    void SpawnClone()
    {
        prefabClone = Instantiate(myPrefab, endPoint.transform.position, endPoint.transform.rotation) as GameObject;
        prefabClone.transform.SetParent(startPos);
        canClone = false;
    }
}
