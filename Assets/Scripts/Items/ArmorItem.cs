using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
[System.Serializable]
public class ArmorItem : Item
{
    public float armor;
    public float speed;
    public float bonusHp;
    public float dashigtime;
    public override int classId()
    {
        return 3;
    }
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void onAdd()
    {
        Start();
        player.GetComponent<PlayerController>().changeDashingRecharge(dashigtime);
        player.GetComponent<PlayerController>().armor = armor;
        player.GetComponent<PlayerController>().changeSpeed(speed);
        player.GetComponent<PlayerController>().boostMaxHealth(bonusHp, true);
    }
    public override void onRemove()
    {
        Start();
        player.GetComponent<PlayerController>().changeDashingRecharge(1/dashigtime);
        player.GetComponent<PlayerController>().armor = 1;
        player.GetComponent<PlayerController>().changeSpeed(1/speed);
        player.GetComponent<PlayerController>().boostMaxHealth(-bonusHp, false);
    }
    public override void triggerEffect() { }
}