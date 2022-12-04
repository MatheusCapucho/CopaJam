using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateDistance : MonoBehaviour
{
    private GameObject _player;

    private int _startPos;
    private TextMeshProUGUI _distanceText;
    private int _currentDistance = 0;
    public int CurrentDistance => _currentDistance;

    private void Start()
    {    
        _distanceText = GameObject.Find("DistanceText").GetComponent<TextMeshProUGUI>();
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
        _startPos = (int)_player.transform.position.x;
    }

    private void OnEnable()
    {
        
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.GameHasStarted)
            return;

        _currentDistance = (int)(_player.transform.position.x - _startPos);

        _distanceText.text = "   Distância: " + _currentDistance; 

    }

}
