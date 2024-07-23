using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{

    [SerializeField,Header("目標金額のテキスト入れるところ")] private TMP_Text goalMoneyTextObj = default;
    [SerializeField,Header("所持金額のテキスト入れるところ")] private TMP_Text nowMoneyTextObj = default;

    //所持金額を入れる
    private int nowHaveMoney = 0;
     
    //現在のステージ
    private int stageNum = 1;

    //各ステージの目標金額を格納した配列
    private string[] goalMoneyArrey = new string[3] { "50,000,000", "500,000,000", "50,000,000,000" };

    /// <summary>
    /// プレイヤーの所持金を受け取るプロパティ
    /// </summary>
    public int NowHaveMoneyProperty
    {
        get { return nowHaveMoney; }
        set { nowHaveMoney = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        goalMoneyTextObj.SetText("目標金額:" + goalMoneyArrey[stageNum]);   //目標金額を表示
    }

    // Update is called once per frame
    void Update()
    {
        nowMoneyTextObj.SetText(NowHaveMoneyProperty.ToString("N0"));   //現在の所持金額を表示
    }
}
