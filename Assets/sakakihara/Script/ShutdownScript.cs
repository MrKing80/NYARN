using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownScript : MonoBehaviour
{
    [SerializeField] private float shutdownTime;    //�Q�[���I���܂ł̎���

    [SerializeField] private GameObject title;//�^�C�g���A�C�e��
    [SerializeField] private GameObject confirmationScreen;//�I���m�F���
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
