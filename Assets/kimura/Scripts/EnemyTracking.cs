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
    private float _obstacleDistance;
    private float _rayAngle;
    [SerializeField] private float _trackingTime = 0;//�ǐՎ���
    [SerializeField] private float _alertTime = 0;//�x������
    [Header("�v���C���[�Ǝ����̋���")]
    [SerializeField] private float _playerDistance;//�v���C���[�Ǝ����̋���
    [Header("�����̏����ʒu")]
  �@[SerializeField] private Vector2 InitialPosition;//�����̏����ʒu  
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
    Transform MyTrans;//�����̈ʒu
    void Start()
    {
        Rig2D = this.GetComponent<Rigidbody2D>();
        MyTrans = this.GetComponent<Transform>();//������Transform���擾
        InitialPosition = MyTrans.position;//�����̏����ʒu���擾       
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        MyVector = MyTrans.position;//�����̌������擾
        //���[�e�[�V���������F�N�^�[�ɓ˂����߂΂�����������Ȃ�
        GetRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, TargetLayer);//���C�L���X�g�����s�i�����͉��j
        ObstacleRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, ObstacleLayer);//��Q�������ʂ��郌�C�L���X�g�����s
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


        if (_trackingTime >= 10 && _playerDistance >= 20)//�v���C���[������������  �ꍇ�ɂ���Ă�or�ɂ���
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


        //if (ObstacleRay)//���C�̋����̃e�X�g
        //{
        //    print("�Ԃ�����");
        //    _obstacleDistance = Vector2.Distance(ObstacleRay.collider.gameObject.transform.position, MyVector);
        //    _rayDistance -= _obstacleDistance;
        //}

       


        if (TrackingFlag)//�ǐՃt���O���I����������
        {
            _playerDistance = Vector2.Distance(PlayerVec, MyVector);
            PlayerVec = TargetPos.position;//�v���C���[�̈ʒu���擾
            print("������" + _playerDistance);
            //�v���C���[��ǂ��|����
            MyTrans.position = Vector2.MoveTowards(MyTrans.position, new Vector2(TargetPos.position.x, TargetPos.position. y), _moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TrackingFlag = true;
        }
    }


}
