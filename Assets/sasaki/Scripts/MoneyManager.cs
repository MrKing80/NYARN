using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goalMoneyTextObj = default;
    [SerializeField] private TMP_Text nowMoneyTextObj = default;

    private int nowHaveMoney = 0;
    private int stageNum = 1;
    private string[] goalMoneyArrey = new string[3] { "50,000,000", "500,000,000", "50,000,000,000" };

    public int NowHaveMoneyProperty
    {
        get { return nowHaveMoney; }
        set { nowHaveMoney = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        goalMoneyTextObj.SetText("–Ú•W‹àŠz:" + goalMoneyArrey[stageNum]);
    }

    // Update is called once per frame
    void Update()
    {
        nowMoneyTextObj.SetText(NowHaveMoneyProperty.ToString());
    }
}
