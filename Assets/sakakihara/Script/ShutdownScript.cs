using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownScript : MonoBehaviour
{
    [Header("�Q�[����߂�������Ă���Q�[���I������܂ł̎���")]
    [SerializeField] private float shutdownTime;    //�Q�[���I���܂ł̎���

    [Header("�^�C�g���̕����E�X�^�[�g�{�^���Ƃ��̃Z�b�g�I�u�W�F�N�g")]
    [SerializeField] private GameObject title;//�^�C�g���A�C�e��
    [Header("�Q�[����߂�H�Z�b�g�̃I�u�W�F�N�g")]
    [SerializeField] private GameObject confirmationScreen;//�I���m�F���
    
    [Header("�{�^������")]
    [SerializeField, Multiline(5)]//�������i�S�s�j
    private string buttonMemo
        = ("ShouldIStopPlayingGames()   //�Q�[����߂�{�^���������� \n ShutdownYes()   //�͂��A��߂܂� \n ShutdownNo()    //�������A��߂܂��� ");


    public void ShouldIStopPlayingGames()   //�Q�[����߂�{�^����������
    {
        title.SetActive(false);
        confirmationScreen.SetActive(true);
    }

    public void ShutdownYes()   //�͂��A��߂܂�
    {
        Invoke("GameShutdown", shutdownTime);
    }

    public void ShutdownNo()    //�������A��߂܂���
    {
        title.SetActive(true);
        confirmationScreen.SetActive(false);
    }


    private void GameShutdown()
    {
        Application.Quit();     //�Q�[�����I������
    }
}
