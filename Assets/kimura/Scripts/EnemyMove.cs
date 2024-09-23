using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    //EnemyTracking GetTracking;

    EnemyVisionScript GetVison;
    EnemyTracking GetTracking;
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
        GetTracking = GetComponent<EnemyTracking>();
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
            MyTrans.Translate(movement * _moveSpeed * Time.deltaTime);//���񂳂���
        }
        // �ړ����������ꍇ�A�����ɉ����ăA�j���[�V�������Đ�
        if (movement.magnitude > 0.1f||GetTracking.existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", true);
           
            // X�����̈ړ����m�F
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0 || GetVison.GetMyRotation<=45&& GetVison.GetMyRotation >= 315)
                {
                    EnemyAnimator.Play("rightwalk");
                    lastDirection = Vector2.right;
                    EnemyAnimator.SetTrigger("rightwalk");
                    //EnemyAnimator.SetBool("rightwalk", true);
                    //print("�݂����邫�ł�");
                }
                else if (movement.x<0||GetVison.GetMyRotation <= 225 && GetVison.GetMyRotation >= 135)
                {
                    EnemyAnimator.Play("leftwalk");
                    lastDirection = Vector2.left;
                    EnemyAnimator.SetTrigger("leftwalk");
                    //EnemyAnimator.SetBool("leftwalk", true);
                    //print("�Ђ��肠�邫�ł�");
                }
            }
            // Y�����̈ړ����m�F
            else
            {
                if (movement.y > 0|| GetVison.GetMyRotation <= 135 && GetVison.GetMyRotation >= 45)
                {
                    EnemyAnimator.Play("forwardwalk");
                    lastDirection = Vector2.up;
                    EnemyAnimator.SetTrigger("forwardwalk");
                    //EnemyAnimator.SetBool("forwardwalk", true);
                    //print("�������邫�ł�");
                }
                else if(movement.y<0||GetVison.GetMyRotation <= 315 && GetVison.GetMyRotation >= 225)
                {
                    EnemyAnimator.Play("Behindwalk");
                    lastDirection = Vector2.down;
                    EnemyAnimator.SetTrigger("Behindwalk");
                    //EnemyAnimator.SetBool("Behindwalk", true);
                    //print("�������邫�ł�");
                }
            }
        }

        if(!GetVison.existIsPatrol&&!GetTracking.existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", false);
            
            // �ړ����Ȃ��ꍇ�A�Ō�̈ړ������Ɋ�Â��Ē�~�A�j���[�V�������Đ�
            if (lastDirection == Vector2.right)
            {
                EnemyAnimator.Play("right");
                EnemyAnimator.SetTrigger("right");
                //print("�݂��ł�");
            }
            else if (lastDirection == Vector2.left)
            {
                EnemyAnimator.Play("left");
                EnemyAnimator.SetTrigger("left");
                //print("�Ђ���ł�");
            }
            else if (lastDirection == Vector2.up)
            {
                EnemyAnimator.Play("forward");
                EnemyAnimator.SetTrigger("forward");
                //print("�����ł�");
            }
            else if (lastDirection == Vector2.down)
            {
                EnemyAnimator.Play("Behind");
                EnemyAnimator.SetTrigger("Behind");
                //print("�����ł�");
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)&&GetVison.existIsPatrol==true)
        {
            GetVison.existIsPatrol = false;
        }
        else if(Input.GetKeyDown(KeyCode.Return) && GetVison.existIsPatrol == false)
        {
            GetVison.existIsPatrol = true;
        }

        //_myVector = currentPos;  // ���݂̈ʒu���X�V

        

    }
    void SetDirection()
    {
        
    }

}
