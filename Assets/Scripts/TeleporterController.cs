using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class TeleporterController : MonoBehaviour
{
    private bool isPlayerIn = false;

    public GameObject canvas;
    public GameObject roomGenerator;
    private Animator animator;
    private GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
        canvas = GameObject.FindWithTag("canvas");
        roomGenerator = GameObject.FindWithTag("enemyGenerator");
        player = GameObject.FindWithTag("Player");
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

            canvas.transform.Find("Text").gameObject.SetActive(false);
            isPlayerIn = false;
        }
    }

    private void Update()
    {
        if (isPlayerIn)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                SaveSystem.SaveInventory(player.GetComponent<InventoryController>().inventory);
                StartCoroutine(teleport());
            }
        }
    }

    IEnumerator teleport()
    {
            
        animator.SetBool("isTeleporting", true);
        player.SetActive(false) ;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("isTeleporting", false);

   
        SceneManager.LoadScene("Andrzej_scene");
        //player.SetActive(true);
        if (roomGenerator != null)
        {
            SaveSystem.SavePlayer(player.GetComponent<PlayerController>());
            roomGenerator.GetComponent<EnemyGenerator>().nextLevel();
            SaveSystem.SaveLevel(roomGenerator.GetComponent<EnemyGenerator>().getCurrnetLevel());
    
        }
    }

}
