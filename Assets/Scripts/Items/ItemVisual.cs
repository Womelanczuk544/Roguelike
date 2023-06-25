using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class ItemVisual : MonoBehaviour
{
    public Item item;
    public GameObject canvas;

    private bool isPlayerIn = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isPlayerIn)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                player.GetComponent<InventoryController>().add(item);
                StartCoroutine(seeText());
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            canvas.transform.Find("Text").gameObject.SetActive(true);
            isPlayerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
        {
            isPlayerIn = false;
            canvas.transform.Find("Text").gameObject.SetActive(false);
        }
    }

    IEnumerator seeText()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
