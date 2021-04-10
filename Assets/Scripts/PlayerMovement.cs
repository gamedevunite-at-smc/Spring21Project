﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float dragSpeed = 30.0f;

    private new Rigidbody2D rigidbody;

    private BulletSystem bulletSystem;

    // Start is called before the first frame update
    void FixedUpdate()
    {

        Vector2 velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector2.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector2.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector2.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector2.down * speed * Time.deltaTime;
        }

        rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, Vector2.zero, dragSpeed * Time.deltaTime);

        rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity + velocity, maxSpeed);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletSystem.StartShooting();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bulletSystem.StopShooting();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit player");
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        bulletSystem = GetComponentInChildren<BulletSystem>();
    }
}
