using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperChuteira : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void UseEffect()
    {
        GameManager.Instance.SuperChuteira = 2f;
    }
}
