using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToFirstLocation : MonoBehaviour
{
    public void Update()
    {
        string nazwaSceny = SceneManager.GetActiveScene().name;
        if (nazwaSceny == "first_location")
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Debug.Log("wracamy byczq");
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                Debug.Log("wracamy byczq");
                SaveSystem.SavePlayer(GameObject.FindWithTag("Player").GetComponent<PlayerController>());
                SaveSystem.SaveLevel(EnemyGenerator.currentLevel);
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
