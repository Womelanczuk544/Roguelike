using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minMapCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roomInfo;
    private PlayerObservator observator;
    private float x, y;
    void Start()
    {
        observator = roomInfo.GetComponent<PlayerObservator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = observator.playerPosOnMapX * 1.1f + 100;
        y = observator.playerPosOnMapY * 1.1f + 100;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
