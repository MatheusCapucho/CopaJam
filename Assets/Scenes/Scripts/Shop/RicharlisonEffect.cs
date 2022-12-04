using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RicharlisonEffect : MonoBehaviour, IEffect
{
    [SerializeField] private ShopItem _item;
    [SerializeField] private float _addForce = 10f;
    [SerializeField] private Vector2 _forceDirection;

    private PlayerController _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void UseEffect()
    {
        if (!GameManager.Instance.GameHasStarted)
            return;

        _player.AddForce((Vector3)_forceDirection, _addForce);
        GameManager.Instance.RicharlisonEffect = false;

    }
}
