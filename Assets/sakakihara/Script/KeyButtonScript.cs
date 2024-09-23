using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonScript : MonoBehaviour
{
    //�{�^�����L�[�{�[�h�ŉ�����悤�ɂ���X�N���v�g

    private float inputX = 0;//�L�[����
    private float inputZ = 0;//�L�[����

    [Header("�����̃{�^��")]
    [SerializeField] Button yesButton;�@//���{�^��
    [Header("�E���̃{�^��")]
    [SerializeField] Button noButton;   //�E�{�^��

    [Header("�㑤�̃{�^��")]
    [SerializeField] Button upButton ;�@//��{�^��
    [Header("�����̃{�^��")]
    [SerializeField] Button downButton ;   //���{�^��

    private void Update()
    {
        //�L�[���͂̎�t
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        //if (upButton == null) return;// ���E�Ƀ{�^�������Ƃ��������Ȃ��悤�ɂ���
        LeftAndRightButtons();//���E�̈ړ�

        //if (upButton == null) return;// �㉺�Ƀ{�^�������Ƃ��������Ȃ��悤�ɂ���
        //UpAndDownButton();//�㉺�̈ړ�

    }

    private void LeftAndRightButtons()//���E�{�^��
    {
        if (inputX > 0)
        {
            noButton.Select();
        }
        if (inputX < 0)
        {
            yesButton.Select();
        }
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
        }
    }
}
