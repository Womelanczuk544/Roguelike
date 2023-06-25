using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveSystem
{

    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.restricted";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveShop(shop shop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.restricted";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(shop);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLevel(int tpLevel)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.restricted";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(tpLevel);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveInventory(List<Item> inventory)
    {
        List<String> inventoryNames = new List<String>();
        foreach (Item item in inventory)
        {
            inventoryNames.Add(item.name);
        }
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.restricted";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, inventoryNames);
        stream.Close();
    }
    public static List<String> LoadInventory()
    {
        string path = Application.persistentDataPath + "/inventory.restricted";
        Debug.Log("Loading inventory from: " + path);

        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                List<String> data = formatter.Deserialize(stream) as List<String>;
                stream.Close();

                Debug.Log("Inventory data loaded successfully.");
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError("Error while deserializing inventory data: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogError("Inventory data file does not exist: " + path);
            return null;
        }
    }
    public static void DeleteInventory()
    {
        string path = Application.persistentDataPath + "/inventory.restricted";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogError("sprawa sie rypla" + path + "nie ma go");
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.restricted";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("sprawa sie rypla" + path + "nie ma go");
            return null;
        }
    }

    public static PlayerData LoadShop()
    {
        string path = Application.persistentDataPath + "/shop.restricted";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("sprawa sie rypla" + path + "nie ma go");
            return null;
        }
    }

    public static PlayerData LoadLevel()
    {
        string path = Application.persistentDataPath + "/level.restricted";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("sprawa sie rypla" + path + "nie ma go");
            return null;
        }
    }

    public static bool levelExist()
    {
        string path3 = Application.persistentDataPath + "/level.restricted";
        if (File.Exists(path3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void DeleteLevel()
    {
        string path3 = Application.persistentDataPath + "/level.restricted";
        if (File.Exists(path3))
            File.Delete(path3);
    }

    public static void DeleteSave()
    {
        string path1 = Application.persistentDataPath + "/player.restricted";
        string path2 = Application.persistentDataPath + "/shop.restricted";
        string path3 = Application.persistentDataPath + "/level.restricted";
        if (File.Exists(path1))
            File.Delete(path1);
        if (File.Exists(path2))
            File.Delete(path2);
        if (File.Exists(path3))
            File.Delete(path3);
    }

}
