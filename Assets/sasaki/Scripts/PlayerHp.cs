using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField,Header("HPを入れるところだよ〜")] private int playerHp;

    //無敵かどうか
    private bool isInvincible = false;
    
    //切り替え時間
    private float flgChangeTime = 0.5f;
    
    //カウント時間
    private float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //無敵状態の場合
        if (isInvincible)
        {
            countTime += Time.deltaTime;

            if(countTime >= flgChangeTime)
            {
                countTime = 0;
                isInvincible = false;
            }
        }

        if (playerHp <= 0)
        {
            print("gameover");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //敵に触れたとき
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isInvincible)
            {
                return;
            }
            else if (!isInvincible)
            {
                playerHp--;
                print("HIT");
                isInvincible = true;
            }
        }
    }
}