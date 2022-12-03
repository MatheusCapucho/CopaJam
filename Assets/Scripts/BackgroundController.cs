using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private Transform _player;

    private Background _farthestBackground;

    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
        _farthestBackground = transform.GetChild(0).GetComponent<Background>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player.position.x > _farthestBackground.transform.position.x)
            SpawnMore();
    }

    private void SpawnMore()
    {
        var backgroundClone = Instantiate(_backgroundPrefab, _farthestBackground.GetNextSpawnPosition(), Quaternion.identity);
        _farthestBackground = backgroundClone.GetComponent<Background>();
    }

}
