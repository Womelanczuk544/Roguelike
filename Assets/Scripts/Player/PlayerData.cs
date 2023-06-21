using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float speed;
    public float dashForce;
    public float dashiingTime;
    public float baseHealth;
    public static int money;
    public float currentHealth;

    public PlayerData(PlayerController player)
    {
        speed = player.speed;
        dashForce = player.dashForce;
        dashiingTime= player.dashiingTime;
        baseHealth= player.baseHealth;
        currentHealth = player.currentHealth;
    }
    public PlayerData(shop shop)
    {
        money = shop.money;
    }

    public int getMoney ()
    {
        return money;
    }
}
