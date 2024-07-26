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
        PORTRAIT,     // 肖像画
        SELFPORTRAIT, // 自画像
        LANDSCAPE,    // 風景画
        ABSTRACT      // 抽象画
    }

    [Header("ジャンル")] [SerializeField] private ArtWork type;
    [Header("数字画像")] [SerializeField] private Sprite sprite; // 数字画像
    [Header("画像")] [SerializeField] private Sprite image; // 画像
    [Header("ID")] [SerializeField] private int ID = default; // ID
    [Header("名前")] [SerializeField] private string itemArtName = default; // 名前
    [Header("説明")] [TextArea] [SerializeField] private string itemExplanation = default; // 説明
    [Header("値段")] [SerializeField] private float itemPrice = default; // 値段
    [Header("重さ")] [SerializeField] private float itemWeight = default; // 重さ
    [Header("スタックの有無")] [SerializeField] private bool itemStackable = true; // スタックできるか

    // パブリックで渡すことで編集可能にする
    public ArtWork artType => type;
    public Sprite itemSprite => sprite;
    public Sprite itemImage => image;
    public int itemID { get => ID; }
    public string artName { get => itemArtName; }
    public string explanation { get => itemExplanation; }
    public float price { get => itemPrice; }
    public float weight { get => itemWeight; }
    public bool stackable { get => itemStackable; }
}
