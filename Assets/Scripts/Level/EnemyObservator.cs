using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObservator : MonoBehaviour
{
    private float time = 0;
    private float await = 1;
    private bool once = true;

    public DoorManager manager;

    public PrizeGenerator prizeGenerator;

    void Update()
    {
        if (spawner.counter == 0 && EnemyController.counter == 0 && Schooting_enemy.counter == 0)
        {
            time += Time.deltaTime;
            if (time > await && once)
            {
                prizeGenerator.generate();
                manager.open();
                once = false;
            }
        }
        else
        {
            time = 0;
            once = true;
        }
    }
    public void resetOnce()
    {
        once = true;
    }
}
