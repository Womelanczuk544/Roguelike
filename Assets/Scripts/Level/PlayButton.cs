using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayButton : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("ciœniesz mnie chopie");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("ciœniesz mnie chopie zara wyleza");
    }
}
