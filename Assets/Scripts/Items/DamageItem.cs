using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageItem : Item
{
    public float value;

    private float devalue;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        devalue = 1 / value;
    }
    public override void onAdd()
    {
        player.GetComponent<PlayerController>().changeDamage(value);
    }
    public override void onRemove()
    {
        player.GetComponent<PlayerController>().changeDamage(devalue);
    }
    public override void triggerEffect() { }
}

