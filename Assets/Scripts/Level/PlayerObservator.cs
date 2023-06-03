using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObservator : MonoBehaviour
{
    private GameObject player;

    public EnemyObservator enemyObservator;
    public EnemyGenerator enemyGenerator;
    public DoorManager manager;

    private GenerateLabirynt generate;
    public int playerPosOnMapX, playerPosOnMapY;
    string currRoom;
    void Start()
    {

        generate = GetComponent<GenerateLabirynt>();
        playerPosOnMapX = generate.startingPosX;
        playerPosOnMapY = generate.startingPosY;
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(generateFirstRoom());
      /*  currRoom = generate.finishedMap[playerPosOnMapX, playerPosOnMapY];
        manager.roomEnter(currRoom[0] == '0', currRoom[2] == '0', currRoom[1] == '0', currRoom[3] == '0'); //true sciana*/
                                                    //przejscie
    }

    IEnumerator generateFirstRoom()
    {
        while (generate.numOfRoomsDone <= 0)
        {
            yield return null;
        }
        currRoom = generate.finishedMap[playerPosOnMapX, playerPosOnMapY];
        manager.roomEnter(currRoom[0] == '0', currRoom[2] == '0', currRoom[1] == '0', currRoom[3] == '0'); //true sciana

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Transform>().position.x >= 19)
        {
            currRoom = currRoom.Remove(currRoom.Length - 1);
            currRoom += '1';
            generate.finishedMap[playerPosOnMapX, playerPosOnMapY] = currRoom;
            playerPosOnMapX++;
            currRoom = generate.finishedMap[playerPosOnMapX, playerPosOnMapY];
            //enemyGenerator.remove();
            Cleaner.clear();
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(-36.5f, 0, 0));
            if (currRoom[4] == '0')
            {
                enemyGenerator.generate();
            }
            manager.roomEnter(currRoom[0] == '0', currRoom[2] == '0', currRoom[1] == '0', currRoom[3] == '0'); //<- TU DODAC LABIRYNT (NP)
            enemyObservator.resetOnce();
        }
        if (player.GetComponent<Transform>().position.x <= -19.5)
        {
            currRoom = currRoom.Remove(currRoom.Length - 1);
            currRoom += '1';
            generate.finishedMap[playerPosOnMapX, playerPosOnMapY] = currRoom;
            playerPosOnMapX--;
            currRoom = generate.finishedMap[playerPosOnMapX, playerPosOnMapY];
            //enemyGenerator.remove();
            Cleaner.clear();
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(36.5f, 0, 0));
            if (currRoom[4] == '0')
            {
                enemyGenerator.generate();
            }
            manager.roomEnter(currRoom[0] == '0', currRoom[2] == '0', currRoom[1] == '0', currRoom[3] == '0');
            enemyObservator.resetOnce();
        }
        if (player.GetComponent<Transform>().position.y >= 12)
        {
            currRoom = currRoom.Remove(currRoom.Length - 1);
             currRoom += '1';
            generate.finishedMap[playerPosOnMapX, playerPosOnMapY] = currRoom;
            playerPosOnMapY++;
            currRoom = generate.finishedMap[playerPosOnMapX, playerPosOnMapY];
            //enemyGenerator.remove();
            Cleaner.clear();
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(0, -20.5f, 0));
            if (currRoom[4] == '0')
            {
                enemyGenerator.generate();
            }
            manager.roomEnter(currRoom[0] == '0', currRoom[2] == '0', currRoom[1] == '0', currRoom[3] == '0');
            enemyObservator.resetOnce();
        }
        if (player.GetComponent<Transform>().position.y <= -10.5)
        {
            currRoom = currRoom.Remove(currRoom.Length - 1);
            currRoom += '1';
            generate.finishedMap[playerPosOnMapX, playerPosOnMapY] = currRoom;
            playerPosOnMapY--;
            currRoom = generate.finishedMap[playerPosOnMapX, playerPosOnMapY];
           // enemyGenerator.remove();
            Cleaner.clear();
            manager.clear();
            player.GetComponent<Transform>().Translate(new Vector3(0, 20.5f, 0));
            if (currRoom[4] == '0')
            {
                enemyGenerator.generate();
            };
            manager.roomEnter(currRoom[0] == '0', currRoom[2] == '0', currRoom[1] == '0', currRoom[3] == '0');
            enemyObservator.resetOnce();
        }
        
    }
}
