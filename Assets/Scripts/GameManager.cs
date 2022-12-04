using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

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
    private TextMeshProUGUI _coinText;
    private TextMeshProUGUI _distanceText;

    #endregion



    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

    }

    private void Start()
    {
        FirstLoad();
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
        if (_coinText == null)
            _coinText = GameObject.Find("CoinsText").GetComponent<TextMeshProUGUI>();

        _coinText.text = "   Moedas: " + _totalCoins;
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
        SetLeaderBoard();
        PlayerPrefs.Save();
        _gameHasStarted = false;
        ResetConfigs();

    }

    public void SetLeaderBoard()
    {
        List<int> topScores = new List<int>();
        if (PlayerPrefs.HasKey("Top1"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top1"));
        }
        if (PlayerPrefs.HasKey("Top2"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top2"));
        }
        if (PlayerPrefs.HasKey("Top3"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top3"));
        }
        if (PlayerPrefs.HasKey("Top4"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top4"));

        }
        if (PlayerPrefs.HasKey("Top5"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top5"));
        }

        int currentDistance = GameObject.Find("DistanceObj").GetComponent<UpdateDistance>().CurrentDistance;
        topScores.Add(currentDistance);
        topScores.Sort();
        topScores.Reverse();

        PlayerPrefs.SetInt("Top1", topScores[0]);
        PlayerPrefs.SetInt("Top2", topScores[1]);
        PlayerPrefs.SetInt("Top3", topScores[2]);
        PlayerPrefs.SetInt("Top4", topScores[3]);
        PlayerPrefs.SetInt("Top5", topScores[4]);


    }

    private void ResetConfigs()
    {
        SuperChuteira = 1f;
        //RicharlisonEffect = false;
        BolaDeBorracha = false;
    }

    private void FirstLoad()
    {
        if (!PlayerPrefs.HasKey("Top1"))
        {
            PlayerPrefs.SetInt("Top1", 0);
        }
        if (!PlayerPrefs.HasKey("Top2"))
        {
            PlayerPrefs.SetInt("Top2", 0);
        }
        if (!PlayerPrefs.HasKey("Top3"))
        {
            PlayerPrefs.SetInt("Top3", 0);
        }
        if (!PlayerPrefs.HasKey("Top4"))
        {
            PlayerPrefs.SetInt("Top4", 0);

        }
        if (!PlayerPrefs.HasKey("Top5"))
        {
            PlayerPrefs.SetInt("Top5", 0);
        }
    }

}
