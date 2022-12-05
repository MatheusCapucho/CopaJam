using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    private int[] _topScores;
    private string[] _topScoresName;
    private TextMeshProUGUI[] _texts;
    [SerializeField] private bool _loadText = true;

    private void Start()
    {
        
        _topScores = new int[5];
        _topScoresName = new string[5];
        _texts = new TextMeshProUGUI[5];
        LoadScores();
        if(_loadText)
            LoadText();
    }

    private void LoadScores()
    {
        if (PlayerPrefs.HasKey("Top1"))
        {
            _topScores[0] = PlayerPrefs.GetInt("Top1");
            _topScoresName[0] = PlayerPrefs.GetString("Top1Name");

        }
        if (PlayerPrefs.HasKey("Top2"))
        {
            _topScores[1] = PlayerPrefs.GetInt("Top2");
            _topScoresName[1] = PlayerPrefs.GetString("Top2Name");

        }
        if (PlayerPrefs.HasKey("Top3"))
        {
            _topScores[2] = PlayerPrefs.GetInt("Top3");
            _topScoresName[2] = PlayerPrefs.GetString("Top3Name");

        }
        if (PlayerPrefs.HasKey("Top4"))
        {
            _topScores[3] = PlayerPrefs.GetInt("Top4");
            _topScoresName[3] = PlayerPrefs.GetString("Top4Name");

        }
        if (PlayerPrefs.HasKey("Top5"))
        {
            _topScores[4] = PlayerPrefs.GetInt("Top5");
            _topScoresName[4] = PlayerPrefs.GetString("Top5Name");

        }
    }

    private void LoadText()
    {
        for(int i = 0; i < 5; i++)
        {
            if (_topScores[i] == 0)
                return;
            _texts[i] = transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            _texts[i].text =  _topScoresName[i] + ": "+ _topScores[i]; 
        }
    }

    public void ApagarTudo()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.FirstLoadBool = true;
        GameManager.Instance.FirstLoad();
        Start();
    }


}
