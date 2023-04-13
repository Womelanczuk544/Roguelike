using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleCreator : MonoBehaviour
{
    
    private Vector3 ytransformer = new Vector3(0, 10, 0);
    private Vector3 xtransformer = new Vector3(20, 0, 0);
    private Vector3 ycorrecttransformer = new Vector3(0, 4.5f , 0);
    private Vector3 xcorrecttransformer = new Vector3(5, 0, 0);

    public GameObject wallPrefab;
    public Transform middle;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(wallPrefab, middle.position, Quaternion.identity);
        Instantiate(wallPrefab, middle.position + ytransformer, Quaternion.identity);
        Instantiate(wallPrefab, middle.position + xtransformer, Quaternion.identity);
        Instantiate(wallPrefab, middle.position + ytransformer + xtransformer, Quaternion.identity);

        Instantiate(wallPrefab, middle.position - ycorrecttransformer + xcorrecttransformer, Quaternion.Euler(new Vector3(0, 0, 90f)));
        Instantiate(wallPrefab, middle.position + ycorrecttransformer + xcorrecttransformer + ytransformer, Quaternion.Euler(new Vector3(0, 0, 90f)));
        Instantiate(wallPrefab, middle.position - ycorrecttransformer - xcorrecttransformer + xtransformer, Quaternion.Euler(new Vector3(0, 0, 90f)));
        Instantiate(wallPrefab, middle.position + ycorrecttransformer - xcorrecttransformer + ytransformer + xtransformer, Quaternion.Euler(new Vector3(0, 0, 90f)));
    }
}