using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    [SerializeField] private GameObject _panel;

    public void LoadSceneByName(string n) 
    {
        SceneManager.LoadScene(n);
    }

    private void OnEnable()
    {
        GameManager.OnGameEnd += EndLevel;
    }
    private void OnDisable()
    {
        GameManager.OnGameEnd -= EndLevel;
    }

    private void EndLevel()
    {
        _panel.SetActive(true);
    }

}
