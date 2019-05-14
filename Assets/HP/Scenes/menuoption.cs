using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menuoption : MonoBehaviour
{
    public Scene senceToLoad;

    // Start is called before the first frame update
    public void menu()
    {
        SceneManager.LoadScene("Startscene");
    }
    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void setResol(int w) {

        switch (w)
        {
            case 0:
                Screen.SetResolution(1024, 768, true);
                Debug.Log("A");
                break;
            case 1:
                Screen.SetResolution(1600, 900, true);
                Debug.Log("B");
                break;
            case 2:
                Screen.SetResolution(1600, 1000, true);
                Debug.Log("C");
                break;
            default:
                Screen.SetResolution(1024, 768, true);
                break;

        }
    }

    public void setVolume(float temp)
    {
        AudioListener.volume = temp;
    }
}