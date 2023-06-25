using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellItem : Item
{
    public GameObject projectile;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        classId = 1;
    }
    public override void onAdd()
    {
        Start();
        player.GetComponent<SpellController>().changeProjectile(projectile);
    }
    public override void onRemove()
    {
        Start();
        player.GetComponent<SpellController>().returnBasicProjectile();
    }
    public override void triggerEffect() { }
}