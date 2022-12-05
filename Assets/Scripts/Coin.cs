using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int _coinValue = 10;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(_coinValue);
            //Play Sound
            Destroy(gameObject);
        }
    }

}
