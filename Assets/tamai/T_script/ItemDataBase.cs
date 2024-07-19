using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// ����ҁF�ʈ�
/// ���e�F�A�C�e�����X�g�ł��B
/// 
/// </summary>

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "ScriptableObjects/CreateItemDataBaseAsset")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private List<ItemData> itemLists = new();

    public List<ItemData> GetItemLists()
    {
        // �O����Ăяo����ăA�C�e�����X�g��Ԃ�
        return itemLists;
    }
}
