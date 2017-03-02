using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMover : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * speed;
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        if (rb.position.y >= 0.4f)
        {
            rb.velocity = Vector3.up * -speed;
        }
    }
}
