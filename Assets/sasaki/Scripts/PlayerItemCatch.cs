using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCatch : MonoBehaviour
{

    private GameObject item = default;      //アイテムを格納する変数

    private bool isItemTouch = false;       //アイテムが拾えるかどうか
    private bool isDoNotThrow = false;      //アイテムが捨てられるかどうか

    private int i = 0;      //リストの添え字 

    private int zero = 0;   //リストの０番目を指す

    [SerializeField] private List<GameObject> items = new List<GameObject>();    //アイテムのリスト

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //アイテム取得
        if (isItemTouch && (Input.GetKeyDown("joystick button 0") || !isDoNotThrow && Input.GetMouseButtonDown(0)))
        {
            items.Add(item);                //リスト追加
            items[i].SetActive(false);      //アイテムを非表示
            i++;                            //インクリメント
            print("とった！");
        }

        //アイテム捨て
        if (!isDoNotThrow && (Input.GetKeyDown("joystick button 1") || !isDoNotThrow && Input.GetMouseButtonDown(1)))
            if (items[zero] != null)
            {
                items[zero].SetActive(true);        //アイテム表示
                items[zero].transform.position = this.transform.position;   //自分の足元へ落とす
                items.Remove(items[zero]);          //リストから削除
                i--;                                //デクリメント
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
