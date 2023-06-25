using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpeedItem : Item
{
    public float value;

    private float devalue;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        devalue = 1 / value;
    }
    public override void onAdd()
    {
        Start();
        player.GetComponent<PlayerController>().changeSpeed(value);
    }
    public override void onRemove() 
    {
        Start();
        player.GetComponent<PlayerController>().changeSpeed(devalue);
    }
    public override void triggerEffect() { }
}
