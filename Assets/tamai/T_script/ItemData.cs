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
        /*
        PORTRAIT,     // �ё���
        SELFPORTRAIT, // ���摜
        LANDSCAPE,    // ���i��
        ABSTRACT      // ���ۉ�
        */

        TREASURE,�@//��
        ENABLEDITEM�@//�g�p�\�A�C�e��
    }

    [Header("�W������")] [SerializeField] private ArtWork type;
    [Header("�摜")] [SerializeField] private Sprite itemSprite; // �摜
    [Header("ID")] [SerializeField] private int ID = default; // ID
    [Header("���O")] [SerializeField] private string artName = default; // ���O
    [Header("�v���n�u")] [SerializeField] private GameObject gameObject = default; // �v���n�u
    [Header("����")] [TextArea] [SerializeField] private string explanation = default; // ����
    [Header("�l�i")] [SerializeField] private int price = default; // �l�i
    [Header("�d��")] [SerializeField] private float weight = default; // �d��
    [Header("�����Ă��邩")] [SerializeField] private bool dead = default; // �����Ă��邩

    // �p�u���b�N�œn�����ƂŕҏW�\�ɂ���
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
