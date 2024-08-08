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
    private Vector2 MyVector;
    private float _initialDistance;
    [Header("�����̏����ʒu")]
    private Vector2 InitialPosition;//�����̏����ʒu  
    public Vector2 GetInitialPos//InitialPositio�̃v���p�e�B
    {
        get { return InitialPosition; }
        set { InitialPosition = value; }
    }
    [Header("�����̃X�s�[�h")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//������Transform���擾
        EnemyAnimator = this.GetComponent<Animator>();
        Agent2D=this.GetComponent<NavMeshAgent2D>();
        InitialPosition = MyTrans.position;//�����̏����ʒu���擾
        GetVison = GetComponent<EnemyVisionScript>();//�q�I�u�W�F�N�g����EnemyVision�X�N���v�g���擾
        SetDirection();
        
    }

    // Update is called once per frame
    void Update()
    {
        _initialDistance = Vector2.Distance(InitialPosition, MyVector);
        MyVector = MyTrans.position;//�����̌������擾
        if (GetVison.existIsPatrol)//�x������������
        {
            MyTrans.Translate(GetVison.GetVisonVec * Time.deltaTime);//���񂳂���
            switch (GetVison.GetMyRotation)
            {

                case 90:
                    EnemyAnimator.Play("Behindwalk");
                    break;
                case 270:
                    EnemyAnimator.Play("forwardwalk");
                    break;
                case 0:
                    EnemyAnimator.Play("rightwalk");
                    break;
                case 180:
                    EnemyAnimator.Play("leftwalk");
                    break;

            }
        }

        else
        {
            switch (GetVison.GetMyRotation)
            {

                case 90:
                    EnemyAnimator.Play("Behind");
                    break;
                case 270:
                    EnemyAnimator.Play("forward");
                    break;
                case 0:
                    EnemyAnimator.Play("right");
                    break;
                case 180:
                    EnemyAnimator.Play("left");
                    break;
            }
        }

       
      
    }
    void SetDirection()
    {
        
    }

}
