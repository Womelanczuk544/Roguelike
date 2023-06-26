using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public static int money;
    public GameObject text;
    public Text moneyText;
    private bool canOpenShop = false;
    private bool canCloseShop = false;
    public Canvas shopCanvas;
    public Canvas firstLocationCanvas;


    private void Start()
    {
        Debug.Log(money);
        if(shopCanvas != null)
        {
            shopCanvas.enabled = false;
        }
        if(firstLocationCanvas != null)
        {
            firstLocationCanvas.enabled = true;
        }
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
