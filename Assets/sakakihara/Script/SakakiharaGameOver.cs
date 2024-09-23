using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SakakiharaGameOver : MonoBehaviour
{
    //�R���e�j���[��ʂ��o�����߂̃X�N���v�g
    //���߈Ⴂ�̂��ߖv

    [Header("�Q�[���I�[�o�[�e�L�X�g������")]
    [SerializeField] private TMP_Text gameOverUI;   //�Q�[���I�[�o�[�e�L�X�g������
    [Header("�Q�[���I�[�o�[����R���e�j���[�o���܂ł̎���")]
    [SerializeField] private float TimeToDisplay;   //�R���e�j���[�o���܂ł̎���

    [Header("�v���C���[�I�u�W�F�N�g������")]
    [SerializeField] private GameObject playerObj;  //�v���C���[�I�u�W�F�N�g������
    [Header("�Q�[���J�n���̃v���C���[�ʒu������")]
    [SerializeField] private GameObject spawnPosition;  //�J�n�n�_������

    private bool isTr = false;  //�R���e�j���[��ʂ��o�Ă���̂��m�F

    void Update()
    {
        if (isTr)   //�R���e�j���[��ʏo���Ă�����o���Ȃ��悤�ɂ���
        {
            return;
        }
        if (gameOverUI.enabled)    //�Q�[���I�[�o�[�o�Ă�Ƃ��ɃR���e�j���[��ʏo��
        {
            Invoke("ContinuationStart", TimeToDisplay);
            isTr = true;
        }

    }
    private void ContinuationStart()    //���̃V�[����ɏo��
    {
        gameOverUI.enabled = false;
        isTr = false;
        SceneManager.LoadSceneAsync("ContinuationScenes", LoadSceneMode.Additive);  //���Ƃ��Əo���Ă�V�[���͂��̂܂܂ɃR���e�j���[�V�[�����o��
        playerObj.transform.position = spawnPosition.transform.position;�@//�v���C���[���w�肵���X�^�[�g�|�W�V�����Ɉړ�
        Time.timeScale = 0;

    }
}

