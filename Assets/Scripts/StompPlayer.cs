using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StompPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private float _timer;
    private Rigidbody rb;
    private bool _defaultPosition;
    [SerializeField]
    private float _downMovementSpeed = 36000f;
    [SerializeField]
    private float _upMovementSpeed = 800f;
    private float _cooldown;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _defaultPosition = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _cooldown + 2 && _defaultPosition)
        {
            rb.velocity = (Vector3.down * _downMovementSpeed * Time.deltaTime);
            _defaultPosition = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(rb.velocity.y == 0 || rb.velocity.y < 0)
        {
            rb.velocity = (Vector3.up * _upMovementSpeed * Time.deltaTime);
        }
        if (other.collider.name == "TrapHeightBoundary")
        {
            _defaultPosition = true;
            _cooldown = Time.time;
        }
    }
}
