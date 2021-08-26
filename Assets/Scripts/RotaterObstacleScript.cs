using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RotaterObstacleScript : MonoBehaviour
{
    [SerializeField]
    public float TrapRotateSpeed = (float)(1.0f/0.0145767f); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,(TrapRotateSpeed * Time.deltaTime), 0);
    }
}
