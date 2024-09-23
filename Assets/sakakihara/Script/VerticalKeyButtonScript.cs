using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VerticalKeyButtonScript : MonoBehaviour
{
    //�{�^�����L�[�{�[�h�ŉ�����悤�ɂ���X�N���v�g

    private float inputX = 0;//�L�[����
    private float inputZ = 0;//�L�[����

    [Header("�����̃{�^��")]
    [SerializeField] Button yesButton;�@//���{�^��
    [Header("�E���̃{�^��")]
    [SerializeField] Button noButton;   //�E�{�^��

    [Header("BGM�X���C�_�[�����")]
    [SerializeField] Slider bGMSlider;//BGM�X���C�_�[�����

    [Header("�㑤�̃{�^��")]
    [SerializeField] Button upButton;�@//��{�^��
    [Header("�����̃{�^��")]
    [SerializeField] Button downButton;   //���{�^��

    private void Start()
    {
        bGMSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        //�L�[���͂̎�t
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        LeftAndRightButtons();//���E�̈ړ�

        if (upButton == null) return;// �㉺�Ƀ{�^�������Ƃ��������Ȃ��悤�ɂ���
        UpAndDownButton();//�㉺�̈ړ�

    }

    private void LeftAndRightButtons()//���E�{�^��
    {

    }
    private void UpAndDownButton()//�㉺�{�^��
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
