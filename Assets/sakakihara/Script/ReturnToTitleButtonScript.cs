using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleButtonScript : MonoBehaviour
{
    //�R���e�j���[��ʂł̃^�C�g���߂邩�ǂ���
    //���߈Ⴂ�̂��ߖv

   [SerializeField] private GameObject ReviveButtons;
   [SerializeField] private GameObject TitleButtons;
    [SerializeField, Multiline(5)]//�������i�S�s�j
    private string layerMemo = ("GoBackToTheTitle()//�������Ȃ���I�� \n IllStopAfterAll()//����σ^�C�g���s���̂�߂� \n ReturnToTitle()//�^�C�g���ɖ߂�ɓ��� \n 0 \n");

    public void GoBackToTheTitle()//�������Ȃ���I��
    {
        ReviveButtons.SetActive(false);
        TitleButtons.SetActive(true);
    }
    public void IllStopAfterAll()//����σ^�C�g���s���̂�߂�
    {
        ReviveButtons.SetActive(true);
        TitleButtons.SetActive(false);
    }

    public void ReturnToTitle()//�^�C�g���ɖ߂�ɓ���
    {
        SceneManager.LoadScene("TitleScene");//�����ɃV�[���J�ڂ��邼
    }
}
