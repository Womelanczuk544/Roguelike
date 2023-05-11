using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PortalRotation : MonoBehaviour
{
    private float angle;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        angle++;
        rb.rotation = angle;
    }
}
