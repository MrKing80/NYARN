using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
   
    RaycastHit2D GetRay;//�����̎���
    private Vector2 PlayerVec;//�v���C���[�̈ʒu���擾����
    private Vector2 MyVector;//�����̌���
    private Vector2 MoveDirection;
    private float _initialPosDistance;//�����ʒu�Ǝ����̋���
    private float _rayAngle;
    [Header("�ǐՎ���")]
    [SerializeField] private float _trackingTime = 10;//�ǐՎ���
    [Header("�x������")]
    [SerializeField] private float _alertTime = 5;//�x������
    [Header("�v���C���[�Ǝ����̋���")]
    [SerializeField] private float _playerDistance;//�v���C���[�Ǝ����̋��� 
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("�v���C���[�̃��C���[")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("�v���C���[�̈ʒu")]
    [SerializeField] Transform TargetTrans;//�v���C���[�̈ʒu
    [Header("�����̒ǐՑ��x")]
    [SerializeField] private float _trackingSpeed = 5;//�G�̃X�s�[�h
    [Header("�ǐՃt���O")]
    [SerializeField] private bool isTracking = false;//�ǐՃt���O
    Transform MyTrans;//�����̈ʒu
    EnemyMove GetMove;//�����̓������擾����
    EnemyVisionScript GetEnemyVision;//�����̎������擾   
    NavMeshAgent2D GetAgent2D;
    void Start()
    {
       
        GetMove = this.GetComponent<EnemyMove>();//�����̓������擾
        GetAgent2D = this.GetComponent<NavMeshAgent2D>();//������NavMeshAgent2D���擾
        MyTrans = GetMove.GetMyTrans;//������Transform���擾
        GetEnemyVision = GetComponentInChildren<EnemyVisionScript>();//�q�I�u�W�F�N�g����EnemyVisionScript���擾
        //GetAgent = this.GetComponent<NavMeshAgent>();
        //GetAgent.updateRotation = false;
        //GetAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        //_rayAngle = MyTrans.eulerAngles.z * Mathf.Deg2Rad;
        MyVector = GetMove.GetMyTrans.position;//�����̌������擾
        GetRay = Physics2D.Raycast(MyTrans.position, GetEnemyVision.GetVisonVec, _rayDistance, TargetLayer);//���C�L���X�g�����s
      
        Debug.DrawRay(MyTrans.position, GetEnemyVision.GetVisonVec * _rayDistance, Color.red);//���C������

        if (GetRay)//�v���C���[�����C�ɐG�ꂽ��
        {
            isTracking = true;//�ǐՃt���O���I���ɂ���
            _trackingTime = 10;
            _alertTime = 5;
        }

        else if (!GetRay && isTracking)//���C�Ƀq�b�g���Ă��Ȃ����A�ǂ������Ă�Œ���������
        {
            print("�̂�����");
            _trackingTime -= Time.deltaTime;          
        }


        if (_trackingTime <= 0 &&_playerDistance >= 10)//�v���C���[������������  �ꍇ�ɂ���Ă�or�ɂ���
        {
            isTracking = false;          
            _alertTime -= Time.deltaTime;
            print("�ǂ��H");
            if (_alertTime <= 0)//���S�Ɍ���������
            {
                GetAgent2D.SetDestination(GetMove.GetInitialPos);
                _initialPosDistance = Vector2.Distance(MyVector, GetMove.GetInitialPos);
                if (MyVector==GetMove.GetInitialPos)//�����ʒu�ɖ߂�����
                {
                    GetEnemyVision.existIsPatrol = true;//�x���ĊJ������
                    print(GetEnemyVision.existIsPatrol);
                    print("�x���ĊJ");
                }
               
                print("���ꂽ");
            }
        }

        if (isTracking)//�ǐՃt���O���I����������
        {
            print("�݂������I�I");
            _playerDistance = Vector2.Distance(PlayerVec, MyVector);//�����ƃv���C���[�̋������v�Z
            PlayerVec = TargetTrans.position;//�v���C���[�̈ʒu���擾
            GetAgent2D.SetDestination(TargetTrans.position);//�v���C���[��ǂ��|����
            GetEnemyVision.existIsPatrol = false;//�x������߂Ēǐ�
            GetEnemyVision.GetVisonVec = (TargetTrans.position - MyTrans.position).normalized;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//�v���C���[�ƒǓ˂�����ǐՊJ�n
        {
            isTracking = true;          
        }
    }
}
