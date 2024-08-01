using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    public enum ChangeAngle
    {
        One = 90,
        Two = 180,
        Tree = 270
    }
    [Header("���񎞂̈ړ�����")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;//�f�t�H���g�͉E����
    [Header("���񎞂̊p�x����")]
    [SerializeField] private ChangeAngle GetAngle = ChangeAngle.One;//�f�t�H���g�͂X�O�x��]������
    [Header("��Q���̃��C���[")]
    [SerializeField] private LayerMask ObstacleLayer;
    [Header("�v���C���[�̃��C���[")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("���C�̔��a")]
    [SerializeField] private float _rayRadius = 1f;
    [SerializeField] private float _maxDistance = 10f;
    public Vector2 GetVisonVec//VisionVec�̃v���p�e�B
    {
        get { return VisionVec; }
        set { VisionVec = value; }
    }
    private Transform VisionTrans;//�����̈ʒu
    [Header("���񂳂��邩���䂷��")]
    private bool isPatrol = true;//�p�g���[�������ǂ������䂷��
    public bool existIsPatrol//isPatrol�̃v���p�e�B
    {
        get { return isPatrol; }
        set { isPatrol = value; }
    }
    private float _myRotation;//�����̊p�x 
    public float GetMyRotation
    {
        get { return _myRotation; }
        set { _myRotation = value; }
    }
    private float _radians;//�p�x�������ɕϊ����邽�߂̐��l
    private float _angleOffset = 15f;
    private GameObject ParentObject;//�e�I�u�W�F�N�g���i�[����ꏊ
    private Vector2 VisionVec;//�����̌���
    private Vector2 Hit2Vec;
    private Vector2 Hit3Vec;
    RaycastHit2D ObstacleRay;//��Q�����������鎋��
    RaycastHit2D PresenceRay;
    EnemyTracking GetTracking;
    // Start is called before the first frame update
    void Start()
    {
        ParentObject = transform.parent.gameObject;//�e�X�g�p�ɐe�I�u�W�F�N�g���擾        
        print(ParentObject.name);
        VisionTrans = this.GetComponent<Transform>();
        GetTracking = GetComponentInParent<EnemyTracking>();
        _myRotation = VisionTrans.rotation.z;//�����̊p�x���擾
        if (isPatrol)//�x������������EnemyMove�X�N���v�g�ňړ�������
        {
            switch (_direction)//�ŏ��Ɉړ��������
            {
                case MoveDirection.Up:
                    _myRotation += 90;
                    break;
                case MoveDirection.Down:
                    _myRotation += 270;
                    break;
                case MoveDirection.Right:
                    _myRotation += 0;
                    break;
                case MoveDirection.Left:
                    _myRotation += 180;
                    break;           
            }          
        }
    }

    // Update is called once per frame
    void Update()
    {
        VisionConvert();
      
        RaycastHit2D hit1 = Physics2D.Raycast(VisionTrans.position, VisionVec, _rayDistance, TargetLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(VisionTrans.position,Hit2Vec, _rayDistance, TargetLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(VisionTrans.position,Hit3Vec, _rayDistance, TargetLayer);
        Debug.DrawRay(VisionTrans.position, GetVisonVec * _rayDistance, Color.red);
        Debug.DrawRay(VisionTrans.position, Hit2Vec * _rayDistance, Color.blue);
        Debug.DrawRay(VisionTrans.position, Hit3Vec * _rayDistance, Color.green);
        ObstacleRay = Physics2D.Raycast(VisionTrans.position, VisionVec, _rayDistance, ObstacleLayer);//��Q�����������郌�C
        PresenceRay = Physics2D.CircleCast(VisionTrans.position, _rayRadius, VisionVec,_maxDistance,TargetLayer);//���p�ł��v���C���[�@�m�ł���悤�ɂ��郌�C
      
        if (isPatrol && ObstacleRay.collider!=null && ObstacleRay.collider.gameObject!=ParentObject)//���񎞁A��Q���ɓ���������
        {
            print("��������");
            _myRotation += (int)GetAngle;//������GetAngle�Ŏw�肵���p�x�ɌX������
            print(_myRotation);
            if (_myRotation >= 360)//�p�x���Z�b�g�̉��g
            {
                _myRotation -= 360;
            }

            //�R�U�O�x�������烊�Z�b�g����d�g�ݕK�v����
        }
        if (PresenceRay)
        {
            print("�Ȃ��?");
            print(PresenceRay.collider.gameObject.name);//�e�X�g�p�ɖ��O���擾����
            TurnAngle();//���������I�u�W�F�N�g�̈ʒu�ɐU�����
        }

        if (hit1 || hit2 || hit3)
        {

        }

    }

    void VisionConvert()//�p�x�������ɕϊ����郁�\�b�h
    {
        _radians = _myRotation * Mathf.Deg2Rad;//�����̊p�x�������ɕϊ�
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radians���王���̌������擾
        float Hit2angle = _myRotation + _angleOffset * Mathf.Deg2Rad;
        Hit2Vec = new Vector2(Mathf.Cos(Hit2angle), Mathf.Sin(Hit2angle));
        float Hit3angle = _myRotation - _angleOffset * Mathf.Deg2Rad;
         Hit3Vec = new Vector2(Mathf.Cos(Hit3angle), Mathf.Sin(Hit3angle));
    }

    void TurnAngle()
    {
        float PresenceAngle = Mathf.Atan2(PresenceRay.collider.gameObject.transform.position.y, PresenceRay.collider.gameObject.transform.position.x) * Mathf.Rad2Deg;
        _myRotation = PresenceAngle;
        isPatrol = false;
    }

    void OnDrawGizmos()//PresenceRay������
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(VisionTrans.position, _rayRadius);
        
    }

  
}
