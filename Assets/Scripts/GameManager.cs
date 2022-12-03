using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-5)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static int _totalCoins = 0;
    public int TotalCoins => _totalCoins;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

    }
    public void AddCoin(int val)
    {
        _totalCoins += val;
        UpdateUI();
    }
    public void SubtractCoins(int val)
    {
        _totalCoins -= val;
        UpdateUI();
    }

    private void UpdateUI()
    {
        Debug.Log(_totalCoins);
    }


}
