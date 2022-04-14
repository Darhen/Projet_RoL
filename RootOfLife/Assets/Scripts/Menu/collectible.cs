using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{

    private int collectibles;

    public GameObject Collectible_1;
    public GameObject Collectible_2;
    public GameObject Collectible_3;
    public GameObject Collectible_4;
    public GameObject Collectible_5;
    public GameObject Collectible_6;
    public GameObject Collectible_7;
    public GameObject Collectible_8;
    public GameObject Collectible_9;
    public GameObject CollectibleUI;
    public GameObject CollectibleUI2;
    public GameObject CollectibleUI3;
    public GameObject CollectibleUI4;
    public GameObject CollectibleUI5;
    public GameObject CollectibleUI6;
    public GameObject CollectibleUI7;
    public GameObject CollectibleUI8;
    public GameObject CollectibleUI9;
    public GameObject CollectibleButton1;
    public GameObject CollectibleButton2;
    public GameObject CollectibleButton3;
    public GameObject CollectibleButton4;
    public GameObject CollectibleButton5;
    public GameObject CollectibleButton6;
    public GameObject CollectibleButton7;
    public GameObject CollectibleButton8;
    public GameObject CollectibleButton9;

    public bool collectibleActive = false;
    public bool collectibleActive2 = false;
    public bool collectibleActive3 = false;
    public bool collectibleActive4 = false;
    public bool collectibleActive5 = false;
    public bool collectibleActive6 = false;
    public bool collectibleActive7 = false;
    public bool collectibleActive8 = false;
    public bool collectibleActive9 = false;

    // Start is called before the first frame update
    void Start()
    {
        collectibles = 0;
    }

// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("You have: " + collectibles + " collectibles");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            collectibles++;
            
            collectibleActive = true;
            
            StartCoroutine(imageOff());

            Collectible_1.SetActive(false);
            CollectibleUI.SetActive(true);

            CollectibleButton1.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible2")
        {
            collectibles++;

            collectibleActive2 = true;

            StartCoroutine(imageOff());

            Collectible_2.SetActive(false);
            CollectibleUI2.SetActive(true);

            CollectibleButton2.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible3")
        {
            collectibles++;

            collectibleActive3 = true;

            StartCoroutine(imageOff());

            Collectible_3.SetActive(false);
            CollectibleUI3.SetActive(true);

            CollectibleButton3.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible4")
        {
            collectibles++;

            collectibleActive4 = true;

            StartCoroutine(imageOff());

            Collectible_4.SetActive(false);
            CollectibleUI4.SetActive(true);

            CollectibleButton4.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible5")
        {
            collectibles++;

            collectibleActive5 = true;

            StartCoroutine(imageOff());

            Collectible_5.SetActive(false);
            CollectibleUI5.SetActive(true);

            CollectibleButton5.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible6")
        {
            collectibles++;

            collectibleActive6 = true;

            StartCoroutine(imageOff());

            Collectible_6.SetActive(false);
            CollectibleUI6.SetActive(true);

            CollectibleButton6.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible7")
        {
            collectibles++;

            collectibleActive7 = true;

            StartCoroutine(imageOff());

            Collectible_7.SetActive(false);
            CollectibleUI7.SetActive(true);

            CollectibleButton7.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible8")
        {
            collectibles++;

            collectibleActive8 = true;

            StartCoroutine(imageOff());

            Collectible_8.SetActive(false);
            CollectibleUI8.SetActive(true);

            CollectibleButton8.SetActive(true);
        }

        if (other.gameObject.tag == "Collectible9")
        {
            collectibles++;

            collectibleActive9 = true;

            StartCoroutine(imageOff());

            Collectible_9.SetActive(false);
            CollectibleUI9.SetActive(true);

            CollectibleButton9.SetActive(true);
        }
    }




    IEnumerator imageOff()
    {
        yield return new WaitForSeconds(2f);
        CollectibleUI.SetActive(false);
        CollectibleUI2.SetActive(false);
        CollectibleUI3.SetActive(false);
        CollectibleUI4.SetActive(false);
        CollectibleUI5.SetActive(false);
        CollectibleUI6.SetActive(false);
        CollectibleUI7.SetActive(false);
        CollectibleUI8.SetActive(false);
        CollectibleUI9.SetActive(false);
    }


}
