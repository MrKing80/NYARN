using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 制作者：玉井
/// 内容：アイテムリストのベースです。
/// 
/// </summary>

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "ScriptableObjects/CreateItemDataBaseAsset")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> itemLists = new();

    [System.Serializable]
    public class ItemData // itemListsの中身
    {
        [Header("画像")] [SerializeField] Sprite itemSprite = default; // 画像
        [Header("ID")] [SerializeField] int ID = default; // ID
        [Header("名前")] [SerializeField] string name = default; // 名前
        [Header("プレハブ")] [SerializeField] GameObject gameObject = default; // プレハブ
        [Header("説明")] [TextArea] [SerializeField] string explanation = default; // 説明
        [Header("値段")] [SerializeField] float price = default; // 値段
        [Header("重さ")] [SerializeField] float weight = default; // 重さ
        [Header("持っているかどうか")] [SerializeField] bool dead = default; // 使用されたか

        // パブリックで渡すことで編集可能にする
        public int ItemID { get => ID; }
        public string Name { get => name; }
        public GameObject ItemObject { get => gameObject; }
        public string Explanation { get => explanation; }
        public float Price { get => price; }
        public float Weight { get => weight; }
        public bool Dead { get => dead; }
    }
    public List<ItemData> GetItemLists() // アイテムリストを返す
    {
        return itemLists;
    }
}
