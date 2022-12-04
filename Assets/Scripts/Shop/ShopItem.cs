using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemImage;
    public int ItemPrice;
}
