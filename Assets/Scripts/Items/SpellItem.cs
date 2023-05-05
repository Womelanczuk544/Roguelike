using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellItem : Item
{
    public GameObject projectile;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void onAdd()
    {
        player.GetComponent<SpellController>().changeProjectile(projectile);
    }
    public override void onRemove()
    {
        player.GetComponent<SpellController>().returnBasicProjectile();
    }
    public override void triggerEffect() { }
}