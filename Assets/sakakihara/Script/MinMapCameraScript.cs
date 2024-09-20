using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapCameraScript : MonoBehaviour
{
    //MapCamera�ɂ���X�N���v�g
    //�~�j�}�b�v�Ƒ傫���}�b�v�����ɕ\������ꍇ�̓��C���[���uMinMap�v�ɂ��Ă�������
    //�傫���}�b�v�ɕ\���������Ȃ����̂̓��C���[���uNotBegMap�v�ɂ��Ă�������

    [Header("�~�j�}�b�v�Œǔ�����Ώ�")]
    [SerializeField] GameObject player;//�ǂ�������Ώ�

    [Header("�傫���}�b�v")]
    [SerializeField] GameObject bigMapObject;//�傫���}�b�v
    [Header("�������}�b�v")]
    [SerializeField] GameObject minMapObject;//�݂Ƀ}�b�v
    [Header("�^�C���}�b�v�ō����Map������")]
    [SerializeField] GameObject mapObject;//�}�b�v

    private Camera cameraComponent;//�J�����R���|�[�l���g
    private float bigCameraSize = -47;//�傫���}�b�v�̃J�����\���͈�
    private float minCameraSize = -15;//�~�j�}�b�v�̃J�����\���͈�
    Vector3 mapTransform;//�}�b�v�̈ʒu�擾

    private bool isBigMap = false;//�傫���}�b�v�\�����Ă邩
    private bool isBigMapFrag = false;//�����{�^���Ő؂�ւ��邽�߂̃t���O

    //��]�p
    //Vector3 playerRotationPos;
    //float roPog;

    private void Start()
    {
        cameraComponent = this.gameObject.GetComponent<Camera>();//�J������Camera�擾
        bigMapObject.SetActive(false);//�傫���}�b�v�\�����Ȃ�
        mapTransform = mapObject.transform.position;//���e����map�ʒu�擾
    }
    void Update()
    {

        if (!isBigMap) //�傫���}�b�v�o���Ė�����
        {
            CameraMove();//�v���C���[�ɃJ���������Ă���
            //CameraRotation();//�}�b�v��]�p
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("joystick button 6"))//�L�[��������
        {
            if (!isBigMapFrag)
            {
                BigMap();
            }

            if (isBigMapFrag)
            {
                NotBigMap();
            }
        }
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Tab) || Input.GetKeyDown("joystick button 6"))
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

    private void CameraMove()//�v���C���[�ǔ�
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);//�v���C���[�̂ɂ��Ă�����
    }

    private void BigMap()//�傫���}�b�v�\��
    {
        isBigMap = true;//�傫���}�b�v�\�����Ă锻��
        Time.timeScale = 0;
        cameraComponent.orthographicSize = bigCameraSize;//�J�����̕\���͈͂�傫������
        transform.position = new Vector3(mapTransform.x, mapTransform.y, transform.position.z);//�J�����Œ�
        cameraComponent.LayerCullingHide("NotBigMap"); // �w�肵�����C���[���\��

        minMapObject.SetActive(false);//�݂Ƀ}�b�v��\��
        bigMapObject.SetActive(true);//�傫���}�b�v�\��
    }

    void NotBigMap()//�傫���}�b�v�����Ă�
    {
        isBigMap = false;//�傫���}�b�v�����Ă锻��
        Time.timeScale = 1;
        cameraComponent.orthographicSize = minCameraSize;//�J�����̕\���͈͂�߂�
        cameraComponent.LayerCullingShow("NotBigMap"); // �w�肵�����C���[��\��

        bigMapObject.SetActive(false); //�傫���}�b�v��\��
        minMapObject.SetActive(true);//�݂Ƀ}�b�v�\��
    }
    //private void CameraRotation() //�}�b�v��]�p�@���v���C���[�������������ۉ�]�������邽�߃R�����g��
    //{
    //    //��
    //    Vector3 playerRotationPos = this.player.transform.eulerAngles;
    //    Vector3 cameraRotationPos = this.gameObject.transform.eulerAngles;
    //    //��

    //    //Vector3 roPos = new Vector3(0, 0, playerRotationPos.z);

    //    //��
    //    if (cameraRotationPos.z - 180f == playerRotationPos.z)
    //    {
    //        return;
    //    }
    //    else if (cameraRotationPos.z - 180f > playerRotationPos.z - 1f)//0=180-180
    //    {
    //        //transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
    //        roPog -= Time.deltaTime * 90;//�����v���
    //                                     //Time.deltaTime * 20f;
    //        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, roPog);
    //    }
    //    else if (cameraRotationPos.z - 180f < playerRotationPos.z - 1f)
    //    {
    //        //transform.Translate(Vector3.back * Time.deltaTime);
    //        roPog += Time.deltaTime * 90;//���v���
    //        //Time.deltaTime * 20f;
    //        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, roPog);
    //    }
    //    //��

    //    //transform.rotation = Quaternion.Euler(0, 0, playerRotationPos.z - 180f);//��

    //    //Quaternion rot = Quaternion.LookRotation(roPos);

    //    //rot = Quaternion.Slerp(this.transform.rotation, rot, Time.deltaTime * 2f);
    //    //this.transform.rotation = rot;
    //}
}
