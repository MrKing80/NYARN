using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapCameraScript : MonoBehaviour
{
    //MapCamera�ɂ���X�N���v�g
    //�~�j�}�b�v�Ƒ傫���}�b�v�����ɕ\������ꍇ�̓��C���[���uMinMap�v�ɂ��Ă�������
    //�傫���}�b�v�ɕ\���������Ȃ����̂̓��C���[���uNotBegMap�v�ɂ��Ă�������


    [SerializeField] GameObject player;//�ǂ�������Ώ�

    [SerializeField] GameObject bigMapObject;//�傫���}�b�v
    [SerializeField] GameObject minMapObject;//�݂Ƀ}�b�v
    [SerializeField] GameObject mapObject;//�}�b�v

    private Camera cameraComponent;//�J�����R���|�[�l���g
    private float bigCameraSize = -47;//�傫���}�b�v�̃J�����\���͈�
    private float minCameraSize = -15;//�~�j�}�b�v�̃J�����\���͈�
    Vector3 mapTransform;//�}�b�v�̈ʒu�擾

    private bool isBigMap = false;//�傫���}�b�v�\�����Ă邩
    private bool isBigMapFrag = false;//�����{�^���Ő؂�ւ��邽�߂̃t���O


    private void Start()
    {
        cameraComponent = this.gameObject.GetComponent<Camera>();//�J�����̃J�����擾
        bigMapObject.SetActive(false);//�傫���}�b�v�\�����Ȃ�
        mapTransform = mapObject.transform.position;//map�ʒu�擾
    }
    void Update()
    {
        if (!isBigMap) //�傫���}�b�v�o���Ė�����
        {
            CameraMove();//�v���C���[�ɃJ���������Ă���
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (!isBigMapFrag)
            {
                isBigMap = true;//�傫���}�b�v�\�����Ă锻��

                cameraComponent.orthographicSize = bigCameraSize;//�J�����̕\���͈͂�傫������
                transform.position = new Vector3(mapTransform.x, mapTransform.y, transform.position.z);//�J�����Œ�
                cameraComponent.LayerCullingHide("NotBegMap"); // �w�肵�����C���[���\��

                minMapObject.SetActive(false);//�݂Ƀ}�b�v��\��
                bigMapObject.SetActive(true);//�傫���}�b�v�\��
            }

            if (isBigMapFrag)
            {
                isBigMap = false;//�傫���}�b�v�����Ă锻��

                cameraComponent.orthographicSize = minCameraSize;//�J�����̕\���͈͂�߂�
                cameraComponent.LayerCullingShow("NotBegMap"); // �w�肵�����C���[��\��

                bigMapObject.SetActive(false); //�傫���}�b�v��\��
                minMapObject.SetActive(true);//�݂Ƀ}�b�v�\��
            }
        }
       if (Input.GetKeyUp(KeyCode.X))
        {
            if (!isBigMap)
            {
                isBigMapFrag = false;//�}�b�v��\�����邽�߂̃t���O
            }
             if (isBigMap)
            {
                isBigMapFrag = true;//�}�b�v���������߂̃t���O
            }
        }

       
    }
    void CameraMove()//�v���C���[�ǔ�
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);//�v���C���[�̂ɂ��Ă�����
    }
}
