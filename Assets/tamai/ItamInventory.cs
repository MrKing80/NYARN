using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItamInventory : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemData;
    [SerializeField] private PlayerItemCatch playerItemCatch;
    [SerializeField] private GameObject[] itemPos = new GameObject[7];
    //�A�C�e�����i�[����ϐ�
    private GameObject itemObj = default;
    [SerializeField] private int length;
    //���X�g�̓Y����
    private int i = 0;
    //���X�g��0�Ԗ�
    private int j = 0;

    void Start()
    {
//        playerItemCatch = this.GetComponent<PlayerItemCatch>();
    }

    void Update()
    {/*
        if (playerItemCatch.itemLists[j] != null || playerItemCatch.isItemTouch &&
                (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            playerItemCatch.item = itemPos[i];

            /*
            // �A�C�e���̗v�f���w��
            itemObj = playerItemCatch.item;
            length = playerItemCatch.itemLists.Count;

            itemObj.transform.parent = itemPos[i];
            itemObj.transform.localPosition = Vector2.zero;
            i++;                                //�f�N�������g
            print("�C���x���g���ǉ��I");
        }
        else if (!playerItemCatch.isDoNotThrow && Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerItemCatch.item = itemPos[i];

            /*
            // �A�C�e���̗v�f���w��
            itemObj = playerItemCatch.item;
            length = playerItemCatch.itemLists.Count;

            i--;                                //�f�N�������g
            print("�C���x���g���폜�I");
        }

        if (i < 0)
        {
            i = 0;
        }*/
    }
}
