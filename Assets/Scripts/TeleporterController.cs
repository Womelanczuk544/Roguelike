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
        player.SetActive(false) ;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("isTeleporting", false);

        SceneManager.LoadScene("Andrzej_scene");//nie przenosi itemow
       player.SetActive(true);



        if (enemyGenerator != null)
            enemyGenerator.GetComponent<EnemyGenerator>().nextLevel();
    }

}
