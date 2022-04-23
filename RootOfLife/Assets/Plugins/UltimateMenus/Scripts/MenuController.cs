using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour 
{

	public string canvasIndex; // The string which defines which canvas is being loaded at any given point in time
	public string startingCanvasIndex; // The string which tells the game which canvas to start on

    public GameObject pauseFirstButton;

    void Start()
	{
        canvasIndex = startingCanvasIndex; // We set the current canvas index equal to that of the starting canvas index string
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }
}
