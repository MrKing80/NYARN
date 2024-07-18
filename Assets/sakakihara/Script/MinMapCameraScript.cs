using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapCameraScript : MonoBehaviour
{
    //MapCamera�ɂ���X�N���v�g

    [SerializeField] GameObject player;//�ǂ�������Ώ�

    [SerializeField] GameObject bigMapObject;//�傫���}�b�v

    private Camera cameraComponent;//�J�����R���|�[�l���g
    private float bigCameraSize = -47;//�傫���}�b�v�̃J�����\���͈�
    private float minCameraSize = -15;//�~�j�}�b�v�̃J�����\���͈�

    private float bigMapPg_x = 11.5f;//�傫���}�b�v���̃J�����ʒuX
    private float bigMapPg_y = 25.6f;//�傫���}�b�v���̃J�����ʒuY

    private bool isBigMap = false;

    private void Start()
    {
        cameraComponent = this.gameObject.GetComponent<Camera>();
        bigMapObject.SetActive(false);
    }
    void Update()
    {
        if (!isBigMap) //�傫���}�b�v�o���Ė�����
        {
            CameraMove();//�v���C���[�ɃJ���������Ă���
        }

        if (Input.GetKey(KeyCode.X))
        {
            isBigMap = true;//�傫���}�b�v�\�����Ă锻��
            bigMapObject.SetActive(true);//�傫���}�b�v�\��
            cameraComponent.orthographicSize = bigCameraSize;//�J�����̕\���͈͂�傫������
            transform.position = new Vector3(bigMapPg_x, bigMapPg_y, transform.position.z);//�J�����Œ�
        }

        if (Input.GetKey(KeyCode.C))
        {
            isBigMap = false;//�傫���}�b�v�����Ă锻��
            bigMapObject.SetActive(false); //�傫���}�b�v����
            cameraComponent.orthographicSize = minCameraSize;//�J�����̕\���͈͂�߂�
        }




    }
    void CameraMove()//�v���C���[�ǔ�
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);//�v���C���[�̂ɂ��Ă�����
    }
}
