using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem : Item
{
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void onAdd()
    {
        Start();
        player.GetComponent<InventoryController>().dropAllItems();
    }
    public override void onRemove()
    {

    }
    public override void triggerEffect() { }
}