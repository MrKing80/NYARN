using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonScript : MonoBehaviour
{
    //�{�^�����L�[�{�[�h�ŉ�����悤�ɂ���X�N���v�g

    private float inputX = 0;//�L�[����

    [Header("�����̃{�^��")]
    [SerializeField] Button yesButton;�@//���{�^��
    [Header("�E���̃{�^��")]
    [SerializeField] Button noButton;   //�E�{�^��

    private void Update()
    {
        //�L�[���͂̎�t
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
