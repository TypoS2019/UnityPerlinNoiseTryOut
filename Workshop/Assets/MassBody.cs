using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBody : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float mass;
    [SerializeField] private float force;
    private float raduis;
    private float maxSpeed = 2;
    public float G;
    

    void Start()
    {
        this.mass = rb.mass;
    }

    void Update()
    {
        print(Mathf.Abs(rb.velocity.y));
        if (Mathf.Abs(rb.velocity.y) < maxSpeed)
        {
            this.force = (G * mass) / (float)Math.Pow(-transform.position.y, 2);
            rb.AddForce(Vector3.up * this.force);
        }
    }
}
