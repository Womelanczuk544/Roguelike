using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageItem : Item
{
    public float value;

    private float devalue;
    public override int classId()
    {
        return 0;
    }
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        devalue = 1 / value;
    }
    public override void onAdd()
    {
        Start();
        player.GetComponent<PlayerController>().changeDamage(value);
    }
    public override void onRemove()
    {
        Start();
        player.GetComponent<PlayerController>().changeDamage(devalue);
    }
    public override void triggerEffect() { }
}

