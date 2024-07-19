using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCatch : MonoBehaviour
{
    // アイテムリスト情報
    [SerializeField] private ItemDataBase itemData;
    
    // 落ちてるアイテム情報   
    [SerializeField] private ItemCreate itemCreate;

    ////移動関係のスクリプト
    //private PlayerMove move = default;

    //お金のUI管理スクリプト
    private MoneyManager moneyMgr = default;

    //Rigidbody2D
    private Rigidbody2D rig = default;
    
    //最大所持重量
    private const float MAX_CARRYING_WEIGHT = 100f;
    
    //現在所持重量
    private float carryingWeight = default;
    
    //拾ったアイテムを格納する変数
    private GameObject item = default;
    
    //捨てたアイテムを格納する変数
    private GameObject removeItem = default;

    // 拾ったアイテム情報
    private int catchItemID = default;

    //所持しているお金
    private int carryMoney = default;
    
    //アイテムが拾えるかどうか
    private bool isItemTouch = false;
    
    //アイテムが捨てられるかどうか
    private bool isDoNotThrow = false;
    
    //リストの添え字
    private int i = 0;
    
    //リストの０番目を指す
    private int zero = 0;
    
    //アイテムのリスト
    public List<GameObject> itemLists = new List<GameObject>();    

    private void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        moneyMgr = GameObject.Find("NowMoneyManager").GetComponent<MoneyManager>();
        //move = this.GetComponent<PlayerMove>();
    }
    void Update()
    {

        //アイテム取得
        if (isItemTouch && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            itemLists.Add(item);                //リスト追加
    
            itemLists[i].SetActive(false);      //アイテムを非表示
    
            i++;                            //インクリメント

            catchItemID = item.GetComponent<ItemCreate>().itemID;  //拾ったアイテムのID取得
            
            carryingWeight += itemData.GetItemLists()[catchItemID].Weight;  //重量を加算
            
            carryMoney += itemData.GetItemLists()[catchItemID].Price;  //金額を加算

            moneyMgr.NowHaveMoneyProperty = carryMoney;     //UIのほうへ受け渡す

            //Rigidbodyの重さが最大所持重量よりも下の場合
            if (rig.drag <= MAX_CARRYING_WEIGHT)
            {
                rig.drag = carryingWeight;  //重さ変更
            }

            print(itemData.GetItemLists()[catchItemID].ItemID + " : " + itemData.GetItemLists()[catchItemID].Name
                   + " : " + itemData.GetItemLists()[catchItemID].Price + " : " + itemData.GetItemLists()[catchItemID].Weight
                        + " : " + itemData.GetItemLists()[catchItemID].Explanation);

            print("とった！");
        }

        //アイテム捨てる
        if (!isDoNotThrow && (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            if (itemLists.Count <= 0)
            {
                return;
            }

            removeItem = itemLists[zero];   //捨てたアイテムの情報保持

            catchItemID = removeItem.GetComponent<ItemCreate>().itemID; //捨てたアイテムのID取得

            carryingWeight -= itemData.GetItemLists()[catchItemID].Weight;  //重量を減算

            carryMoney -= itemData.GetItemLists()[catchItemID].Price;  //金額を減算

            moneyMgr.NowHaveMoneyProperty = carryMoney;     //UIのほうへ受け渡す

            rig.drag = carryingWeight;  //重さ変更

            itemLists[zero].SetActive(true);        //アイテム表示
            itemLists[zero].transform.position = this.transform.position;   //自分の足元へ落とす
            itemLists.Remove(itemLists[zero]);          //リストから削除
            i--;                                //デクリメント
        }

        //添え字がマイナスになるとき0にする
        if (i < zero)
        {
            i = zero;
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