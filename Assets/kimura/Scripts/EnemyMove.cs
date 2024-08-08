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
    public Transform GetMyTrans//MyTransのプロパティ
    {
        get { return MyTrans; }
        set { MyTrans = value; }
    }
    private Vector2 MyVector;
    private float _initialDistance;
    [Header("自分の初期位置")]
    private Vector2 InitialPosition;//自分の初期位置  
    public Vector2 GetInitialPos//InitialPositioのプロパティ
    {
        get { return InitialPosition; }
        set { InitialPosition = value; }
    }
    [Header("自分のスピード")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//自分のTransformを取得
        EnemyAnimator = this.GetComponent<Animator>();
        Agent2D=this.GetComponent<NavMeshAgent2D>();
        InitialPosition = MyTrans.position;//自分の初期位置を取得
        GetVison = GetComponent<EnemyVisionScript>();//子オブジェクトからEnemyVisionスクリプトを取得
        SetDirection();
        
    }

    // Update is called once per frame
    void Update()
    {
        _initialDistance = Vector2.Distance(InitialPosition, MyVector);
        MyVector = MyTrans.position;//自分の向きを取得
        if (GetVison.existIsPatrol)//警備中だったら
        {
            MyTrans.Translate(GetVison.GetVisonVec * Time.deltaTime);//巡回させる
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
