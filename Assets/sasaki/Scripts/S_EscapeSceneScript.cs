using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EscapeSceneScript : MonoBehaviour
{
    //�o���ɂ���X�N���v�g
    //�o���ɐG�ꂽ��V�[���ړ�����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainGameScene");//�����ɃV�[���J�ڂ��邼
        }
    }
}
