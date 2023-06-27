using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellItem : Item
{
    public GameObject projectile;

    public override int classId()
    {
        return 1;
    }
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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