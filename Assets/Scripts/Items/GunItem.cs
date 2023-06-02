using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : Item
{
    public float projectileForce;
    public int projectileSerie;
    public float rechargeTime;
    public float dmgMultiplayer;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void onAdd()
    {
        player.GetComponent<SpellController>().setProjectileForce(projectileForce);
        player.GetComponent<SpellController>().setRechargeTime(rechargeTime);
        player.GetComponent<SpellController>().setProjectileSerie(projectileSerie);
        //player.GetComponent<SpellController>(). <-change dmg
    }
    public override void onRemove()
    {
        player.GetComponent<SpellController>().returnBasicGun();
    }
    public override void triggerEffect() { }
}
