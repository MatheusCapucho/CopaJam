using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private GameObject _coin;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        SpawnCoin();
    }

    public Vector3 GetNextSpawnPosition()
    {
        return transform.position + new Vector3(_collider.bounds.extents.x * 2, 0f, 0f);
    }

    private void SpawnCoin()
    {
        for(int i = 0; i < 70; i++)
        {
            var xx = Random.Range(-16, 50);
            var yy = Random.Range(-20, 80);
            Instantiate(_coin, transform.position + new Vector3(xx, yy, 0f), Quaternion.identity);
        }
        
    }

}
