using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField,Header("HP������Ƃ��낾��`")] private int playerHp;

    //���G���ǂ���
    private bool isInvincible = false;
    
    //�؂�ւ�����
    private float flgChangeTime = 0.5f;
    
    //�J�E���g����
    private float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���G��Ԃ̏ꍇ
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
        //�G�ɐG�ꂽ�Ƃ�
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