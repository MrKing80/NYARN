using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool isCanHide = false;     //�B����邩�ǂ���
    private bool isHiding = false;      //�B��Ă��邩�ǂ���

    private GameObject player = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�B�ꂽ��o���肷�鏈��
        if ((isCanHide || isHiding) && Input.GetKeyDown("joystick button 0"))
        {
            //�B��Ă���ꍇ
            if (isHiding)
            {   
                player.SetActive(true);     //�v���C���[�\��
                player.transform.position = this.transform.position;    //�n�C�h�|�C���g�̈ʒu�Ƀv���C���[��߂�
                isHiding = false;           //���b�J�[����o����
            }

            //�B��Ă��Ȃ��ꍇ
            else if (!isHiding)
            {
                player.SetActive(false);    //�Ղꂢ��[���\��
                isHiding = true;            //���b�J�[�ɉB�ꂽ��
            }
        }

        //���b�J�[�̂��΂ɂ��Ȃ��Ƃ��ϐ���������
        if(!isCanHide)
        {
            player = null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCanHide = true;                   //�B������
            player = collision.gameObject;      //�v���C���[�̏���ێ�
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCanHide = false;          //���b�J�[�̂��΂ɂ��Ȃ���
        }
    }
}
