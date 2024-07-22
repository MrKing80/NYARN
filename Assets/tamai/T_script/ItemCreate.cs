using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    // アイテムリスト情報
    [SerializeField] private ItemDataBase itemData;
    // アイテムIDを指定
    [Range(0, 9)] public int itemID;
}
