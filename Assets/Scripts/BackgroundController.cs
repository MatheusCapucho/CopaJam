using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private GameObject _backgroundPrefab2;
    [SerializeField] private Transform _player;

    private GameObject _background;

    private Background _farthestBackground;

    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
        _farthestBackground = transform.GetChild(0).GetComponent<Background>();

        if(GameManager.Instance.BolaDeBorracha)
        {
            _background = _backgroundPrefab2;
        } else
        {
            _background = _backgroundPrefab;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player.position.x > _farthestBackground.transform.position.x)
            SpawnMore();
    }

    private void SpawnMore()
    {
        var backgroundClone = Instantiate(_background, _farthestBackground.GetNextSpawnPosition(), Quaternion.identity);
        _farthestBackground = backgroundClone.GetComponent<Background>();
    }

}
