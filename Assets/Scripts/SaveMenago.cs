using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenago : MonoBehaviour
{
    // Start is called before the first frame update
    public void savePlayer()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().SavePlayer();
    }
    public void loadPlayer()
    {
        Debug.Log("ciœniesz mnie chopie");
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().LoadPlayer();
    }
    public void saveShop()
    {
        GameObject.FindWithTag("Shop").GetComponent<shop>().SaveShop();
        
    }
    public void loadShop()
    {
        GameObject.FindWithTag("Shop").GetComponent<shop>().LoadShop();
    }
    public void deleteSave()
    {
        SaveSystem.DeleteSave();
    }
}
