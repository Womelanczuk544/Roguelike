using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public static int money;
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
}
