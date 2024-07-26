using UnityEngine;

/// <summary>
/// 
/// ����ҁF�ʈ�
/// ���e�F�A�C�e�����X�g�̒��g�ł��B
/// 
/// </summary>
/// 
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/CreateItemDataAsset")]
[System.Serializable]
public class ItemData : ScriptableObject
{
    public enum ArtWork
    {
        PORTRAIT,     // �ё���
        SELFPORTRAIT, // ���摜
        LANDSCAPE,    // ���i��
        ABSTRACT      // ���ۉ�
    }

    [Header("�W������")] [SerializeField] private ArtWork type;
    [Header("�����摜")] [SerializeField] private Sprite sprite; // �����摜
    [Header("�摜")] [SerializeField] private Sprite image; // �摜
    [Header("ID")] [SerializeField] private int ID = default; // ID
    [Header("���O")] [SerializeField] private string itemArtName = default; // ���O
    [Header("����")] [TextArea] [SerializeField] private string itemExplanation = default; // ����
    [Header("�l�i")] [SerializeField] private float itemPrice = default; // �l�i
    [Header("�d��")] [SerializeField] private float itemWeight = default; // �d��
    [Header("�X�^�b�N�̗L��")] [SerializeField] private bool itemStackable = true; // �X�^�b�N�ł��邩

    // �p�u���b�N�œn�����ƂŕҏW�\�ɂ���
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
