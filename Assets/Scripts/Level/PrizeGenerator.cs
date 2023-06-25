using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class PrizeGenerator : MonoBehaviour
{
    public GameObject teleport;

    public List<GameObject> prizes;

    private GameObject active1 = null;
    private GameObject active2 = null;

    private Vector3 xOffset = new Vector3(3.0f, 0, 0);
    public void generate()
    {
        int index1 = UnityEngine.Random.Range(0, prizes.Count);
        active1 = Instantiate(prizes[index1]);
        active1.transform.position = xOffset;
        int index2 = UnityEngine.Random.Range(0, prizes.Count);
        if (index1 == index2)
            index2++;
        if (index2 == prizes.Count)
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
    }
    // Update is called once per frame

    private void Update()
    {
        if (active1 == null && active2 == null) return;
        if (active1 != null && active1.GetComponent<Collider2D>().enabled == false)
        {            
            Destroy(active2);
            active2 = null;
        }
        if (active2 != null && active2.GetComponent<Collider2D>().enabled == false)
        {
            Destroy(active1);
            active1 = null;
        }
        /*if (active1 == null)
        {
            active2.SetActive(false);
        }
        if (active2 == null)
        {
            active1.SetActive(false);
        }*/
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
        }        
        if (active2 != null)
        {
            Destroy(active2);
        }
        active2 = null;
        active1 = null;
    }
}
