using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreen : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "GOLD EARNED " + PlayerController.score.ToString();
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().clearScore();
    }

}
