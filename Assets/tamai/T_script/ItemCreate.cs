using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    // アイテムリスト情報
    public ItemDataBase itemData;
    public ItemData item;
    // アイテムIDを指定
    [Range(0, 9)] public int itemID;
}
