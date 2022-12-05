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
    [HideInInspector] public bool FirstLoadBool = true;
    private string lastNameInput = string.Empty;
    private int[] _topScores;
    List<string> topScoresName;

    #endregion

    int currentDistanceIndex;

    public GameObject Player;




    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(Instance);

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
        _totalCoins = 0;
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
        topScoresName = new List<string>();
        if (PlayerPrefs.HasKey("Top1"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top1"));
            topScoresName.Add(PlayerPrefs.GetString("Top1Name"));
        }
        if (PlayerPrefs.HasKey("Top2"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top2"));
            topScoresName.Add(PlayerPrefs.GetString("Top2Name"));
        }
        if (PlayerPrefs.HasKey("Top3"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top3"));
            topScoresName.Add(PlayerPrefs.GetString("Top3Name"));
        }
        if (PlayerPrefs.HasKey("Top4"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top4"));
            topScoresName.Add(PlayerPrefs.GetString("Top4Name"));

        }
        if (PlayerPrefs.HasKey("Top5"))
        {
            topScores.Add(PlayerPrefs.GetInt("Top5"));
            topScoresName.Add(PlayerPrefs.GetString("Top5Name"));
        }

        int currentDistance = GameObject.Find("DistanceObj").GetComponent<UpdateDistance>().CurrentDistance;

        topScores.Add(currentDistance);
        topScores.Sort();
        topScores.Reverse();

        //LoadScores(); //previus 

        //string previusName;

        for (int i = 0; i < 5; i++)
        {
            if (topScores[i] == currentDistance)
            {
                //previusName = _topScoresName[i+1]; //blz
                currentDistanceIndex = i;
                //SetTopNames(previusName); //f
            }
        }

        PlayerPrefs.SetInt("Top1", topScores[0]);
        PlayerPrefs.SetInt("Top2", topScores[1]);
        PlayerPrefs.SetInt("Top3", topScores[2]);
        PlayerPrefs.SetInt("Top4", topScores[3]);
        PlayerPrefs.SetInt("Top5", topScores[4]);

        //SetTopNames(lastNameInput);


    }

    public void SetTopNames(string name)
    {
        lastNameInput = name;
        //LoadScores();

        switch (currentDistanceIndex) 
        {
            case 0:
                PlayerPrefs.SetString("Top5Name", PlayerPrefs.GetString("Top4Name"));
                PlayerPrefs.SetString("Top4Name", PlayerPrefs.GetString("Top3Name"));
                PlayerPrefs.SetString("Top3Name", PlayerPrefs.GetString("Top2Name"));
                PlayerPrefs.SetString("Top2Name", PlayerPrefs.GetString("Top1Name"));
                PlayerPrefs.SetString("Top1Name", name);
                break;
            case 1:
                PlayerPrefs.SetString("Top5Name", PlayerPrefs.GetString("Top4Name"));
                PlayerPrefs.SetString("Top4Name", PlayerPrefs.GetString("Top3Name"));
                PlayerPrefs.SetString("Top3Name", PlayerPrefs.GetString("Top2Name"));
                PlayerPrefs.SetString("Top2Name", name);
                break;
            case 2:
                PlayerPrefs.SetString("Top5Name", PlayerPrefs.GetString("Top4Name"));
                PlayerPrefs.SetString("Top4Name", PlayerPrefs.GetString("Top3Name"));
                PlayerPrefs.SetString("Top3Name", name);
                break;
            case 3:
                PlayerPrefs.SetString("Top5Name", PlayerPrefs.GetString("Top4Name"));
                PlayerPrefs.SetString("Top4Name", name);
                break;
            case 4:
                PlayerPrefs.SetString("Top5Name", name);
                break;
            default:
                break;
        }
    }

   
    private void ResetConfigs()
    {
        SuperChuteira = 1f;
        //RicharlisonEffect = false;
        BolaDeBorracha = false;
    }

    public void FirstLoad()
    {
        _topScores = new int[5];

        if (PlayerPrefs.HasKey("Top1"))
            return;

        PlayerPrefs.SetInt("Top1", 0);
        PlayerPrefs.SetString("Top1Name", "'Nome1':");

        PlayerPrefs.SetInt("Top2", 0);
        PlayerPrefs.SetString("Top2Name", "'Nome2':");
              
        PlayerPrefs.SetInt("Top3", 0);
        PlayerPrefs.SetString("Top3Name", "'Nome3':");
               
        PlayerPrefs.SetInt("Top4", 0);
        PlayerPrefs.SetString("Top4Name", "'Nome4':");
   
        PlayerPrefs.SetInt("Top5", 0);
        PlayerPrefs.SetString("Top5Name", "'Nome5':");


        FirstLoadBool = false;
        
    }

}
