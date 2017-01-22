using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject optionsMenu;

	public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void backToPause()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void exitToMainMenu(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    } 
}
