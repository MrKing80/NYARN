using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// ����ҁF�ʈ�
/// ���e�F�A�C�e�����X�g�̃x�[�X�ł��B
/// 
/// </summary>

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "ScriptableObjects/CreateItemDataBaseAsset")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemData> itemLists = new();

    [System.Serializable]
    public class ItemData // itemLists�̒��g
    {
        [Header("�摜")] [SerializeField] Sprite itemSprite = default; // �摜
        [Header("ID")] [SerializeField] int ID = default; // ID
        [Header("���O")] [SerializeField] string name = default; // ���O
        [Header("�v���n�u")] [SerializeField] GameObject gameObject = default; // �v���n�u
        [Header("����")] [TextArea] [SerializeField] string explanation = default; // ����
        [Header("�l�i")] [SerializeField] float price = default; // �l�i
        [Header("�d��")] [SerializeField] float weight = default; // �d��
        [Header("�����Ă��邩�ǂ���")] [SerializeField] bool dead = default; // �g�p���ꂽ��

        // �p�u���b�N�œn�����ƂŕҏW�\�ɂ���
        public int ItemID { get => ID; }
        public string Name { get => name; }
        public GameObject ItemObject { get => gameObject; }
        public string Explanation { get => explanation; }
        public float Price { get => price; }
        public float Weight { get => weight; }
        public bool Dead { get => dead; }
    }
    public List<ItemData> GetItemLists() // �A�C�e�����X�g��Ԃ�
    {
        return itemLists;
    }
}
