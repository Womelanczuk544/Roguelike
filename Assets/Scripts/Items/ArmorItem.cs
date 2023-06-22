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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        classId = 3;
    }
    public override void onAdd()
    {
        player.GetComponent<PlayerController>().changeDashingRecharge(dashigtime);
        player.GetComponent<PlayerController>().armor = armor;
        player.GetComponent<PlayerController>().changeSpeed(speed);
        player.GetComponent<PlayerController>().boostMaxHealth(bonusHp, true);
    }
    public override void onRemove()
    {
        player.GetComponent<PlayerController>().changeDashingRecharge(1/dashigtime);
        player.GetComponent<PlayerController>().armor = 1;
        player.GetComponent<PlayerController>().changeSpeed(1/speed);
        player.GetComponent<PlayerController>().boostMaxHealth(-bonusHp, false);
    }
    public override void triggerEffect() { }
}