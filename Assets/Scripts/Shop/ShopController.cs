using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textElement;
    [SerializeField] ShopItem[] _itens;

    [SerializeField] private float _superChuteiraMultiplier = 2f;

    private int _currentCoins = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerTotalCoins"))
            return;

        _currentCoins = PlayerPrefs.GetInt("PlayerTotalCoins");
        _textElement.text = "Moedas: " + _currentCoins;

    }
    public void PurchaseItem(ShopItem item)
    { 
        if (_currentCoins < item.ItemPrice)
            return;

        _currentCoins -= item.ItemPrice;
        _textElement.text = "Moedas: " + _currentCoins;

        ResolveEffect(item);

        PlayerPrefs.SetInt("PlayerTotalCoins", _currentCoins);

    }

    private void ResolveEffect(ShopItem item)
    {
        switch(item.ItemID)
        {
            case 0: //richarlison
                GameManager.Instance.RicharlisonEffect = true;
                break;
            case 1:
                GameManager.Instance.SuperChuteira = _superChuteiraMultiplier;

                break;
            case 2: // bola
                GameManager.Instance.BolaDeBorracha = true;
                break;
        }
    }

}
