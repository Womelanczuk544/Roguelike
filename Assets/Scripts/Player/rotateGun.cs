using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion rotationOffset;
    void Start()
    {
        //offset = transform.position;
        rotationOffset = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Vector2 direction = (mousePos - myPos).normalized;
        transform.right = direction;

        if (direction.x > 0)
        {
            transform.rotation *= rotationOffset;
        }
        else
        {
            transform.rotation *= new Quaternion(0,0,-rotationOffset.z, 1);
        }


    }
}
