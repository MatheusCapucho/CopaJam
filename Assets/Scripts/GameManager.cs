using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DefaultExecutionOrder(-5)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int _totalCoins = 0;
    public int TotalCoins => _totalCoins;

    public static Action OnGameStart;
    public static Action OnGameEnd;

    private bool _gameHasStarted = false;
    public bool GameHasStarted => _gameHasStarted;

    #region Migue

    public float SuperChuteira = 1f;
    public bool RicharlisonEffect = false;
    public bool BolaDeBorracha = false;

    #endregion



    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

    }

    private void OnEnable()
    {
        OnGameStart += StartGame;
        OnGameEnd += EndGame;
    }
    private void OnDisable()
    {
        OnGameStart -= StartGame;
        OnGameEnd -= EndGame;
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

    public void StartGame()
    {
        _gameHasStarted = true;
    }

    public void EndGame()
    {
        if (!_gameHasStarted)
            return;

        int coinsStored;

        if (PlayerPrefs.HasKey("PlayerTotalCoins"))
        {
           coinsStored = PlayerPrefs.GetInt("PlayerTotalCoins");
        } 
        else
        {
            coinsStored = 0;
        }
        
        PlayerPrefs.SetInt("PlayerTotalCoins", _totalCoins + coinsStored);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("PlayerTotalCoins"));
        _gameHasStarted = false;
        ResetConfigs();

    }

    private void ResetConfigs()
    {
        SuperChuteira = 1f;
        //RicharlisonEffect = false;
        BolaDeBorracha = false;
    }

}
