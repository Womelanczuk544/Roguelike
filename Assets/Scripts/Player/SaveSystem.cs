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
        string path = Application.persistentDataPath + "/player.resticted";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveShop(shop shop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.resticted";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(shop);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLevel(int tpLevel)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.resticted";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(tpLevel);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveInventory(List<Item> inventory)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.resticted";
        FileStream stream;
        stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, inventory);
        stream.Close();
    }
    public static List<Item> LoadInventory()
    {
        string path = Application.persistentDataPath + "/inventory.resticted";
        Debug.Log("Loading inventory from: " + path);

        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                List<Item> data = formatter.Deserialize(stream) as List<Item>;
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
        string path = Application.persistentDataPath + "/inventory.resticted";
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
        string path = Application.persistentDataPath + "/player.resticted";
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
        string path = Application.persistentDataPath + "/shop.resticted";
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
        string path = Application.persistentDataPath + "/level.resticted";
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
        string path3 = Application.persistentDataPath + "/level.resticted";
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
        string path3 = Application.persistentDataPath + "/level.resticted";
        if (File.Exists(path3))
            File.Delete(path3);
    }

    public static void DeleteSave()
    {
        string path1 = Application.persistentDataPath + "/player.resticted";
        string path2 = Application.persistentDataPath + "/shop.resticted";
        string path3 = Application.persistentDataPath + "/level.resticted";
        if (File.Exists(path1))
            File.Delete(path1);
        if (File.Exists(path2))
            File.Delete(path2);
        if (File.Exists(path3))
            File.Delete(path3);
    }

}
