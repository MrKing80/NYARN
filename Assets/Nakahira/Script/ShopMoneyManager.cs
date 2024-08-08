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
    // �{�^���̉��i
    [SerializeField] private int price = 1000;
    [SerializeField] private int moneypey = 2000;
    [SerializeField] private int mappey = 5000;
    //�{�^�����擾
    [SerializeField] private Button shoes;
    [SerializeField] private Button pawer;
    [SerializeField] private Button map;
    [SerializeField] private Image image;
    //���v���z
    private int sum = 0;
    //�����ڂ̑f��
    [SerializeField] private Sprite newSprite;
    [SerializeField] private Sprite newSprite2;
    [SerializeField] private Sprite newSprite3;
    [SerializeField] private Sprite newSprite4;
    [SerializeField] private int common_people = 7000;
    [SerializeField] private int wealthy = 15000;
    [SerializeField] private int millionaire = 20000;
    //���ꂼ�ꉟ������
    private int countshoes = 0;
    private int countpawer = 0;
    private int countmap = 0;
    //�}�b�v�̔z��̒��g
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject map2;
    [SerializeField] private GameObject map3;
    [SerializeField] private GameObject map4;
    [SerializeField] private GameObject map5;
    [SerializeField] private GameObject map6;
    ////�C�̔z��̒��g
    //[SerializeField] private GameObject shoes1;
    //[SerializeField] private GameObject shoes2;
    //[SerializeField] private GameObject shoes3;
    ////�͂̔z��̒��g
    //[SerializeField] private GameObject pawer1;
    //[SerializeField] private GameObject mpawer2;
    //[SerializeField] private GameObject pawer3;
    // 3�s3���2�����z��
    GameObject[,] maparray;
    private int verticalmap = 0;
    private int besidemap = 0;

    void Start()
    {
        _moneypossession.text = money.ToString(); // UI��������

        maparray = new GameObject[2, 3] { { map1, map2, map3 }, { map4, map5, map6 }, };

    }
    private void Update()
    {
        //���z�ɉ����Č����ڂ�ς���
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

    //�͂̃{�^��
    public void OnButtonPower()
    {
        if (money >= price) // �����������i�ȏ゠��ꍇ
        {
            money -= price; // ���������牿�i������
            _moneypossession.text = money.ToString(); // UI���X�V
            sum = sum + price;
            countpawer += 1;
        }
        if (money < price || countpawer >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            pawer.interactable = false;
        }
    }

    //�C�̃{�^��
    public void OnButtonShoes()
    {
        if (money >= moneypey) // �����������i�ȏ゠��ꍇ
        {
            money -= moneypey; // ���������牿�i������
            _moneypossession.text = money.ToString(); // UI���X�V
            sum = sum + moneypey;
            countshoes += 1;
        }
        if (money < moneypey || countshoes >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            shoes.interactable = false;
        }

    }
    //�}�b�v�̃{�^��
    public void OnButtonmap()
    {
        if (money >= mappey) // �����������i�ȏ゠��ꍇ
        {
            money -= mappey; // ���������牿�i������
                             // player = maparray[verticalmap, besidemap];
            Debug.Log(maparray[verticalmap, besidemap]);
            besidemap += 1;
            _moneypossession.text = money.ToString(); // UI���X�V
            sum = sum + mappey;
            countmap += 1;
        }
        if (money < mappey || countmap >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            map.interactable = false;
        }
      
    }

    public void OnCllic()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("test");
        //�{�^���Ƃ�������
        pawer.interactable = true;
        shoes.interactable = true;
        map.interactable = true;
        besidemap = 0;
        verticalmap += 1;
    }
}
