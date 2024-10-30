using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    [SerializeField, Header("�X�s�[�h�{��������Ƃ��낾��[")] private float magnification = 3.9f;

    //�v���C���[�̈ړ��X�N���v�g���i�[����Ƃ���
    private PlayerMove move = default;

    //�v���C���[���i�[����Ƃ���
    private GameObject player = default;

    //�o�t�̌��ʎ���
    [SerializeField] private float buffTime = 3f;

    //�ꎞ�I�ɃX�s�[�h���i�[����Ƃ���
    public float tmpSpeed = 0;

    //�v���C���[�̏����X�s�[�h���i�[����Ƃ���
    private float initialSpeed = default;

    //�G��Ă��邩
    private bool isTouch = false;

    //�Q�b�g���Ă��邩
    private bool isGet = false;

    // ���ʈ�ǉ� �G�t�F�N�g�p
    [SerializeField] private GameObject dashSmork = default;
    // �󂯓n���p�̃p�u���b�N�ϐ� 
    public float BuffItem{ get => buffTime; }
    public bool IsGet { get => isGet; }

    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //�ꎞ��~����Ă����珈�������Ȃ�
        if (Time.timeScale == 0)
        {
            return;
        }

        //A�{�^���������͍��N���b�N���������Ƃ�
        if (isTouch && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            move = player.GetComponent<PlayerMove>();   //�X�N���v�g�擾

            // ���ʈ�ǉ� �q�I�u�W�F�N�g��GameObj�擾
            dashSmork = player.transform.GetChild(1).gameObject;

            initialSpeed = move.SpeedProperty;          //�����X�s�[�h��ۑ�
            tmpSpeed = move.SpeedProperty * magnification;  //�X�s�[�h�A�b�v
            
            move.SpeedProperty = tmpSpeed;      //�X�s�[�h�ύX

            isGet = true;

            // ���ʈ�ǉ� �C���ρ@
            if (initialSpeed < tmpSpeed)
                dashSmork.SetActive(true);

            this.GetComponent<SpriteRenderer>().enabled = false;    
                                                                        //��\��            
            this.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (isGet)
        {
            buffTime -= Time.deltaTime;     //���Ԍv��

            //���ʎ��ԏI��������
            if (buffTime <= 0)
            {
                move.SpeedProperty = initialSpeed;  //�X�s�[�h�����ɖ߂�
                dashSmork.SetActive(false);
                player = null;      
                isGet = false;      //�e��ϐ�������
                buffTime = 3f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = true;
            player = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
