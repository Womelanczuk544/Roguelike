using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemVisual : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAA");
            collision.gameObject.GetComponent<InventoryController>().add(item);
<<<<<<< Updated upstream
            Destroy(gameObject);
=======
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
>>>>>>> Stashed changes
        }
    }
}
