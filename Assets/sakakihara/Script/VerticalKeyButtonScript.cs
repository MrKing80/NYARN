using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VerticalKeyButtonScript : MonoBehaviour
{
    //ボタンをキーボードで押せるようにするスクリプト

    private float inputX = 0;//キー入力
    private float inputZ = 0;//キー入力

    [Header("左側のボタン")]
    [SerializeField] Button yesButton;　//左ボタン
    [Header("右側のボタン")]
    [SerializeField] Button noButton;   //右ボタン

    [Header("BGMスライダー入れる")]
    [SerializeField] Slider bGMSlider;//BGMスライダー入れる

    [Header("上側のボタン")]
    [SerializeField] Button upButton;　//上ボタン
    [Header("下側のボタン")]
    [SerializeField] Button downButton;   //下ボタン

    private void Start()
    {
        bGMSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        //キー入力の受付
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        LeftAndRightButtons();//左右の移動

        if (upButton == null) return;// 上下にボタン無いとき発動しないようにする
        UpAndDownButton();//上下の移動

    }

    private void LeftAndRightButtons()//左右ボタン
    {

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

            if (inputX > 0)
            {
                noButton.Select();
                bGMSlider.value = +0.1f;
            }
            if (inputX < 0)
            {
                yesButton.Select();
                bGMSlider.value = -0.1f;
            }

        }

    }
}
