using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    public void Resume()
    {
	Time.timeScale = 1;
	pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
	Time.timeScale = 1;
	SceneManager.LoadScene("MainMenu");
    }
}
