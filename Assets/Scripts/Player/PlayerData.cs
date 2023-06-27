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
    public bool dashBought;
    public float dashRechargeTime;
    public int money;
    public float currentHealth;
    public float damageMultiplayer;
    public int level;
    public float dmg;
    public List<Item> inventory;

    public PlayerData(PlayerController player)
    {
        speed = player.speed;
        dashForce = player.dashForce;
        dashiingTime= player.dashiingTime;
        baseHealth= player.baseHealth;
        currentHealth = player.currentHealth;
        dmg = player.damageMultiplayer;
    }
    public PlayerData(List<Item> inventory)
    {
        this.inventory = inventory;
    }
    public PlayerData(shop shop)
    {
        money = shop.money;
        dashBought = shop.dashBought;
        dashRechargeTime = shop.dashRechargeTime;
        dmg = shop.damageMultiplayer;
    }

    public PlayerData(int tpLevel)
    {
        level = tpLevel;
    }

    public int getMoney ()
    {
        return money;
    }
}
