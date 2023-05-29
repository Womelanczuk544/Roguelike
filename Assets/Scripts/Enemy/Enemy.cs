using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static int enemyCounter = 0;

    public virtual void takeBloodDamage(float damage)
    {

    }
    public virtual void takeDamage(float damage)
    {
        Debug.Log("coooooo");
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
