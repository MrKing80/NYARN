using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFromTheBeginning : MonoBehaviour
{
    //�^�C�g���̃X�^�[�g�{�^���ɂ���X�N���v�g


    private void Awake()
    {
        SceneManager.LoadSceneAsync("VolumeChange", LoadSceneMode.Additive);
    }

    public void FirstStageStarts()   //�{�^����������
    {
        SceneManager.LoadScene("MainGameScene");//�����ɃV�[���J�ڂ��邼
    }
}
