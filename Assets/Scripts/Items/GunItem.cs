using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
[System.Serializable]
public class GunItem : Item
{
    public float projectileForce;
    public int projectileSerie;
    public float rechargeTime;
    public float dmgMultiplayer;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        classId = 2;
    }
    public override void onAdd()
    {
        Start();
        player.GetComponent<SpellController>().setProjectileForce(projectileForce);
        player.GetComponent<SpellController>().setRechargeTime(rechargeTime);
        player.GetComponent<SpellController>().setProjectileSerie(projectileSerie);
        player.GetComponent<PlayerController>().setDamage(dmgMultiplayer);
    }
    public override void onRemove()
    {
        player.GetComponent<SpellController>().returnBasicGun();
        player.GetComponent<PlayerController>().setDamage(1);            
    }
    public override void triggerEffect() { }
}
