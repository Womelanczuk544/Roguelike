using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class TextShower : MonoBehaviour
{
    private bool flag=false;

    public Canvas text1;


    void Start()
    {
        text1.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            text1.enabled=true;
            flag=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            text1.enabled = false;
            flag = false;
        }
    }

    private void Update()
    {
        if (flag)
        {
            if(Input.GetKeyUp(KeyCode.E)) {

                SceneManager.LoadScene("Andrzej_scene");
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            SceneManager.LoadScene("Menu");
        }
    }

}
