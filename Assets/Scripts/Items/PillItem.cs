using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
[System.Serializable]
public class PillItem : Item
{
    private float damage = 1;
    private float speed = 1;
    private float bonusHp =0;
    private float heal=0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int index1 = UnityEngine.Random.Range(0, 4);
        switch(index1)
        {
            case 0: damage = 1.1f; break;
            case 1: speed = 1.1f; break;
            case 2: bonusHp = 10f; break;
            case 3: damage = 1.1f; break;
            case 4: speed = 1.1f; break;
        }
    }
    public override void onAdd()
    {
        player.GetComponent<PlayerController>().takeDamage(-heal);
        player.GetComponent<PlayerController>().changeDamage(damage);
        player.GetComponent<PlayerController>().changeSpeed(speed);
        player.GetComponent<PlayerController>().boostMaxHealth(bonusHp, false);
    }
    public override void onRemove()
    {
        player.GetComponent<PlayerController>().armor = 1;
        player.GetComponent<PlayerController>().changeSpeed(1 / speed);
        player.GetComponent<PlayerController>().changeDamage(1 / damage);
        player.GetComponent<PlayerController>().boostMaxHealth(-bonusHp, false);
    }
    public override void triggerEffect() { }
}