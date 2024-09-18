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
    private Vector2 _myVector;
    private float _initialDistance;
    private Vector2 lastDirection;  // 最後の移動方向を保存する変数
    [Header("自分の初期位置")]
    private Vector2 _initialPosition;//自分の初期位置  

    public Vector2 GetInitialPos//InitialPositionのプロパティ
    {
        get { return _initialPosition; }
        set { _initialPosition = value; }
    }
    [Header("自分のスピード")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//自分のTransformを取得
        EnemyAnimator = this.GetComponent<Animator>();
        Agent2D=this.GetComponent<NavMeshAgent2D>();
        _initialPosition = MyTrans.position;//自分の初期位置を取得
        GetVison = GetComponent<EnemyVisionScript>();//子オブジェクトからEnemyVisionスクリプトを取得
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        //Vector2 currentPos = MyTrans.position;
        Vector2 movement = GetVison.GetVisionVec;
        _initialDistance = Vector2.Distance(_initialPosition, _myVector);
        _myVector = MyTrans.position;//自分の向きを取得
        if (GetVison.existIsPatrol)
        {
            MyTrans.Translate(movement * Time.deltaTime);//巡回させる
        }
        // 移動があった場合、方向に応じてアニメーションを再生
        if (movement.magnitude > 0.1f)
        {
            // X方向の移動を確認
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    EnemyAnimator.Play("rightwalk");
                    lastDirection = Vector2.right;
                    EnemyAnimator.SetBool("rightwalk", true);
                    print("みぎあるきです");
                }
                else
                {
                    EnemyAnimator.Play("leftwalk");
                    lastDirection = Vector2.left;
                    EnemyAnimator.SetBool("leftwalk", true);
                    print("ひだりあるきです");
                }
            }
            // Y方向の移動を確認
            else
            {
                if (movement.y > 0)
                {
                    EnemyAnimator.Play("forwardwalk");
                    lastDirection = Vector2.up;
                    EnemyAnimator.SetBool("forwardwalk", true);
                    print("うえあるきです");
                }
                else
                {
                    EnemyAnimator.Play("Behindwalk");
                    lastDirection = Vector2.down;
                    EnemyAnimator.SetBool("Behindwalk", true);
                    print("したあるきです");
                }
            }
        }
        else
        {
            // 移動がない場合、最後の移動方向に基づいて停止アニメーションを再生
            if (lastDirection == Vector2.right)
            {
                EnemyAnimator.Play("right");
                print("みぎです");
            }
            else if (lastDirection == Vector2.left)
            {
                EnemyAnimator.Play("left");
                print("ひだりです");
            }
            else if (lastDirection == Vector2.up)
            {
                EnemyAnimator.Play("forward");
                print("うえです");
            }
            else if (lastDirection == Vector2.down)
            {
                EnemyAnimator.Play("Behind");
                print("したです");
            }
        }

        //_myVector = currentPos;  // 現在の位置を更新



    }
    void SetDirection()
    {
        
    }

}
