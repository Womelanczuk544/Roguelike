using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static int counter = 0; 

    protected void onCreate()
    {
        counter++;
    }
    protected void OnDestroy()
    {
        counter--;
    }
    public static int getCounter()
    {
        return counter;
    }
}
