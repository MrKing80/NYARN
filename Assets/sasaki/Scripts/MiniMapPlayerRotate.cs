using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPlayerRotate : MonoBehaviour
{
    private float inputX = 0f;      //�������̃C���v�b�g���ꂽ�l��ێ�����ϐ�
    private float inputY = 0f;      //�c�����̃C���v�b�g���ꂽ�l��ێ�����ϐ�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");   //�v���C���[�̉������̒l���i�[
        inputY = Input.GetAxisRaw("Vertical");      //�v���C���[�̏c�����̒l���i�[

        //�v���C���[���������Ɉړ������Ƃ������ɉ����ĉ�]
        if (inputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        //�v���C���[���c�����Ɉړ������Ƃ������ɉ����ĉ�]
        if(inputY > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputY < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

}
