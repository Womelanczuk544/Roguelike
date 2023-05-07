using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public DoorManager manager;
    public GameObject interior;

    void Start()
    {
        manager.roomEnter(true, false, true, true);
        Instantiate(interior);
    }
    private void Update()
    {
        if (spawner.counter == 0 && EnemyController.counter == 0 && Schooting_enemy.counter == 0)
        {
            manager.open();
        }
    }

}
