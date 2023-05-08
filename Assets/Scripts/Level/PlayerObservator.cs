using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObservator : MonoBehaviour
{
    private GameObject player;

    public EnemyGenerator enemyGenerator;
    public DoorManager manager;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager.roomEnter(true, false, true, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Transform>().position.x >= 11)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(-21, 0, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, false, true, true); //<- TU DODAC LABIRYNT (NP)
        }
        if (player.GetComponent<Transform>().position.x <= -11)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(21, 0, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, true, true, true);
        }
        if (player.GetComponent<Transform>().position.y >= 11)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(0, -21, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, true, true, true);
        }
        if (player.GetComponent<Transform>().position.y <= -11)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(0, 21, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, true, true, true);
        }
    }
}
