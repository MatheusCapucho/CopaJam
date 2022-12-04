using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundPrefab;
    [SerializeField] private GameObject _backgroundPrefab2;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerBorracha;

    [SerializeField] private Transform _playerSpawnPoint;

    private GameObject _background;
    private GameObject _playerInstantiate;

    private Background _farthestBackground;

    private Camera _cam;

    private GameObject clone;

    void Start()
    {
        _cam = Camera.main;
        _farthestBackground = transform.GetChild(1).GetComponent<Background>();

        if(GameManager.Instance.BolaDeBorracha)
        {
            _background = _backgroundPrefab2;
            _playerInstantiate = _playerBorracha;
        } else
        {
            _background = _backgroundPrefab;
            _playerInstantiate = _player;
        }

        clone = Instantiate(_playerInstantiate, _playerSpawnPoint.position, Quaternion.identity);

        Setup();


    }

    void Setup()
    {
        transform.GetChild(0).GetComponent<UpdateDistance>().SetPlayer(clone);
        GameObject.Find("ArrowHolder").GetComponent<ArrowMovement>().SetPlayer(clone);
        GameObject.Find("CMVCam").GetComponent<CinemachineVirtualCamera>().Follow = clone.transform;
        GameObject.Find("CMVCam").GetComponent<CinemachineVirtualCamera>().LookAt = clone.transform;
    }
    void FixedUpdate()
    {
        if (clone.transform.position.x > _farthestBackground.transform.position.x)
            SpawnMore();
    }

    private void SpawnMore()
    {
        var backgroundClone = Instantiate(_background, _farthestBackground.GetNextSpawnPosition(), Quaternion.identity);
        _farthestBackground = backgroundClone.GetComponent<Background>();
    }

}
