using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SakakiharaGameOver : MonoBehaviour
{
    //�R���e�j���[��ʂ��o�����߂̃X�N���v�g
    //���߈Ⴂ�̂��ߖv

    [SerializeField] private TMP_Text gameOverUI;//�Q�[���I�[�o�[�e�L�X�g������
    [SerializeField] private float TimeToDisplay;//�R���e�j���[�o���܂ł̎���

    private bool isTr = false;//�R���e�j���[��ʂ��o�Ă���̂��m�F

    void Update()
    {
        if (isTr)//�R���e�j���[��ʏo���Ă�����o���Ȃ��悤�ɂ���
        {
            return;
        }
        if (gameOverUI.enabled)//�Q�[���I�[�o�[�o�Ă�Ƃ��ɃR���e�j���[��ʏo��
        {
            Invoke("ContinuationStart", TimeToDisplay);
            isTr = true;
        }
        else
        {
            isTr = false;
            
        }


    }
    private void ContinuationStart()    //���̃X�N���v�g��ɏo��
    {
        gameOverUI.enabled = false;
        SceneManager.LoadSceneAsync("ContinuationScenes", LoadSceneMode.Additive);
    }
}

