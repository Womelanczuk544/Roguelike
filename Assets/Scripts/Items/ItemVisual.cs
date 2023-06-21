using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class ItemVisual : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            collision.gameObject.GetComponent<InventoryController>().add(item);
            gameObject.SetActive(false);
        }
    }
}
