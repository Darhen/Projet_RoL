using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;

    menuStormFrei menu;

    void Start()
    {
        menu = gameObject.GetComponentInParent<menuStormFrei>();  
    }
    public void openPanel()
    {
        {
            if (Panel != null)
            {
                {
                    Panel.SetActive(true);
                }
            }
        }
    }

    public void closePanel()
    {
        {
            if (Panel != null)
            {
                Panel.SetActive(false);
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
