using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeSceneScript : MonoBehaviour
{
    //�o���ɂ���X�N���v�g
    //�o���ɐG�ꂽ��V�[���ړ�����

    //�@8/22���_�ł͎����̃V�[�������[�h����悤�ɂ��Ă����

   private string sceneName;//�V�[�����擾�p

    private void Start()
    {
         sceneName = SceneManager.GetActiveScene().name;//�����[���h���擾

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);//�����ɃV�[���J�ڂ��邼
        }
    }

}
