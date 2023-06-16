using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeGenerator : MonoBehaviour
{
    //private int prizeId;

    public GameObject variant1; //Tu zmieniac
    public GameObject variant2;
    public GameObject variant3;
    public GameObject variant4;
    public GameObject variant5;
    public GameObject gvariant1; //Tu zmieniac
    public GameObject gvariant2;
    public GameObject gvariant3;
    public GameObject gvariant4;
    public GameObject gvariant5; // co to tablica xd

    public GameObject teleport;

    private int variantCount = 10; //tu zmienic

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

        Cleaner.add(active1);
        Cleaner.add(active2);
    }

    public bool getList(List<GameObject> _prizes)
    {
        prizes = _prizes;
        if (prizes.Count >= 2)
            return true;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        prizes = new List<GameObject>();    //tu dodac
        prizes.Add(variant1);
        prizes.Add(variant2);
        prizes.Add(variant3);
        prizes.Add(variant4);
        prizes.Add(variant5);
        prizes.Add(gvariant1);
        prizes.Add(gvariant2);
        prizes.Add(gvariant3);
        prizes.Add(gvariant4);
        prizes.Add(gvariant5);
    }
    // Update is called once per frame

    private void Update()
    {
        if (active1 == null && active2 == null)
            return;
        if (active1 == null)
        {            
            if (active2 !=null)
                Destroy(active2);
            active2 = null;
        }
        if (active2 == null)
        {
            if (active1 != null)
                Destroy(active1);
            active1 = null;
        }
    }

    public void generateTeleport()
    {
        GameObject tp = Instantiate(teleport,new Vector3(0,0,0), Quaternion.identity);
        Cleaner.add(tp);
    }
    public void remove()
    {
        if (active1 != null)
        {
            Destroy(active1);
            Destroy(active2);
        }        
        if (active2 != null)
        {
            Destroy(active2);
            Destroy(active1);
        }
        active2 = null;
        active1 = null;
    }
}
