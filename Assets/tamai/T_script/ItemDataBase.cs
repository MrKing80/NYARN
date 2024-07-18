using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 制作者：玉井
/// 内容：アイテムリストです。
/// 
/// </summary>

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "ScriptableObjects/CreateItemDataBaseAsset")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private List<ItemData> itemLists = new();

    public List<ItemData> GetItemLists()
    {
        // 外から呼び出されてアイテムリストを返す
        return itemLists;
    }
}
