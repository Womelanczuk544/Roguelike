using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class DoorManager : MonoBehaviour
{    
    private Vector3 leftOffset = new Vector3(-18.61f, 0.59f, 0);
    private Vector3 rightOffset = new Vector3(17.43f, 0.6f, 0);
    private Vector3 upOffset = new Vector3(-0.61f, 11.43f, 0);
    private Vector3 downOffset = new Vector3(-0.6f, -10.22f, 0);
    private Quaternion rot90 = Quaternion.Euler(new Vector3(0, 0, 90f));
    private Quaternion rot180 = Quaternion.Euler(new Vector3(0, 0, 180f));
    private Quaternion rot270 = Quaternion.Euler(new Vector3(0, 0, 270f));

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
            leftDoorObj = Instantiate(wallPrefab, pos.position + leftOffset, Quaternion.identity);
        else
            leftDoorObj = Instantiate(temporaryWallPrefab, pos.position + leftOffset, Quaternion.identity);
        if(rightDoor==true)
            rightDoorObj = Instantiate(wallPrefab, pos.position + rightOffset, rot180);
        else
            rightDoorObj = Instantiate(temporaryWallPrefab, pos.position + rightOffset, rot180);
        if(upDoor==true)
            upDoorObj = Instantiate(wallPrefab, pos.position + upOffset, rot270);
        else
            upDoorObj = Instantiate(temporaryWallPrefab, pos.position + upOffset, rot270);
        if(downDoor==true)
            downDoorObj = Instantiate(wallPrefab, pos.position + downOffset, rot90);
        else
            downDoorObj = Instantiate(temporaryWallPrefab, pos.position + downOffset, rot90);
    }
    public void open()
    {
        Debug.Log("Otwarto");
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