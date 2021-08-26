using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrapBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    private char _objectRelPos;
    private float _HorMovementSpeed = 600f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        char[] name = gameObject.name.ToCharArray();
        _objectRelPos = name[name.Length-1];
        switch (_objectRelPos)
        {
            case 'L':   _rb.velocity = (Vector3.right * _HorMovementSpeed * Time.deltaTime);
                         break;
            case 'R':   _rb.velocity = (Vector3.left * _HorMovementSpeed * Time.deltaTime);
                        break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other) 
    {
        switch (_objectRelPos)
        {
            case 'L': 
            {
                if (other.collider.name.StartsWith("DeathBall"))
                {
                    _rb.velocity = (Vector3.left * _HorMovementSpeed * Time.deltaTime);
                }
                if (other.collider.name.Contains("WallComponent"))
                {
                    _rb.velocity = (Vector3.right * _HorMovementSpeed * Time.deltaTime);
                }
                break;
            }
            case 'R':
            {
                if (other.collider.name.StartsWith("DeathBall"))
                {
                    _rb.velocity = (Vector3.right * _HorMovementSpeed * Time.deltaTime);
                }
                if (other.collider.name.Contains("WallComponent"))
                {
                    _rb.velocity = (Vector3.left * _HorMovementSpeed * Time.deltaTime);
                }
                break;
            }
        }
    }
}
