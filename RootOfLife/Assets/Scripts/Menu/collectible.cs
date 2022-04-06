using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{

    private int collectibles;

    public GameObject Collectible1;
    public GameObject Collectible2;
    public GameObject Collectible3;
    public GameObject Collectible4;
    public GameObject Collectible5;
    public GameObject Collectible6;
    public GameObject Collectible7;
    public GameObject Collectible8;
    public GameObject Collectible9;
    public GameObject CollectibleUI;
    public GameObject CollectibleUI2;
    public GameObject CollectibleUI3;
    public GameObject CollectibleUI4;
    public GameObject CollectibleUI5;
    public GameObject CollectibleUI6;
    public GameObject CollectibleUI7;
    public GameObject CollectibleUI8;
    public GameObject CollectibleUI9;
    public bool collectibleActive = false;

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

            other.gameObject.SetActive(false);
            CollectibleUI.SetActive(true);
            
            Collectible1.SetActive(true);

            if (other.gameObject.tag == "Collectible2")
            {
                collectibles++;

                collectibleActive = true;

                StartCoroutine(imageOff());

                other.gameObject.SetActive(false);
                CollectibleUI2.SetActive(true);

                Collectible2.SetActive(true);
            }
            if (other.gameObject.tag == "Collectible3")
            {
                collectibles++;

                collectibleActive = true;

                StartCoroutine(imageOff());

                other.gameObject.SetActive(false);
                CollectibleUI3.SetActive(true);

                Collectible3.SetActive(true);
            }
            if (other.gameObject.tag == "Collectible4")
            {
                collectibles++;

                collectibleActive = true;

                StartCoroutine(imageOff());

                other.gameObject.SetActive(false);
                CollectibleUI4.SetActive(true);

                Collectible4.SetActive(true);
            }
            if (other.gameObject.tag == "Collectible5")
            {
                collectibles++;

                collectibleActive = true;

                StartCoroutine(imageOff());

                other.gameObject.SetActive(false);
                CollectibleUI5.SetActive(true);

                Collectible5.SetActive(true);
            }   
                            if (other.gameObject.tag == "Collectible6")
                            {
                                collectibles++;

                                collectibleActive = true;

                                StartCoroutine(imageOff());

                                other.gameObject.SetActive(false);
                                CollectibleUI6.SetActive(true);

                            Collectible6.SetActive(true);
                            }
                                if (other.gameObject.tag == "Collectible7")
                                {
                                    collectibles++;

                                    collectibleActive = true;

                                    StartCoroutine(imageOff());

                                    other.gameObject.SetActive(false);
                                    CollectibleUI7.SetActive(true);

                                    Collectible7.SetActive(true);
                                }
                                    if (other.gameObject.tag == "Collectible8")
                                    {
                                        collectibles++;

                                        collectibleActive = true;

                                        StartCoroutine(imageOff());
                                        
                                        other.gameObject.SetActive(false);
                                        CollectibleUI8.SetActive(true);

                                        Collectible8.SetActive(true);
                                    }
                                        if (other.gameObject.tag == "Collectible9")
                                        {
                                            collectibles++;

                                            collectibleActive = true;

                                            StartCoroutine(imageOff());
                                          
                                            other.gameObject.SetActive(false);
                                            CollectibleUI9.SetActive(true);

                                            Collectible9.SetActive(true);
                                        }

 

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
