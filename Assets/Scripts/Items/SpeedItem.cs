using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item
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
        player.GetComponent<PlayerController>().changeSpeed(value);
    }
    public override void onRemove() 
    {
        player.GetComponent<PlayerController>().changeSpeed(devalue);
    }
    public override void triggerEffect() { }
}
