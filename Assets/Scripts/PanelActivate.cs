using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivate : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    [SerializeField] private bool activeOnStart = false;
    private bool a;


    private void Start()
    {
        a = GameManager.Instance.RicharlisonEffect;
        if (activeOnStart && a)
            SetActivePanel();
    }

    public void SetActivePanel()
    {
        _panel.SetActive(true);
    }
}
