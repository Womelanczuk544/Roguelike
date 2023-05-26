using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapContorller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject generator;
    private PlayerObservator observator;
    private int playerX, playerY;
    private int prevPozX, prevPozY;
    void Start()
    {
       observator =  generator.GetComponent<PlayerObservator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerX = observator.playerPosOnMapX;
        playerY = observator.playerPosOnMapY;
        if (playerX == 0 || playerY == 0 || prevPozX == 0 || prevPozY == 0)
        {
            prevPozX = playerX;
            prevPozY = playerY;
            return;
        }
       
        GameObject currRoom = transform.Find(playerX.ToString() + " " + playerY.ToString() +"(Clone)").gameObject;
        currRoom.transform.Find("icon").gameObject.SetActive(true);

        if (playerX != prevPozX || playerY != prevPozY)
        {
            GameObject prevRoom = transform.Find(prevPozX.ToString() + " " + prevPozY.ToString() + "(Clone)").gameObject;
            prevRoom.transform.Find("icon").gameObject.SetActive(false);
            prevRoom.transform.Find("bg").gameObject.SetActive(false);
        }

        prevPozX = playerX;
        prevPozY = playerY;
    }
}
