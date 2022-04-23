using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LEVEL_GROTTE_OFFICIEL", LoadSceneMode.Single);
            SceneManager.LoadScene("LEVEL_GROTTE_OFFICIEL SECTION 2", LoadSceneMode.Additive);
        }
    }
}
