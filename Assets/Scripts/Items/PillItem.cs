using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
[System.Serializable]
public class PillItem : Item
{
    private float damage = 1;
    private float speed = 1;
    private float bonusHp =0;
    private float heal=0;
    public Text text;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //text = GameObject.Find("Text1").GetComponent<TextMeshProUGUI>();
        text.enabled = false;
        int index1 = UnityEngine.Random.Range(0, 4);
        switch(index1)
        {
            case 0:
                damage = 1.1f;
                text.text = "Damage up";
                break;
            case 1:
                speed = 1.1f;
                text.text = "Speed up";
                break;
            case 2:
                bonusHp = 10f;
                text.text = "Max health up";
                break;
            case 3:
                speed = 1.1f;
                text.text = "Speed up";
                break;
            case 4:
                damage = 1.1f;
                text.text = "Damage up";
                break;
        }
    }
    IEnumerator ShowText()
    {
        text.enabled = true;
        yield return new WaitForSeconds(0.1f);
        text.enabled = false;
    }
    public override void onAdd()
    {
        StartCoroutine(ShowText());
        player.GetComponent<PlayerController>().takeDamage(-heal);
        player.GetComponent<PlayerController>().changeDamage(damage);
        player.GetComponent<PlayerController>().changeSpeed(speed);
        player.GetComponent<PlayerController>().boostMaxHealth(bonusHp, true);
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