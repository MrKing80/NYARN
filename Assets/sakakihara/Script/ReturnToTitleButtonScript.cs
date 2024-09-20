using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleButtonScript : MonoBehaviour
{
    //�R���e�j���[��ʂł̃^�C�g���߂邩�ǂ���
    //���߈Ⴂ�̂��ߖv
    [SerializeField, Multiline(1)]//������
    private string scriptMemo = ("�R���e�j���[��ʂł̃^�C�g���߂邩�ǂ���");

    [Header("�Q�[���ɖ߂�H�Z�b�g������")]
    [SerializeField] private GameObject ReviveButtons;
    [Header("�ق�ƂɃ^�C�g���ɖ߂�H�Z�b�g������")]
    [SerializeField] private GameObject TitleButtons;

    [Header("�{�^������")]
    [SerializeField, Multiline(5)]//�������i�S�s�j
    private string buttonsMemo = ("�EGoBackToTheTitle() ���������Ȃ���I�� \n �EIllStopAfterAll() //����σ^�C�g���s���̂�߂� \n �EReturnToTitle() //�^�C�g���ɖ߂�ɓ��� \n  \n");

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
        SceneManager.LoadScene("SampleTitle");//�����ɃV�[���J�ڂ��邼
    }
}
