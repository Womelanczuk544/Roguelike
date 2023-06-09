using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        animator = GetComponent<Animator>();
        canvas = GameObject.FindWithTag("canvas");
        roomGenerator = GameObject.FindWithTag("enemyGenerator");
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
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("Andrzej_scene");
        if (roomGenerator != null)
            roomGenerator.GetComponent<EnemyGenerator>().nextLevel();
    }

}
