using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneypossession;
    private int money = 20000;
    // ボタンの価格
    [SerializeField] private int price = 1000;
    [SerializeField] private int moneypey = 2000;
    [SerializeField] private int mappey = 5000;
    //ボタンを取得
    [SerializeField] private Button shoes;
    [SerializeField] private Button pawer;
    [SerializeField] private Button map;
    [SerializeField] private Image image;
    //合計金額
    private int sum = 0;
    //見た目の素材
    [SerializeField] private Sprite newSprite;
    [SerializeField] private Sprite newSprite2;
    [SerializeField] private Sprite newSprite3;
    [SerializeField] private Sprite newSprite4;
    [SerializeField] private int common_people = 7000;
    [SerializeField] private int wealthy = 15000;
    [SerializeField] private int millionaire = 20000;
    //それぞれ押した回数
    private int countshoes = 0;
    private int countpawer = 0;
    private int countmap = 0;
    //マップの配列の中身
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject map2;
    [SerializeField] private GameObject map3;
    [SerializeField] private GameObject map4;
    [SerializeField] private GameObject map5;
    [SerializeField] private GameObject map6;
    ////靴の配列の中身
    //[SerializeField] private GameObject shoes1;
    //[SerializeField] private GameObject shoes2;
    //[SerializeField] private GameObject shoes3;
    ////力の配列の中身
    //[SerializeField] private GameObject pawer1;
    //[SerializeField] private GameObject mpawer2;
    //[SerializeField] private GameObject pawer3;
    // 3行3列の2次元配列
    GameObject[,] maparray;
    private int verticalmap = 0;
    private int besidemap = 0;

    void Start()
    {
        _moneypossession.text = money.ToString(); // UIを初期化

        maparray = new GameObject[2, 3] { { map1, map2, map3 }, { map4, map5, map6 }, };

    }
    private void Update()
    {
        //金額に応じて見た目を変える
        if (sum >= common_people)
        {
            image.sprite = newSprite;
        }
        if (sum >= wealthy)
        {
            image.sprite = newSprite2;
        }
        if (sum >= millionaire)
        {
            image.sprite = newSprite3;
        }
    }

    //力のボタン
    public void OnButtonPower()
    {
        if (money >= price) // 所持金が価格以上ある場合
        {
            money -= price; // 所持金から価格を引く
            _moneypossession.text = money.ToString(); // UIを更新
            sum = sum + price;
            countpawer += 1;
        }
        if (money < price || countpawer >= 3) // 価格が所持金以上ある場合ボタン押せなくする
        {
            pawer.interactable = false;
        }
    }

    //靴のボタン
    public void OnButtonShoes()
    {
        if (money >= moneypey) // 所持金が価格以上ある場合
        {
            money -= moneypey; // 所持金から価格を引く
            _moneypossession.text = money.ToString(); // UIを更新
            sum = sum + moneypey;
            countshoes += 1;
        }
        if (money < moneypey || countshoes >= 3) // 価格が所持金以上ある場合ボタン押せなくする
        {
            shoes.interactable = false;
        }

    }
    //マップのボタン
    public void OnButtonmap()
    {
        if (money >= mappey) // 所持金が価格以上ある場合
        {
            money -= mappey; // 所持金から価格を引く
                             // player = maparray[verticalmap, besidemap];
            Debug.Log(maparray[verticalmap, besidemap]);
            besidemap += 1;
            _moneypossession.text = money.ToString(); // UIを更新
            sum = sum + mappey;
            countmap += 1;
        }
        if (money < mappey || countmap >= 3) // 価格が所持金以上ある場合ボタン押せなくする
        {
            map.interactable = false;
        }
      
    }

    public void OnCllic()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("test");
        //ボタンとか初期化
        pawer.interactable = true;
        shoes.interactable = true;
        map.interactable = true;
        besidemap = 0;
        verticalmap += 1;
    }
}
