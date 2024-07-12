using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rig2D;
    RaycastHit2D GetRay;
    RaycastHit2D ObstacleRay;
    private Vector2 PlayerVec;//�v���C���[�̈ʒu���擾����
    private Vector2 MyVector;
    [SerializeField] private float _trackingTime = 0;//�ǐՎ���
    [SerializeField] private float _alertTime = 0;//�x������
    [Header("�v���C���[�Ǝ����̋���")]
    [SerializeField] private float _distance;//�v���C���[�Ǝ����̋���
    [Header("�����̏����ʒu")]
  �@[SerializeField]private Vector2 InitialPosition;//�����̏����ʒu  
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("�v���C���[�̃��C���[")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("��Q���̃��C���[")]
    [SerializeField] private LayerMask ObstacleLayer;    
    [Header("�v���C���[�̈ʒu")]
    [SerializeField] Transform TargetPos;//�v���C���[�̈ʒu
    [Header("�����̃X�s�[�h")]
    [SerializeField] private float _moveSpeed = 5;//�G�̃X�s�[�h
    [Header("�ǐՃt���O")]
    [SerializeField] private bool TrackingFlag = false;//�ǐՃt���O
    private int Hit;
    Transform MyTrans;//�����̈ʒu
    void Start()
    {
        Rig2D = this.GetComponent<Rigidbody2D>();
        MyTrans = this.GetComponent<Transform>();//������Transform���擾
        InitialPosition = MyTrans.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        MyVector = MyTrans.position;//�����̌������擾
        //���[�e�[�V���������F�N�^�[�ɓ˂����߂΂�����������Ȃ�
        GetRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, TargetLayer);//���C�L���X�g�����s�i�����͉��j
        ObstacleRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, ObstacleLayer);
        Debug.DrawRay(MyTrans.position, MyTrans.right * _rayDistance, Color.red);//���C������

        if (GetRay)//�v���C���[�����C�ɐG�ꂽ��
        {
            TrackingFlag = true;
            _trackingTime = 0;
            _alertTime = 0;
        }

        else if (!GetRay && TrackingFlag)//���C�Ƀq�b�g���Ă��Ȃ����A�ǂ������Ă�Œ���������
        {
            print("�̂�����");
            print("�����̈ʒu��"+MyVector);
            _trackingTime += Time.deltaTime;          
        }

        if (_trackingTime >= 10 && _distance >= 20)//�v���C���[������������  �ꍇ�ɂ���Ă�or�ɂ���
        {
            TrackingFlag = false;          
            _alertTime += Time.deltaTime;
            print("�ǂ��H");
            if (_alertTime >= 10)
            {
                //�����ʒu�ɖ߂�
                MyTrans.position = Vector2.MoveTowards(MyTrans.position, InitialPosition, _moveSpeed * Time.deltaTime);
                print("���ꂽ");
            }
        }

        if (TrackingFlag)//�ǐՃt���O���I����������
        {
            _distance = Vector2.Distance(PlayerVec, MyVector);
            PlayerVec = TargetPos.position;//�v���C���[�̈ʒu���擾
            print("������" + _distance);
            //�v���C���[��ǂ��|����
            MyTrans.position = Vector2.MoveTowards(MyTrans.position, new Vector2(TargetPos.position.x, TargetPos.position. y), _moveSpeed * Time.deltaTime);
        }
    }

   
}
