using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    // �A�C�e�����X�g���
    [SerializeField] private ItemDataBase itemData;
    // �A�C�e��ID���w��
    [Range(0, 9)] public int itemID;
}
