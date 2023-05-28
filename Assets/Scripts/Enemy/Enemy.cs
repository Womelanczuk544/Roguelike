using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static int enemyCounter = 0;

    public virtual void takeDamage(float damage)
    {

    }
    public static int getCounter()
    {
        return enemyCounter;
    }

    public void onCreate()
    {
        enemyCounter++;
    }

    public void OnDestroy()
    {
        enemyCounter--;
    }
}
