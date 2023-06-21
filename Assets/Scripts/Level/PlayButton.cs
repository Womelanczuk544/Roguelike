using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayButton : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        if (SaveSystem.levelExist())
        {
            SceneManager.LoadScene("Andrzej_scene");
        }
        else
        {
        SceneManager.LoadScene(sceneName);
        Debug.Log("ci�niesz mnie chopie");
        }
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("ci�niesz mnie chopie zara wyleza");
    }
}
