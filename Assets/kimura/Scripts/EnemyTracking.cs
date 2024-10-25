using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
   
    //RaycastHit2D GetRay;//�����̎���
    private Vector2 _playerVec;//�v���C���[�̈ʒu���擾����
    private Vector2 _myVector;//�����̌���
    private Vector2 MoveDirection;
    private float _initialPosDistance;//�����ʒu�Ǝ����̋���
    private float _trakingTimeLimit = 10;
    private float _arertTimeLimit = 5;
   
    [SerializeField] GameObject _playerObj;
    [SerializeField] GameObject _lightObj;
    [Header("�ǐՎ���")]
    [SerializeField] private float _trackingTime ;//�ǐՎ���
    [Header("�x������")]
    [SerializeField] private float _alertTime;//�x������
    [Header("�v���C���[�Ǝ����̋���")]
    [SerializeField] private float _playerDistance;//�v���C���[�Ǝ����̋��� 
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance ;
    [Header("�v���C���[�̃��C���[")]
    [SerializeField] private LayerMask _targetLayer;
    [Header("�v���C���[�̈ʒu")]
    private Transform _targetTrans;//�v���C���[�̈ʒu
    [Header("�����̒ǐՑ��x")]
    [SerializeField] private float _trackingSpeed = 5;//�G�̃X�s�[�h
    [Header("�ǐՃt���O")]
    [SerializeField] private bool _isTracking = false;//�ǐՃt���O
   
    NavMeshAgent GetAgent;
    public bool _existIsTracking
    {
        get { return _isTracking; }
        set { _isTracking = value; }
    }
    Transform _myTrans;//�����̈ʒu
    EnemyMove _getMove;//�����̓������擾����
    EnemyVisionScript _getEnemyVision;//�����̎������擾
    NavMeshAgent2D _getAgent2D;
    void Start()
    {
        _targetTrans = GameObject.FindGameObjectWithTag("Player").transform;
        _getMove = this.GetComponent<EnemyMove>();//�����̓������擾
        _getAgent2D = this.GetComponent<NavMeshAgent2D>();//������NavMeshAgent2D���擾
        _myTrans = _getMove._getMyTrans;//������Transform���擾
        _getEnemyVision = GetComponent<EnemyVisionScript>();//�q�I�u�W�F�N�g����EnemyVisionScript���擾
        //GetAgent = this.GetComponent<NavMeshAgent>();
        //GetAgent.enabled = false;
        //GetAgent.updateRotation = false;
        //GetAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        //_rayAngle = MyTrans.eulerAngles.z * Mathf.Deg2Rad;
        _myVector = _getMove._getMyTrans.position;//�����̌������擾
        //GetRay = Physics2D.Raycast(MyTrans.position, GetEnemyVision.GetVisonVec, _rayDistance, TargetLayer);//���C�L���X�g�����s
      
        //Debug.DrawRay(_myTrans.position, _getEnemyVision._getVisionVec * _rayDistance, Color.red);//���C������

        if (_getEnemyVision._getHit1)//�v���C���[�����C�ɐG�ꂽ��
        {
            _isTracking = true;//�ǐՃt���O���I���ɂ���
            _trackingTime = _trakingTimeLimit;
            _alertTime = _arertTimeLimit;
        }

        else if (!_getEnemyVision._getHit1 && _isTracking)//���C�Ƀq�b�g���Ă��Ȃ����A�ǂ������Ă�Œ���������
        {
            
            _trackingTime -= Time.deltaTime;          
        }


        if (_isTracking&&_trackingTime <= 0 ||_playerDistance >= 200)//�v���C���[������������  �ꍇ�ɂ���Ă�or�ɂ���
        {
            TargetLost();
        }

        if (_isTracking&&!_playerObj.activeSelf&&_playerDistance>=5)//�v���C���[�����b�J�[�ɉB�ꂽ���̃e�X�g
        {
            //print("��\���ł�");
            TargetLost();
        }

            if (_isTracking)//�ǐՃt���O���I����������
        {           
            _playerDistance = Vector2.Distance(_playerVec, _myVector);//�����ƃv���C���[�̋������v�Z
            _playerVec = _targetTrans.position;//�v���C���[�̈ʒu���擾
            _getAgent2D.SetDestination(_targetTrans.position);//�v���C���[��ǂ��|����
            _getEnemyVision._existIsPatrol = false;//�x������߂Ēǐ�
            _getEnemyVision._existsIsStop = false;
                                                 //GetAgent2D.enabled = true;
            Vector2 direction = _targetTrans.position - _myTrans.position;//�v���C���[�Ɏ�����U���������
            float _targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _getEnemyVision._getMyRotation = _targetAngle;
            //GetEnemyVision.GetVisonVec = (TargetTrans.position - MyTrans.position).normalized;
        }
    }
    /// <summary>
    /// <para>�v���C���[�������������̃��\�b�h</para>
    /// </summary>
   //�V�������\�b�h����
   void TargetLost()
    {
        _isTracking = false;
        _alertTime -= Time.deltaTime;

        if (_alertTime <= 0)//���S�Ɍ���������
        {
            OnDestinationReached();
            //GetAgent.SetDestination(GetMove.GetInitialPos);
            //_initialPosDistance = Vector2.Distance(MyVector, GetMove.GetInitialPos);
            //if (!GetAgent.pathPending&&GetAgent.remainingDistance<=GetAgent.stoppingDistance)//�����ʒu�ɖ߂�����
            //{
            //    if (!GetAgent.hasPath || GetAgent.velocity.sqrMagnitude == 0f)
            //    {
            //        OnDestinationReached();//�x�����ĊJ������
            //    }

            //}

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//�v���C���[�ƒǓ˂�����ǐՊJ�n
        {
            _isTracking = true;          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }

    void OnDestinationReached()
    {
        _getEnemyVision._existIsPatrol = true;//�x���ĊJ������
        //GetAgent2D.enabled = false;
        //print(_getEnemyVision._existIsPatrol);
       
        //GetAgent.enabled = false;
    }

}
