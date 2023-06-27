using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreShower : MonoBehaviour
{
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "SCORE: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "first_location")
            score.text = "SCORE: " + PlayerController.score;     
        else
            score.text = "MONEY: " + GameObject.FindWithTag("Shop").GetComponent<shop>().money;
    }
}
