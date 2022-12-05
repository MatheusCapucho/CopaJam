using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    private GameObject _panel;

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
        _panel = GameObject.Find("PanelActivate");
        _panel.GetComponent<PanelActivate>().SetActivePanel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
