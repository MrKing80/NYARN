using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneypossession;
    private int money = 1000000000;

    [SerializeField] private Animator anim;

    // �{�^���̉��i
    [SerializeField] private int price = 100000;
    [SerializeField] private int moneypey = 200000;
    [SerializeField] private int mappey = 500000;
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
    [SerializeField] private int common_people = 700000;
    [SerializeField] private int wealthy = 1500000;
    [SerializeField] private int millionaire = 2000000;
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

    private MainGameMoneyManager mainMoney = default;

    void Start()
    {
        mainMoney = GameObject.Find("NowMoneyManager").GetComponent<MainGameMoneyManager>();

        money = mainMoney.NowHaveMoneyProperty;

        _moneypossession.text = money.ToString("N0"); // UI��������

        SceneManager.sceneLoaded += OnSceneLoaded;  //sceneLoaded�Ɋ֐���ǉ�

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

        if (money < price || countpawer >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            pawer.interactable = false;
        }
        if (money < moneypey || countshoes >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            shoes.interactable = false;
        }
        if (money < mappey || countmap >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            map.interactable = false;
        }
    }

    //�͂̃{�^��
    public void OnButtonPower()
    {
        if (money >= price) // �����������i�ȏ゠��ꍇ
        {
            money -= price; // ���������牿�i������
            _moneypossession.text = money.ToString("N0"); // UI���X�V
            sum = sum + price;
            countpawer += 1;
            SoundEffects();
            anim.SetBool("oji", true);
            Invoke("Anime", 0.3f);
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
            _moneypossession.text = money.ToString("N0"); // UI���X�V
            sum = sum + moneypey;
            countshoes += 1;
            SoundEffects();
            anim.SetBool("oji", true);
            Invoke("Anime", 0.3f);
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
            //Debug.Log(maparray[verticalmap, besidemap]);
            besidemap += 1;
            _moneypossession.text = money.ToString("N0"); // UI���X�V
            sum = sum + mappey;
            countmap += 1;
            SoundEffects();
            anim.SetBool("oji", true);
            Invoke("Anime", 0.3f);
        }
        if (money < mappey || countmap >= 3) // ���i���������ȏ゠��ꍇ�{�^�������Ȃ�����
        {
            map.interactable = false;
        }

    }

    public void OnCllic()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("SampleTitle");
        //�{�^���Ƃ�������
        this.gameObject.SetActive(false);
       // besidemap = 0;
      //  verticalmap += 1;
    }

    public void SoundEffects()
    {
        GetComponent<AudioSource>().Play();

    }
    public void Anime()
    {
        anim.SetBool("oji", false);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "shop")
        {
            countpawer = 0;
            countshoes = 0;
            countmap = 0;
            besidemap = 0;
            pawer.interactable = true;
            shoes.interactable = true;
            map.interactable = true;

            verticalmap += 1;
//            money += 20000;
            _moneypossession.text = money.ToString(); // UI���X�V
        }
    }
}
