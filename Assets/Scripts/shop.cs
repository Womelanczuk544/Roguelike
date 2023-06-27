using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public int money;
    public GameObject text;
    public Text moneyText;
    private bool canOpenShop = false;
    private bool canCloseShop = false;
    public Canvas shopCanvas;
    public Canvas firstLocationCanvas;
    public bool dashBought = false;
    public float dashRechargeTime = 2f;
    public float additionalMaxHealth = 0;
    public float damageMultiplayer = 1;


    private void Start()
    {
        if(shopCanvas != null)
        {
            shopCanvas.enabled = false;
        }
        if(firstLocationCanvas != null)
        {
            firstLocationCanvas.enabled = true;
        }
        if(SaveSystem.LoadShop()!=null)
        {
            PlayerData data = SaveSystem.LoadShop();
            money = data.getMoney();
            dashBought = data.dashBought;
            dashRechargeTime = data.dashRechargeTime;
            damageMultiplayer = data.damageMultiplayer;

        }
        Debug.Log(money);
    }
    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }
    public void LoadShop()
    {
        PlayerData data = SaveSystem.LoadShop();
        money = data.getMoney();
    }

    public int getMoney()
    {
        return money;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        canOpenShop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
        canOpenShop = false;
    }

    private void Update()
    {
       
        if(canOpenShop && Input.GetKeyDown(KeyCode.E) && !canCloseShop)
        {
            canCloseShop= true;
            Debug.Log("Shop opened");
            moneyText.text = money.ToString();
            shopCanvas.enabled = true;
            firstLocationCanvas.enabled = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled=false;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindWithTag("Player").GetComponent<SpellController>().enabled=false;
        }
        else if (canOpenShop && Input.GetKeyDown(KeyCode.E) && canCloseShop)
        {
            canCloseShop = false;
            Debug.Log("Shop opened");
            shopCanvas.enabled = false;
            firstLocationCanvas.enabled = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = true;
            GameObject.FindWithTag("Player").GetComponent<SpellController>().enabled = true;
        }
    }

}
