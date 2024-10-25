using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    [SerializeField,Header("スピード倍率を入れるところだよー")] private float magnification = 3.9f;
    
    //プレイヤーの移動スクリプトを格納するところ
    private PlayerMove move = default;

    //プレイヤーを格納するところ
    private GameObject player = default;

    //バフの効果時間
    [SerializeField] private float buffTime = 3f;

    //一時的にスピードを格納するところ
    public float tmpSpeed = 0;

    //プレイヤーの初期スピードを格納するところ
    private float initialSpeed = default;

    //触れているか
    private bool isTouch = false;
 
    //ゲットしているか
    private bool isGet = false;

    // ★玉井追加 エフェクト用
    [SerializeField] private GameObject dashSmork = default;
    [SerializeField] private bool isDashSmork = default;


    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //一時停止されていたら処理をしない
        if (Time.timeScale == 0)
        {
            return;
        }

        //Aボタンもしくは左クリックを押したとき
        if (isTouch && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            move = player.GetComponent<PlayerMove>();   //スクリプト取得

            // ★玉井追加 子オブジェクトのGameObj取得
            dashSmork = player.transform.GetChild(1).gameObject;
            isDashSmork = dashSmork.GetComponent<SpriteRenderer>().enabled;

            initialSpeed = move.SpeedProperty;          //初期スピードを保存
            tmpSpeed = move.SpeedProperty * magnification;  //スピードアップ
            
            move.SpeedProperty = tmpSpeed;      //スピード変更

            // ★玉井追加 修正済　
            if (isDashSmork == false)
                isDashSmork = true;
            if (initialSpeed < tmpSpeed)
            {
                dashSmork.SetActive(true);
            }
            else
                dashSmork.SetActive(false);

            isGet = true;

            this.GetComponent<SpriteRenderer>().enabled = false;    
                                                                        //非表示            
            this.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (isGet)
        {
            buffTime -= Time.deltaTime;     //時間計測

            //効果時間終了したら
            if (buffTime <= 0)
            {
                move.SpeedProperty = initialSpeed;  //スピードを元に戻す
                player = null;      
                isGet = false;      //各種変数初期化
                buffTime = 3f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = true;
            player = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
