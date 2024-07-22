using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCatch : MonoBehaviour
{
    // アイテムリスト情報
    [SerializeField] private ItemDataBase itemData;
    // 落ちてるアイテム情報   
    [SerializeField] private ItemCreate itemCreate;
    // インベントリ情報
    [SerializeField] private InventoryManager inventoryManager;
    // 拾ったアイテム情報
    public int catchItemID = default;
    public Sprite catchItemSprite = default;

    public GameObject item = default;      //アイテムを格納する変数
    public ItemData[] items;

    public bool isItemTouch = false;       //アイテムが拾えるかどうか
    public bool isDoNotThrow = false;      //アイテムが捨てられるかどうか

    private int i = 0;      //リストの添え字

    private int zero = 0;   //リストの０番目を指す

    public List<GameObject> itemLists = new List<GameObject>();    //アイテムのリスト

    void Update()
    {
        //アイテム取得
        if (isItemTouch && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            itemLists.Add(item);                //リスト追加
            itemLists[i].SetActive(false);      //アイテムを非表示
            i++;                                //インクリメント

            // アイテムIDを取得
            catchItemID = item.GetComponent<ItemCreate>().itemID;
            catchItemSprite = itemData.GetItemLists()[catchItemID].itemImage;

            inventoryManager.AddItem(items[catchItemID]);

            // アイテム情報を拾えているか確認
            Debug.Log(itemData.GetItemLists()[catchItemID].itemID + " : " + itemData.GetItemLists()[catchItemID].artName
                       + " : " + itemData.GetItemLists()[catchItemID].price + " : " + itemData.GetItemLists()[catchItemID].weight
                            + " : " + itemData.GetItemLists()[catchItemID].explanation);
            
            print("とった！");
        }

        //アイテム捨てる
        if (!isDoNotThrow && (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            if (itemLists[zero] != null)
            {
                itemLists[zero].SetActive(true);        //アイテム表示
                itemLists[zero].transform.position = this.transform.position;   //自分の足元へ落とす
                itemLists.Remove(itemLists[zero]);          //リストから削除
                i--;                                //デクリメント
            }
        }

        if (i < 0)
        {
            i = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            item = collision.gameObject;    //触れたアイテムの情報取得
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            isItemTouch = true;         //触れている状態にする
            isDoNotThrow = true;        //アイテムを落とせないようにする
            print("アイテム！");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            isItemTouch = false;        //触れていない状態にする
            isDoNotThrow = false;       //アイテムを落とせないようにする
            print("アイテム....");
        }
    }
}