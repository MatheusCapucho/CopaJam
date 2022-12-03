using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] ShopItem[] _itens;
    public void PurchaseItem(ShopItem item) // passar como referencia o item que foi clicado na loja
    {
        GameManager.Instance.SubtractCoins(item.ItemPrice);
    }

}
