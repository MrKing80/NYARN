using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool isCanHide = false;     //隠れられるかどうか
    private bool isHiding = false;      //隠れているかどうか

    private GameObject player = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //隠れたり出たりする処理
        if ((isCanHide || isHiding) && Input.GetKeyDown("joystick button 0"))
        {
            //隠れている場合
            if (isHiding)
            {   
                player.SetActive(true);     //プレイヤー表示
                player.transform.position = this.transform.position;    //ハイドポイントの位置にプレイヤーを戻す
                isHiding = false;           //ロッカーから出たよ
            }

            //隠れていない場合
            else if (!isHiding)
            {
                player.SetActive(false);    //ぷれいやーを非表示
                isHiding = true;            //ロッカーに隠れたよ
            }
        }

        //ロッカーのそばにいないとき変数を初期化
        if(!isCanHide)
        {
            player = null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCanHide = true;                   //隠れられるよ
            player = collision.gameObject;      //プレイヤーの情報を保持
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCanHide = false;          //ロッカーのそばにいないよ
        }
    }
}
