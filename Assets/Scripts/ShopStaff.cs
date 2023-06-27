using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopStaff : MonoBehaviour
{
    private GameObject player;
    private GameObject shop;
    public Text text;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        shop = GameObject.FindWithTag("Shop");
    }

    public void addDashToHero()
    {
        if(shop.GetComponent<shop>().money >= 300) 
        {
            if (player.GetComponent<PlayerController>().dashRechargeTime > 0.5f)
            {
                shop.GetComponent<shop>().money -= 300;
                text.text = shop.GetComponent<shop>().money.ToString();

                if (player.GetComponent<PlayerController>().dashBought == false)
                {
                    shop.GetComponent<shop>().dashBought = true;
                    player.GetComponent<PlayerController>().dashBought = true;
                }
                else
                {
                    shop.GetComponent<shop>().dashRechargeTime /= 1.2f;
                    player.GetComponent<PlayerController>().dashRechargeTime /= 1.2f;
                }
                SaveSystem.SaveShop(GameObject.FindGameObjectWithTag("Shop").GetComponent<shop>());
            }
        }
    }

    public void addHealth()
    {
        if (shop.GetComponent<shop>().money >= 300)
        {
            shop.GetComponent<shop>().money -= 300;
            text.text = shop.GetComponent<shop>().money.ToString();
            shop.GetComponent<shop>().additionalMaxHealth += 20;
            player.GetComponent<PlayerController>().boostMaxHealth(20,true);
            player.GetComponent<PlayerController>().baseHealth += 20;
            SaveSystem.SaveShop(GameObject.FindGameObjectWithTag("Shop").GetComponent<shop>());
        }
    }

    public void addDamage()
    {
        if (shop.GetComponent<shop>().money >= 300 && player.GetComponent<PlayerController>().damageMultiplayer < 2.0f)
        {
            shop.GetComponent<shop>().money -= 300;
            text.text = shop.GetComponent<shop>().money.ToString();
            
                shop.GetComponent<shop>().damageMultiplayer *= 1.2f;
                player.GetComponent<PlayerController>().damageMultiplayer *= 1.2f;
            
            SaveSystem.SaveShop(GameObject.FindGameObjectWithTag("Shop").GetComponent<shop>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            getGold();
        }   
    }

    public void getGold()
    {
        shop.GetComponent<shop>().money += 1000;
        text.text = shop.GetComponent<shop>().money.ToString();
        SaveSystem.SaveShop(GameObject.FindGameObjectWithTag("Shop").GetComponent<shop>());
    }
}
