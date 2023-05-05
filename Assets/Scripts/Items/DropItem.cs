using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : Item
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void onAdd()
    {
        player.GetComponent<InventoryController>().dropAllItems();
    }
    public override void onRemove()
    {

    }
    public override void triggerEffect() { }
}