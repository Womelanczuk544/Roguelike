using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject interior;

    public void generate()
    {
        Instantiate(interior);
    }
}
