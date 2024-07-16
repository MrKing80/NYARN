using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCatch : MonoBehaviour
{
    // アイテムリスト情報
    [SerializeField] private ItemDataBase itemData;
    // 落ちてるアイテム情報   
    [SerializeField] private ItemCreate itemCreate;
    // 拾ったアイテム情報
    public int catchItemID = default;
    // 重さ
    [SerializeField] private float catchItemWeight = default;

    private GameObject item = default;      //アイテムを格納する変数

    private bool isItemTouch = false;       //アイテムが拾えるかどうか
    private bool isDoNotThrow = false;      //アイテムが捨てられるかどうか

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
            i++;                            //インクリメント

            catchItemID = item.GetComponent<ItemCreate>().itemID;
            Debug.Log(itemData.GetItemLists()[catchItemID].ItemID + " : " + itemData.GetItemLists()[catchItemID].Name
                       + " : " + itemData.GetItemLists()[catchItemID].Price + " : " + itemData.GetItemLists()[catchItemID].Weight
                            + " : " + itemData.GetItemLists()[catchItemID].Explanation);
            
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