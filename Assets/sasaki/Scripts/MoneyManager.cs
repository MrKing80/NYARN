using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{

    [SerializeField,Header("�ڕW���z�̃e�L�X�g�����Ƃ���")] private TMP_Text goalMoneyTextObj = default;
    [SerializeField,Header("�������z�̃e�L�X�g�����Ƃ���")] private TMP_Text nowMoneyTextObj = default;

    //�������z������
    private int nowHaveMoney = 0;
     
    //���݂̃X�e�[�W
    private int stageNum = 1;

    //�e�X�e�[�W�̖ڕW���z���i�[�����z��
    private string[] goalMoneyArrey = new string[3] { "50,000,000", "500,000,000", "50,000,000,000" };

    /// <summary>
    /// �v���C���[�̏��������󂯎��v���p�e�B
    /// </summary>
    public int NowHaveMoneyProperty
    {
        get { return nowHaveMoney; }
        set { nowHaveMoney = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        goalMoneyTextObj.SetText("�ڕW���z:" + goalMoneyArrey[stageNum]);   //�ڕW���z��\��
    }

    // Update is called once per frame
    void Update()
    {
        nowMoneyTextObj.SetText(NowHaveMoneyProperty.ToString("N0"));   //���݂̏������z��\��
    }
}
