using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartFromTheBeginning : MonoBehaviour
{
    //�^�C�g���̃X�^�[�g�{�^���ɂ���X�N���v�g
    [SerializeField, Multiline(1)]//������
    private string scriptMemo = ("�{�^�����������炷���Q�[�����n�܂�X�N���v�g");

    public void FirstStageStarts()   //�{�^����������
    {
        SceneManager.LoadScene("MainGameScene");//�����ɃV�[���J�ڂ��邼
    }
}
