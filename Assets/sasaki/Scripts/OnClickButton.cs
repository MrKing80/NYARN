using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// �|�[�Y���j���[�̃{�^���Ɏg���X�N���v�g
/// </summary>
public class OnClickButton : MonoBehaviour
{
    /// <summary>
    /// �^�C�g���֖߂�{�^���p�̊֐�
    /// </summary>
    public void GoToTitle()
    {
        SceneManager.LoadScene("SampleTitle");
    }

    /// <summary>
    /// �ĊJ����p�̕ϐ�
    /// </summary>
    public void RetrunToGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
