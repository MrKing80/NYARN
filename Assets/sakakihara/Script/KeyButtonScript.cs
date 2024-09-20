using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonScript : MonoBehaviour
{
    //ボタンをキーボードで押せるようにするスクリプト

    private float inputX = 0;//キー入力
    private float inputZ = 0;//キー入力

    [Header("左側のボタン")]
    [SerializeField] Button yesButton;　//左ボタン
    [Header("右側のボタン")]
    [SerializeField] Button noButton;   //右ボタン

    [Header("上側のボタン")]
    [SerializeField] Button upButton ;　//上ボタン
    [Header("下側のボタン")]
    [SerializeField] Button downButton ;   //下ボタン

    private void Update()
    {
        //キー入力の受付
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        //if (upButton == null) return;// 左右にボタン無いとき発動しないようにする
        LeftAndRightButtons();//左右の移動

        //if (upButton == null) return;// 上下にボタン無いとき発動しないようにする
        //UpAndDownButton();//上下の移動

    }

    private void LeftAndRightButtons()//左右ボタン
    {
        if (inputX > 0)
        {
            noButton.Select();
        }
        if (inputX < 0)
        {
            yesButton.Select();
        }
    }
    private void UpAndDownButton()//上下ボタン
    {

        if (inputZ > 0)
        {
            upButton.Select();
        }
        if (inputZ < 0)
        {
            downButton.Select();
        }
    }
}
