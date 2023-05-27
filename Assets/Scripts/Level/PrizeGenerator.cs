using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class PrizeGenerator : MonoBehaviour
{
    //private int prizeId;

    public GameObject variant1;
    public GameObject variant2;

    private int variantCount = 2;

    private List<GameObject> prizes;

    private GameObject active1 = null;
    private GameObject active2 = null;

    private Vector3 xOffset = new Vector3(3.0f, 0, 0);
    public void generate()
    {
        int index1 = UnityEngine.Random.Range(0, variantCount);
        active1 = Instantiate(prizes[index1]);
        active1.transform.position = xOffset;
        int index2 = UnityEngine.Random.Range(0, variantCount);
        if (index1 == index2)
            index2++;
        if (index2 == variantCount)
            index2 = 0;
        active2 = Instantiate(prizes[index2]);
        active2.transform.position = -xOffset;
        //utworzyc cale przedmioty tzn Ratatata + ItemVisual
    }
    // Start is called before the first frame update
    void Start()
    {
        prizes = new List<GameObject>();
        prizes.Add(variant1);
        prizes.Add(variant2);
    }
    // Update is called once per frame
    public void remove()
    {
        if (active1 != null)
            Destroy(active1);
        active1 = null;
        if (active2 != null)
            Destroy(active2);
        active2 = null;
    }
}
