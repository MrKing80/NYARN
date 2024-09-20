using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonScript : MonoBehaviour
{
    //ボタンをキーボードで押せるようにするスクリプト

    private float inputX = 0;//キー入力

    [Header("左側のボタン")]
    [SerializeField] Button yesButton;　//左ボタン
    [Header("右側のボタン")]
    [SerializeField] Button noButton;   //右ボタン

    private void Update()
    {
        //キー入力の受付
        inputX = Input.GetAxisRaw("Horizontal");


        if (inputX > 0)
        {
            noButton.Select();
        }
        if (inputX < 0)
        {
            yesButton.Select();
        }
    }
   
}
