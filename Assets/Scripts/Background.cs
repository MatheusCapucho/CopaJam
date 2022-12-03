using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Collider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    public Vector3 GetNextSpawnPosition()
    {
        return transform.position + new Vector3(_collider.bounds.extents.x, 0f, 0f);
    }
}
