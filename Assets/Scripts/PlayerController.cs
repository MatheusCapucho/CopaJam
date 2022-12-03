using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _gravityScale = 1f;

    private Vector3 _direction;
    private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void StartRun()
    {
        _rigidbody.gravityScale = _gravityScale;
        _rigidbody.AddForce(_direction * _speed, ForceMode2D.Impulse);
    }

    public void SetupRun(Vector3 dir, float speed)
    {
        SetDirection(dir);
        SetSpeed(speed);
        StartRun();
    }

    private void SetDirection(Vector3 dir)
    {
        _direction = dir;
    }
    private void SetSpeed(float speed)
    {
        _speed = speed;
    }

}
