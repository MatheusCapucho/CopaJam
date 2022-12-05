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

    private void Start()
    {

    }

    private void StartRun()
    {
        _rigidbody.gravityScale = _gravityScale;
        _rigidbody.AddForce(_direction * _speed * GameManager.Instance.SuperChuteira, ForceMode2D.Impulse);
        GameManager.OnGameStart?.Invoke();
    }

    public void SetupRun(Vector3 dir, float speed)
    {
        SetDirection(dir);
        SetSpeed(speed);
        StartRun();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.GameHasStarted)
            return;

        if (_rigidbody.velocity == Vector2.zero)
        {
            GameManager.OnGameEnd?.Invoke();
        }

    }

    private void SetDirection(Vector3 dir)
    {
        _direction = dir;
    }
    private void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void AddForce(Vector3 dir, float speed)
    {
        _rigidbody.AddForce(dir * speed * GameManager.Instance.SuperChuteira, ForceMode2D.Impulse);
    }

}
