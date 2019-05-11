using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    public Scene senceToLoad;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Demo_tester");
    }
    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void Option()
    {
        SceneManager.LoadScene("menu-option");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        CompleteCameraController.setState(false);
    }
}
