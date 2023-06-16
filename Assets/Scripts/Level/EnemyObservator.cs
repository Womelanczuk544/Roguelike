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
    public GameObject enemyRoomGenerator;
    private EnemyGenerator enemyGenerator;
    public PrizeGenerator prizeGenerator;

    private void Start()
    {
        enemyGenerator = enemyRoomGenerator.GetComponent<EnemyGenerator>();
    }
    void Update()
    {
        if (Enemy.getCounter() == 0)
        {
            time += Time.deltaTime;
            if (time > await && once)
            {
                if (enemySlainFlag == true)
                {
                    if (enemyGenerator.playerIsInBossRoom)
                    {
                        prizeGenerator.generateTeleport();
                    }
                    else
                    {
                        prizeGenerator.generate();

                    }
                }
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
