using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntityMovement : MonoBehaviour
{
    private Vector3 _movementInput;
    private Rigidbody rb;
    [SerializeField]
    private float _speed = 400f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (_movementInput * _speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputVec = context.ReadValue<Vector2>();
        _movementInput = new Vector3(inputVec.x, 0, inputVec.y);
    }
}
