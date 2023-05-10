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
        manager.roomEnter(true, false, true, true); //true sciana
                                                    //przejscie
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Transform>().position.x >= 12)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(-22, 0, 0));
            
            manager.roomEnter(false, false, true, true); //<- TU DODAC LABIRYNT (NP)

            enemyGenerator.generate();
        }
        if (player.GetComponent<Transform>().position.x <= -12)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(22, 0, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, true, true, true);
        }
        if (player.GetComponent<Transform>().position.y >= 12)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(0, -22, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, true, true, true);
        }
        if (player.GetComponent<Transform>().position.y <= -12)
        {
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(0, 22, 0));
            enemyGenerator.generate();
            manager.roomEnter(true, true, true, true);
        }
    }
}
