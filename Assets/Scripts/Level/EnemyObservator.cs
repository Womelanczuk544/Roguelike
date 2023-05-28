using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObservator : MonoBehaviour
{
    private float time = 0;
    private float await = 0.3f;

    private bool once = true;
    private bool enemySlainFlag = false;

    public DoorManager manager;

    public PrizeGenerator prizeGenerator;

    void Update()
    {
        if (Enemy.getCounter() == 0)
        {
            time += Time.deltaTime;
            if (time > await && once)
            {
                if (enemySlainFlag == true)
                    prizeGenerator.generate();
                enemySlainFlag = false;                
                manager.open();
                once = false;
            }
        }
        else
        {
            enemySlainFlag = true;
            time = 0;
            once = true;
        }
    }
    public void resetOnce()
    {
        once = true;
    }
}
