using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{

    [SerializeField] private float _arrowAngleCicleDuration = 2f;
    [SerializeField] private float _arrowSpeedCicleDuration = 2f;
    [SerializeField] private float _forceMultiplier = 10f;

    [SerializeField] Transform _directionTransform;

    private bool _canMoveAngle;
    private bool _canMoveSpeed;

    private Tween _angleTween;
    private Tween _speedTween;

    private Vector2 _direction;
    private float _speed;

    [SerializeField]
    private PlayerController _player;

    void Start()
    {
        _canMoveAngle = true;
        _canMoveSpeed = false;

        StartTween();

    }

    private void OnEnable()
    {
        InputManager.Instance.OnTouchPressed += Interact;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnTouchPressed -= Interact;
    }


    private void StartTween()
    {
        _angleTween = transform.DORotate(new Vector3(0f, 0f, 80f), _arrowAngleCicleDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
        _speedTween = transform.DOScaleX(3f, _arrowSpeedCicleDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear)
            .Pause();
    }

    private void Interact()
    {
        if (_canMoveSpeed)
            StopArrowSpeed();

        if (_canMoveAngle)
            StopArrowAngle();

    }

    public void StopArrowAngle()
    {
        _canMoveAngle = false;
        _canMoveSpeed = true;

        _angleTween.Pause();
        _speedTween.Play();
    }
    private void SetDirection()
    {

        float yy = Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        float xx = Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        _direction = new Vector2(xx, yy).normalized;

    }

    private void StopArrowSpeed()
    {
        _canMoveSpeed = false;
        _speedTween.Pause();
        _speed = _forceMultiplier * transform.localScale.x;
        SetDirection();
        Debug.Log(_speed);

        _player.SetupRun(_direction, _speed); // !!
    }


}
