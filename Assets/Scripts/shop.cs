using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public static int money;
    public GameObject text;
    private bool canOpenShop = false;
    // Start is called before the first frame update
    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }
    public void LoadShop()
    {
        PlayerData data = SaveSystem.LoadShop();
        money = data.getMoney();
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
        if(canOpenShop && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Shop opened");
        }
    }

}
