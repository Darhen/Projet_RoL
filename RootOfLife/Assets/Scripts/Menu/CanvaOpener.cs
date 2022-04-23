using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvaOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public GameObject pauseFirstButton;

    menuStormFrei menu;

    private void Start()
    {
        menu = gameObject.GetComponentInParent<menuStormFrei>();
    }

    private void Update()
    {
       
    }
    public void openPanel()
    {
        {
            if (Panel != null)
            {
                {
                    Panel.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(pauseFirstButton);
                }
            }
        }
    }

    public void closePanel()
    {
        {
            if (Panel != null)
            {
                Panel2.SetActive(false);
                {
                    if(this.gameObject.tag == "TaRace")
                    {
                        menu.Reprendre();
                    }
                }
            }
        }
    }
}
