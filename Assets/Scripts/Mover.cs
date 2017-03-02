using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float destroyTime;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * speed;
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        if(rb.position.y >= 0.0f)
        {
            rb.velocity = Vector3.up * -speed;
        }
    }
}