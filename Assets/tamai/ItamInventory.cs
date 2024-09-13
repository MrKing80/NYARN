using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItamInventory : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemData;
    [SerializeField] private PlayerItemCatch playerItemCatch;
    [SerializeField] private GameObject[] itemPos = new GameObject[7];
    //アイテムを格納する変数
    private GameObject itemObj = default;
    [SerializeField] private int length;
    //リストの添え字
    private int i = 0;
    //リストの0番目
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
            // アイテムの要素を指定
            itemObj = playerItemCatch.item;
            length = playerItemCatch.itemLists.Count;

            itemObj.transform.parent = itemPos[i];
            itemObj.transform.localPosition = Vector2.zero;
            i++;                                //デクリメント
            print("インベントリ追加！");
        }
        else if (!playerItemCatch.isDoNotThrow && Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerItemCatch.item = itemPos[i];

            /*
            // アイテムの要素を指定
            itemObj = playerItemCatch.item;
            length = playerItemCatch.itemLists.Count;

            i--;                                //デクリメント
            print("インベントリ削除！");
        }

        if (i < 0)
        {
            i = 0;
        }*/
    }
}
