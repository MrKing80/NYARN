using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviveButtonScript : MonoBehaviour
{
    //�R���e�j���[��ʂ��������߂̃X�N���v�g
    //���߈Ⴂ�̂��ߖv

    public void Onclick()
    {
        SceneManager.UnloadSceneAsync("ContinuationScenes");//Yes��������R���e�j���[��ʏ���
    }
}
