using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{    
    [SerializeField,Header("�|�[�Y���j���[�̃I�u�W�F�N�g������Ƃ��낾��[")] private GameObject pauseCanvas = default;
    
    //�|�[�Y�I�u�W�F�N�g���i�[����ϐ�
    private GameObject pause = default;
    
    //�|�[�Y���Ă��邩
    private bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        pause = Instantiate(pauseCanvas, transform.position, Quaternion.identity);  //�|�[�Y�I�u�W�F�N�g����
        pause.SetActive(false); //��\��
    }

    // Update is called once per frame
    void Update()
    {
        //�X�^�[�g�{�^����������ESC�L�[
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.Escape))
        {
            //�ꎞ��~���Ă�����ꎞ��~����߂�
            if(isPause)
            {
                pause.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
            }
            //�ꎞ��~���Ă��Ȃ���Έꎞ��~������
            else if(!isPause)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
        }
    }
}
