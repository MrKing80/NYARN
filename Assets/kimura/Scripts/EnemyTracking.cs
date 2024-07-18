using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rig2D;
    RaycastHit2D GetRay;//�����̎���
    RaycastHit2D ObstacleRay;
    private Vector2 PlayerVec;//�v���C���[�̈ʒu���擾����
    private Vector2 MyVector;//�����̌���
    private Vector2 MoveDirection;
    private float _obstacleDistance;
    private float _rayAngle;
    [Header("�ǐՎ���")]
    [SerializeField] private float _trackingTime = 0;//�ǐՎ���
    [Header("�x������")]
    [SerializeField] private float _alertTime = 0;//�x������
    [Header("�v���C���[�Ǝ����̋���")]
    [SerializeField] private float _playerDistance;//�v���C���[�Ǝ����̋��� 
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("�v���C���[�̃��C���[")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("��Q���̃��C���[")]
    [SerializeField] private LayerMask ObstacleLayer;    
    [Header("�v���C���[�̈ʒu")]
    [SerializeField] Transform TargetTrans;//�v���C���[�̈ʒu
    [Header("�����̒ǐՑ��x")]
    [SerializeField] private float _trackingSpeed = 5;//�G�̃X�s�[�h
    [Header("�ǐՃt���O")]
    [SerializeField] private bool TrackingFlag = false;//�ǐՃt���O
    Transform MyTrans;//�����̈ʒu
    EnemyMove GetMove;
    EnemyVisionScript GetEnemyVision;
    void Start()
    {
        Rig2D = this.GetComponent<Rigidbody2D>();
        GetMove = this.GetComponent<EnemyMove>();//�����̓������擾
        MyTrans = GetMove.MyTrans;//������Transform���擾
        GetEnemyVision = GetComponentInChildren<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        //_rayAngle = MyTrans.eulerAngles.z * Mathf.Deg2Rad;
        MyVector = GetMove.MyTrans.position;//�����̌������擾
        //���[�e�[�V���������F�N�^�[�ɓ˂����߂΂�����������Ȃ�
        GetRay = Physics2D.Raycast(MyTrans.position, GetEnemyVision.VisionVec, _rayDistance, TargetLayer);//���C�L���X�g�����s�i�����͉��j
        ObstacleRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, ObstacleLayer);//��Q�������ʂ��郌�C�L���X�g�����s
        Debug.DrawRay(MyTrans.position, GetEnemyVision.VisionVec * _rayDistance, Color.red);//���C������

        if (GetRay)//�v���C���[�����C�ɐG�ꂽ��
        {
            TrackingFlag = true;
            _trackingTime = 0;
            _alertTime = 0;
        }

        else if (!GetRay && TrackingFlag)//���C�Ƀq�b�g���Ă��Ȃ����A�ǂ������Ă�Œ���������
        {
            print("�̂�����");
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
                MyTrans.position = Vector2.MoveTowards(MyTrans.position, GetMove.InitialPosition, _trackingSpeed * Time.deltaTime);
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
            _playerDistance = Vector2.Distance(PlayerVec, MyVector);//�����ƃv���C���[�̋������v�Z
            print("�ق��ċA��悭�Ȃ��I�I�I");
            PlayerVec = TargetTrans.position;//�v���C���[�̈ʒu���擾
            MyTrans.position = Vector2.MoveTowards(MyTrans.position, new Vector2(TargetTrans.position.x, TargetTrans.position. y), _trackingSpeed * Time.deltaTime); //�v���C���[��ǂ��|����
            //GetRay = Physics2D.Raycast(MyTrans.position, new Vector2(Mathf.Cos(_rayAngle), Mathf.Sin(_rayAngle)), _rayDistance, TargetLayer);
            MoveDirection = TargetTrans.position - MyTrans.position;
            _rayAngle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            GetEnemyVision.VisionTrans.rotation = Quaternion.Euler(new Vector3(0, 0, _rayAngle));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//�v���C���[�ƒǓ˂�����ǐՊJ�n
        {
            TrackingFlag = true;
           
        }
    }
}
