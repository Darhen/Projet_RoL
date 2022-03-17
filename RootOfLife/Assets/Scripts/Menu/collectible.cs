using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{

    private int collectibles;

    public GameObject Collectible1;
    public GameObject CollectibleUI;

    // Start is called before the first frame update
    void Start()
    {
        collectibles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("You have: " + collectibles + " collectibles");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Collectible")
        {
            collectibles++;
            StartCoroutine(imageOff());
            other.gameObject.SetActive(false);
            CollectibleUI.SetActive(true);

            Collectible1.SetActive(true);
        }
    }

    IEnumerator imageOff()
    {
        yield return new WaitForSeconds(5f);
        CollectibleUI.SetActive(false);
    }


}
