using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapGeneraor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tile;
    public GameObject generator;
    private string[,] labirynt;

    void Start()
    {
       /* labirynt = generator.GetComponent<GenerateLabirynt>().finishedMap;
        for (int i = 0; i < labirynt.Length; i++)
        {
            for (int j = 0; j < labirynt.Length; j++)
            {
                if (labirynt[i,j] != null)
                {

                print(labirynt[i, j]);
                }
            }
        }*/

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
