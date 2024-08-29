using UnityEngine;

/// <summary>
/// 
/// 制作者：玉井
/// 内容：アイテムリストの中身です。
/// 
/// </summary>
/// 
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/CreateItemDataAsset")]
[System.Serializable]
public class ItemData : ScriptableObject
{
    public enum ArtWork
    {
        /*
        PORTRAIT,     // 肖像画
        SELFPORTRAIT, // 自画像
        LANDSCAPE,    // 風景画
        ABSTRACT      // 抽象画
        */

        TREASURE,　//宝物
        ENABLEDITEM　//使用可能アイテム
    }

    [Header("ジャンル")] [SerializeField] private ArtWork type;
    [Header("画像")] [SerializeField] private Sprite itemSprite; // 画像
    [Header("ID")] [SerializeField] private int ID = default; // ID
    [Header("名前")] [SerializeField] private string artName = default; // 名前
    [Header("プレハブ")] [SerializeField] private GameObject gameObject = default; // プレハブ
    [Header("説明")] [TextArea] [SerializeField] private string explanation = default; // 説明
    [Header("値段")] [SerializeField] private int price = default; // 値段
    [Header("重さ")] [SerializeField] private float weight = default; // 重さ
    [Header("持っているか")] [SerializeField] private bool dead = default; // 持っているか

    // パブリックで渡すことで編集可能にする
    public ArtWork _Type => type;
    public Sprite ItemSprite => itemSprite;
    public int ItemID { get => ID; }
    public string Name { get => artName; }
    public GameObject ItemObject { get => gameObject; }
    public string Explanation { get => explanation; }
    public int Price { get => price; }
    public float Weight { get => weight; }
    public bool Dead { get => dead; }
}
