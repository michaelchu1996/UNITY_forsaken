using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    public static bool temp;

    private void Start()
    {
         
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Samplescene");
    }
    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void Resume()
    {
        //Time.timeScale = 1;

        print("haha");

        temp = CompleteCameraController.getState();
        temp = temp == false ? true : false;
        CompleteCameraController.setState(temp);

    }

}
