using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour
{
    private bool isPlayerIn = false;

    public GameObject canvas;
    public GameObject enemyGenerator;
    private GameObject mainRoomGenerator;
    private Animator animator;
    private GameObject player;
    void Start()
    {
        animator = GetComponent<Animator>();
        canvas = GameObject.FindWithTag("canvas");
        enemyGenerator = GameObject.FindWithTag("enemyGenerator");
        player = GameObject.FindWithTag("Player");
        mainRoomGenerator = GameObject.Find("MainRoomGenerator");
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
<<<<<<< Updated upstream
=======
                SaveSystem.SaveInventory(player.GetComponent<InventoryController>().inventory);
                player.GetComponent<InventoryController>().dropAllItems();
>>>>>>> Stashed changes
                StartCoroutine(teleport());
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator teleport()
    {
        animator.SetBool("isTeleporting", true);
        player.active = false;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("isTeleporting", false);
<<<<<<< Updated upstream

        SceneManager.LoadScene("Andrzej_scene");//nie przenosi itemow
       player.SetActive(true);



        if (enemyGenerator != null)
            enemyGenerator.GetComponent<EnemyGenerator>().nextLevel();
=======
        
        SceneManager.LoadScene("Andrzej_scene");
        //player.SetActive(true);
        if (roomGenerator != null)
        {
            SaveSystem.SavePlayer(player.GetComponent<PlayerController>());
            roomGenerator.GetComponent<EnemyGenerator>().nextLevel();
            SaveSystem.SaveLevel(roomGenerator.GetComponent<EnemyGenerator>().getCurrnetLevel());
        }
>>>>>>> Stashed changes
    }

}
