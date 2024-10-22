using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    //EnemyTracking GetTracking;

    EnemyVisionScript _getVison;
    EnemyTracking _getTracking;
    NavMeshAgent2D _agent2D;
    Animator _enemyAnimator;
    private Transform _myTrans;
    public Transform _getMyTrans//MyTrans�̃v���p�e�B
    {
        get { return _myTrans; }
        set { _myTrans = value; }
    }
    private Vector2 _myVector;
    private float _initialDistance;
    private Vector2 _lastDirection;  // �Ō�̈ړ�������ۑ�����ϐ�
    [Header("�����̏����ʒu")]
    private Vector2 _initialPosition;//�����̏����ʒu  

    public Vector2 _getInitialPos//InitialPosition�̃v���p�e�B
    {
        get { return _initialPosition; }
        set { _initialPosition = value; }
    }
    [Header("�����̃X�s�[�h")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        _myTrans = this.GetComponent<Transform>();//������Transform���擾
        _enemyAnimator = this.GetComponent<Animator>();
        _agent2D=this.GetComponent<NavMeshAgent2D>();
        _initialPosition = _myTrans.position;//�����̏����ʒu���擾
        _getVison = GetComponent<EnemyVisionScript>();//�q�I�u�W�F�N�g����EnemyVision�X�N���v�g���擾
        _getTracking = GetComponent<EnemyTracking>();
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        //Vector2 currentPos = MyTrans.position;
        Vector2 movement = _getVison._getVisionVec;
        _initialDistance = Vector2.Distance(_initialPosition, _myVector);
        _myVector = _myTrans.position;//�����̌������擾
        if (_getVison._existIsPatrol)
        {
            _myTrans.Translate(movement * _moveSpeed * Time.deltaTime);//���񂳂���
        }
        // �ړ����������ꍇ�A�����ɉ����ăA�j���[�V�������Đ�
        if (movement.magnitude > 0.1f||_getTracking._existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", true);
           
            // X�����̈ړ����m�F
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0 || _getVison._getMyRotation<=45&& _getVison._getMyRotation >= 315)
                {
                    _enemyAnimator.Play("rightwalk");
                    _lastDirection = Vector2.right;
                    _enemyAnimator.SetTrigger("rightwalk");
                    //EnemyAnimator.SetBool("rightwalk", true);
                    //print("�݂����邫�ł�");
                }
                else if (movement.x<0||_getVison._getMyRotation <= 225 && _getVison._getMyRotation >= 135)
                {
                    _enemyAnimator.Play("leftwalk");
                    _lastDirection = Vector2.left;
                    _enemyAnimator.SetTrigger("leftwalk");
                    //EnemyAnimator.SetBool("leftwalk", true);
                    //print("�Ђ��肠�邫�ł�");
                }
            }
            // Y�����̈ړ����m�F
            else
            {
                if (movement.y > 0|| _getVison._getMyRotation <= 135 && _getVison._getMyRotation >= 45)
                {
                    _enemyAnimator.Play("forwardwalk");
                    _lastDirection = Vector2.up;
                    _enemyAnimator.SetTrigger("forwardwalk");
                    //EnemyAnimator.SetBool("forwardwalk", true);
                    //print("�������邫�ł�");
                }
                else if(movement.y<0||_getVison._getMyRotation <= 315 && _getVison._getMyRotation >= 225)
                {
                    _enemyAnimator.Play("Behindwalk");
                    _lastDirection = Vector2.down;
                    _enemyAnimator.SetTrigger("Behindwalk");
                    //EnemyAnimator.SetBool("Behindwalk", true);
                    //print("�������邫�ł�");
                }
            }
        }

        if(!_getVison._existIsPatrol&&!_getTracking._existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", false);
            
            // �ړ����Ȃ��ꍇ�A�Ō�̈ړ������Ɋ�Â��Ē�~�A�j���[�V�������Đ�
            if (_lastDirection == Vector2.right)
            {
                _enemyAnimator.Play("right");
                _enemyAnimator.SetTrigger("right");
                //print("�݂��ł�");
            }
            else if (_lastDirection == Vector2.left)
            {
                _enemyAnimator.Play("left");
                _enemyAnimator.SetTrigger("left");
                //print("�Ђ���ł�");
            }
            else if (_lastDirection == Vector2.up)
            {
                _enemyAnimator.Play("forward");
                _enemyAnimator.SetTrigger("forward");
                //print("�����ł�");
            }
            else if (_lastDirection == Vector2.down)
            {
                _enemyAnimator.Play("Behind");
                _enemyAnimator.SetTrigger("Behind");
                //print("�����ł�");
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)&&_getVison._existIsPatrol==true)
        {
            _getVison._existIsPatrol = false;
        }
        else if(Input.GetKeyDown(KeyCode.Return) && _getVison._existIsPatrol == false)
        {
            _getVison._existIsPatrol = true;
        }

        //_myVector = currentPos;  // ���݂̈ʒu���X�V

        

    }
    void SetDirection()
    {
        
    }

}
