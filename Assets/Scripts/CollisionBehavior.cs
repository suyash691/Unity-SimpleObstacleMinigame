using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    const float TIME_LIMIT = 0.5f;
    private MeshRenderer _collisionMesh;
    private float _timer;
    private bool takenDamage;
    private int _hp;
    private GameObject _respawnPoint;
    private Material _normalMaterial;
    private Material _dmgMaterial;
    private GameObject _uiCanvas;

    public void Start() 
    {
        _collisionMesh = GetComponent<MeshRenderer>();
        _hp = 4;
        _respawnPoint = GameObject.Find("/RespawnPoint");
        _normalMaterial = GetComponent<Renderer>().material;
        _dmgMaterial = (Material)Resources.Load("Materials/PlayerDmgMaterial", typeof(Material));
        _uiCanvas = GameObject.Find("/Canvas");
    }

    public void OnCollisionEnter(Collision other) 
    {
        if (!String.Equals(other.collider.name, "Floor"))
        {
            Debug.Log(other.collider.name);
            _collisionMesh.material = _dmgMaterial;
            _timer = 0f;
            takenDamage = true;
            if (_hp > 1)
            {
                _hp -= 1;
            }
            else
            {
                respawnPlayer();
            }
        }
        if (String.Equals(other.collider.name, "DeathBox"))
        {
            respawnPlayer();
        }
    }

    public void Update() 
    {
        if (takenDamage)
        {
            _timer += Time.deltaTime;
            if (_timer >= TIME_LIMIT)
            {
                _collisionMesh.material = _normalMaterial;
                takenDamage = false;
            }
        }
    }

    private void respawnPlayer()
    {
        _hp = 10;
        transform.position = _respawnPoint.transform.position;
        _collisionMesh.material = _normalMaterial;
        takenDamage = false;
    }
}
