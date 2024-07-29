using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField,Header("HP‚ð“ü‚ê‚é‚Æ‚±‚ë‚¾‚æ`")] private int playerHp;

    //–³“G‚©‚Ç‚¤‚©
    private bool isInvincible = false;
    
    //Ø‚è‘Ö‚¦ŽžŠÔ
    private float flgChangeTime = 0.5f;
    
    //ƒJƒEƒ“ƒgŽžŠÔ
    private float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //–³“Gó‘Ô‚Ìê‡
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
        //“G‚ÉG‚ê‚½‚Æ‚«
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