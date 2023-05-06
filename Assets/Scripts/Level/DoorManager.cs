using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class DoorManager : MonoBehaviour
{    
    private Vector3 yOffset = new Vector3(0, 12.25f, 0);
    private Vector3 yCorrect = new Vector3(0, 2.75f, 0);
    private Vector3 xOffset = new Vector3(11, 0, 0);
    private Quaternion rot90 = Quaternion.Euler(new Vector3(0, 0, 90f));

    private bool upDoor;
    private bool downDoor;
    private bool leftDoor;
    private bool rightDoor;

    private GameObject leftDoorObj;
    private GameObject rightDoorObj;
    private GameObject upDoorObj;
    private GameObject downDoorObj;

    public GameObject wallPrefab;
    public GameObject temporaryWallPrefab;
    public Transform pos;

    private void Start()
    {
        roomEnter(true, true, false, true); //Narazie tu, potem gdzies indziej
    }
    public void roomEnter(bool left, bool right, bool up, bool down)
    {
        upDoor = up;
        downDoor = down;
        leftDoor = left;
        rightDoor = right;
        close();
    }
    public void close()
    {
        if(leftDoor==true)
            leftDoorObj = Instantiate(wallPrefab, pos.position - xOffset, Quaternion.identity);
        else
            leftDoorObj = Instantiate(temporaryWallPrefab, pos.position - xOffset, Quaternion.identity);
        if(rightDoor==true)
            rightDoorObj = Instantiate(wallPrefab, pos.position + xOffset, Quaternion.identity);
        else
            rightDoorObj = Instantiate(temporaryWallPrefab, pos.position + xOffset, Quaternion.identity);
        if(upDoor==true)
            upDoorObj = Instantiate(wallPrefab, pos.position + yOffset, rot90);
        else
            upDoorObj = Instantiate(temporaryWallPrefab, pos.position + yOffset, rot90);
        if(downDoor==true)
            downDoorObj = Instantiate(wallPrefab, pos.position - yOffset + yCorrect, rot90);
        else
            downDoorObj = Instantiate(temporaryWallPrefab, pos.position - yOffset + yCorrect, rot90);
    }
    public void open()
    {
        if(leftDoor==false)
            Destroy(leftDoorObj);
        if (rightDoor == false)
            Destroy(rightDoorObj);
        if (upDoor == false)
            Destroy(upDoorObj);
        if (downDoor == false)
            Destroy(downDoorObj);
    }
    public void clear()
    {
        Destroy(leftDoorObj);
        Destroy(rightDoorObj);
        Destroy(upDoorObj);
        Destroy(downDoorObj);
    }
}