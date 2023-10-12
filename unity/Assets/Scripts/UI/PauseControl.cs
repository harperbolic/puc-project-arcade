using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{

    public static bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
    
    }

    void Update()
    {

	if (Input.GetButtonDown("Pause"))
	{
		gameIsPaused = !gameIsPaused;
		PauseGame();	
	}

    }

    void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;

	    pauseMenu.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;

	    pauseMenu.SetActive(false);
        }
    }
}