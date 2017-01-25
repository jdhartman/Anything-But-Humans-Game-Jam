using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneOnClick: MonoBehaviour {

	public void LoadByIndex(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
