using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    //EnemyTracking GetTracking;

    EnemyVisionScript GetVison;
    NavMeshAgent2D Agent2D;
    Animator EnemyAnimator;
    private Transform MyTrans;
    public Transform GetMyTrans//MyTrans�̃v���p�e�B
    {
        get { return MyTrans; }
        set { MyTrans = value; }
    }
    private Vector2 _myVector;
    private float _initialDistance;
    private Vector2 lastDirection;  // �Ō�̈ړ�������ۑ�����ϐ�
    [Header("�����̏����ʒu")]
    private Vector2 _initialPosition;//�����̏����ʒu  

    public Vector2 GetInitialPos//InitialPosition�̃v���p�e�B
    {
        get { return _initialPosition; }
        set { _initialPosition = value; }
    }
    [Header("�����̃X�s�[�h")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//������Transform���擾
        EnemyAnimator = this.GetComponent<Animator>();
        Agent2D=this.GetComponent<NavMeshAgent2D>();
        _initialPosition = MyTrans.position;//�����̏����ʒu���擾
        GetVison = GetComponent<EnemyVisionScript>();//�q�I�u�W�F�N�g����EnemyVision�X�N���v�g���擾
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        //Vector2 currentPos = MyTrans.position;
        Vector2 movement = GetVison.GetVisionVec;
        _initialDistance = Vector2.Distance(_initialPosition, _myVector);
        _myVector = MyTrans.position;//�����̌������擾
        if (GetVison.existIsPatrol)
        {
            MyTrans.Translate(movement * Time.deltaTime);//���񂳂���
        }
        // �ړ����������ꍇ�A�����ɉ����ăA�j���[�V�������Đ�
        if (movement.magnitude > 0.1f)
        {
            // X�����̈ړ����m�F
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    EnemyAnimator.Play("rightwalk");
                    lastDirection = Vector2.right;
                    EnemyAnimator.SetBool("rightwalk", true);
                    print("�݂����邫�ł�");
                }
                else
                {
                    EnemyAnimator.Play("leftwalk");
                    lastDirection = Vector2.left;
                    EnemyAnimator.SetBool("leftwalk", true);
                    print("�Ђ��肠�邫�ł�");
                }
            }
            // Y�����̈ړ����m�F
            else
            {
                if (movement.y > 0)
                {
                    EnemyAnimator.Play("forwardwalk");
                    lastDirection = Vector2.up;
                    EnemyAnimator.SetBool("forwardwalk", true);
                    print("�������邫�ł�");
                }
                else
                {
                    EnemyAnimator.Play("Behindwalk");
                    lastDirection = Vector2.down;
                    EnemyAnimator.SetBool("Behindwalk", true);
                    print("�������邫�ł�");
                }
            }
        }
        else
        {
            // �ړ����Ȃ��ꍇ�A�Ō�̈ړ������Ɋ�Â��Ē�~�A�j���[�V�������Đ�
            if (lastDirection == Vector2.right)
            {
                EnemyAnimator.Play("right");
                print("�݂��ł�");
            }
            else if (lastDirection == Vector2.left)
            {
                EnemyAnimator.Play("left");
                print("�Ђ���ł�");
            }
            else if (lastDirection == Vector2.up)
            {
                EnemyAnimator.Play("forward");
                print("�����ł�");
            }
            else if (lastDirection == Vector2.down)
            {
                EnemyAnimator.Play("Behind");
                print("�����ł�");
            }
        }

        //_myVector = currentPos;  // ���݂̈ʒu���X�V



    }
    void SetDirection()
    {
        
    }

}
