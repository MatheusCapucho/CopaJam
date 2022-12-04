using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivate : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public void SetActivePanel()
    {
        _panel.SetActive(true);
    }
}
