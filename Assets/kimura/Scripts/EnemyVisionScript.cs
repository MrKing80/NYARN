using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public enum MoveDirection//�ړ����������߂�Ƃ��̒萔
    {
        Up,
        Down,
        Left,
        Right
    }
    public enum ChangeAngle//��Q���ɏՓ˂����ۂǂꂭ�炢�p�x��ς��邩���߂�Ƃ��̒萔
    {
        Angle90 = 90,
        Angle180 = 180,
        Angle270 = 270
    }
    [Header("���񎞂̈ړ�����")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;//�f�t�H���g�͉E����
    [Header("�Փˎ��̊p�x����")]
    [SerializeField] private ChangeAngle _getAngle = ChangeAngle.Angle90;//�f�t�H���g�͂X�O�x��]������
    [Header("��Q���̃��C���[")]
    [SerializeField] private LayerMask _obstacleLayer;
    [Header("�v���C���[�̃��C���[")]
    [SerializeField] private LayerMask _targetLayer;
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("���C�̔��a")]
    [SerializeField] private float _rayRadius = 1f;
    [SerializeField] private float _maxDistance = 10f;
    [Header("�����~�܂鎞��")]
    [SerializeField] private float _stopTime = 5f;
    [SerializeField] private  float _initialValue = 5f;//�ėp�̏����l�i�e�X�g�p�j
    private float _currentDistance;
    public Vector2 _getVisionVec//VisionVec�̃v���p�e�B
    {
        get { return _visionVec; }
        set { _visionVec = value; }
    }
    private Transform _visionTrans;//�����̈ʒu
    [Header("��~���邩���䂷��")]
    [SerializeField] private bool _isStop = false;//��~�����邽�߂̃t���O
    public bool _existsIsStop
    {
        get { return _isStop; }
        set { _isStop = value; }
    }
    [Header("���񂳂��邩���䂷��")]
    [SerializeField] private bool _isPatrol = true;//�p�g���[�������ǂ������䂷��
    public bool _existIsPatrol//isPatrol�̃v���p�e�B
    {
        get { return _isPatrol; }
        set { _isPatrol = value; }
    }
    
    private float _myRotation;//�����̊p�x 
    public float _getMyRotation//_myRotation�̃v���p�e�B
    {
        get { return _myRotation; }
        set { _myRotation = value; }
    }
    private float _radians;//�p�x�������ɕϊ����邽�߂̕ϐ�
    private float _angleOffset = 15f;//hit2,hit3�̊p�x���߂Ɏg���ϐ�
    private float _currentRotation = default;//myRotation�̒l���擾���邽�߂̕ϐ�
    private float _turnAroundTime = 0.5f;
    private float _turnAroundTimeValue = 0.5f;
    private float _presenceAngle;//�Փˎ��ɐU��������邽�߂̕ϐ�
    private Vector2 _visionVec;//�����̌���
    private Vector2 Hit2Vec;
    private Vector2 Hit3Vec;
    RaycastHit2D _obstacleRay;//��Q�����������鎋��
    RaycastHit2D _presenceRay;//���p�ł��v���C���[���@�m�ł���悤�ɂ��鋅��̃��C
    RaycastHit2D hit1;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    public RaycastHit2D GetHit1
    {
        get { return hit1;}
    }
    public RaycastHit2D GetHit2
    {
        get { return hit2; }
    }

    public RaycastHit2D GetHit3
    {
        get { return hit3; }
    }
    EnemyTracking GetTracking;
    // Start is called before the first frame update
    void Start()
    {               
        _visionTrans = this.GetComponent<Transform>();
        GetTracking = GetComponent<EnemyTracking>();
        //_currentDistance = _rayDistance;
        _myRotation = _visionTrans.rotation.z;//�p�x���擾
        if (_isPatrol)//�x������������EnemyMove�X�N���v�g�ňړ�������
        {
            switch (_direction)//�ŏ��Ɉړ��������
            {
                case MoveDirection.Up:
                    _myRotation = 90;
                    break;
                case MoveDirection.Down:
                    _myRotation = 270;
                    break;
                case MoveDirection.Right:
                    _myRotation = 0;
                    break;
                case MoveDirection.Left:
                    _myRotation = 180;
                    break;
            }
        }
        _currentRotation = _myRotation;//myRotation�̒l���擾
    }

    // Update is called once per frame
    void Update()
    {
        VisionConvert();
        hit1 = Physics2D.Raycast(_visionTrans.position, _visionVec, _rayDistance, _targetLayer);//���ʂ̃��C
        //hit2 = Physics2D.Raycast(VisionTrans.position, Hit2Vec, _rayDistance, TargetLayer);
        //hit3 = Physics2D.Raycast(VisionTrans.position, Hit3Vec, _rayDistance, TargetLayer);
        Debug.DrawRay(_visionTrans.position, _visionVec * _rayDistance, Color.red);
        //Debug.DrawRay(VisionTrans.position, Hit2Vec * _rayDistance, Color.blue);
        //Debug.DrawRay(VisionTrans.position, Hit3Vec * _rayDistance, Color.green);
        _obstacleRay = Physics2D.Raycast(_visionTrans.position, _visionVec, _rayDistance, _obstacleLayer);//��Q�����������郌�C
        _presenceRay = Physics2D.CircleCast(_visionTrans.position, _rayRadius, _visionVec, _maxDistance, _targetLayer);//���p�ł��v���C���[�@�m�ł���悤�ɂ��郌�C
        //int _turnCount = default;
        if (_myRotation >= 360 && _isPatrol)//360�x��������p�x���Z�b�g
        {
            
            _myRotation -= 360;
            
            //print(_currentRotation);
        }
        else if (_myRotation < 0)
        {
           
            _myRotation += 360;
            
        }

        if (_isPatrol && _obstacleRay.collider != null && _obstacleRay.collider.gameObject != this.gameObject)//���񎞁A��Q���ɓ���������
        {
            
            _myRotation += (int)_getAngle;//������GetAngle�Ŏw�肵���p�x�ɌX������ �@
            if (_myRotation >= 360 && _isPatrol)//360�x��������p�x���Z�b�g
            {

                _myRotation -= 360;
                _currentRotation = _myRotation;//�ēxmyRotation�̒l���擾
                                               //print(_currentRotation);
            }
            else if (_myRotation < 0)
            {

                _myRotation += 360;
                _currentRotation = _myRotation;
            }
            //print(_myRotation);
        }

        if (_presenceRay&&!GetTracking._existIsTracking)//���G�͈͂Ƀv���C���[���Փ˂�����
        {
            
            //print(PresenceRay.collider.gameObject.name);//�e�X�g�p�ɖ��O���擾����
            _isPatrol = false;//�������߂�
            _isStop = true;//�����~�܂�
            //print(_myRotation);
                          //if (_turnCount == 1)
                          //{

            //    _turnCount++;

            //}
            if (_isStop == false)
            {
                _stopTime = _initialValue;
                _turnAroundTime = _turnAroundTimeValue;
            }
           

            _presenceAngle = Mathf.Atan2(_presenceRay.collider.transform.position.y, _presenceRay.collider.transform.position.x) * Mathf.Rad2Deg;//�Փ˂����I�u�W�F�N�g�̍��W���擾
            
        }
        else
        {
            //_turnCount = default;
        }

        if (_isStop)//�~�܂�����
        {
            
            _stopTime -= Time.deltaTime;//�����~�܂鎞�Ԃ��J�E���g�_�E��
            _turnAroundTime -= Time.deltaTime;//�U������܂ł̎��Ԃ��J�E���g�_�E��
            if (_turnAroundTime <= 0)//��莞�ԗ����~�܂�����
            {
                TurnAngle();//�v���C���[�����E���ɂ����ʒu�ɐU�����
               
            }
            if (_stopTime <= 0)//�O�b�ɂȂ�����i�U������O�Ƀv���C���[���ړ�������)
            {        
                _myRotation = _currentRotation;//_myRotation�����񂵂Ă������̊p�x�ɂ��ǂ�
                _isPatrol = true;//�Ăя��񂳂���
                _isStop = false;
                _stopTime = _initialValue;//�����l�ɖ߂�
                _turnAroundTime = _turnAroundTimeValue;//������}�W�b�N�i���o�[����
            }
        }
    }

    /// <summary>
    ///  �p�x�������ɕϊ����郁�\�b�h
    /// </summary>
    void VisionConvert()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//�����̊p�x�������ɕϊ�
        _visionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radians���王���̌������擾
        //float Hit2Angle = _myRotation + _angleOffset * Mathf.Deg2Rad;
        //Hit2Vec = new Vector2(Mathf.Cos(Hit2Angle), Mathf.Sin(Hit2Angle));
        //float Hit3Angle = _myRotation - _angleOffset * Mathf.Deg2Rad;
        //Hit3Vec = new Vector2(Mathf.Cos(Hit3Angle), Mathf.Sin(Hit3Angle));
    }

    /// <summary>
    ///  �w�肵���p�x�ɐU��������郁�\�b�h
    /// </summary>
    void TurnAngle()
    {
        _presenceAngle = Mathf.Atan2(_presenceRay.point.y, _presenceRay.point.x) * Mathf.Rad2Deg;//�Փ˂����I�u�W�F�N�g�̍��W���擾
        _myRotation = _presenceAngle;//PresenceAngle�̒l���擾���Ă��̒l�̌����ɍ��킹��
    }

    void OnDrawGizmos()//PresenceRay������
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(_visionTrans.position, _rayRadius);
    }

}
