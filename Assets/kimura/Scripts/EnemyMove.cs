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
        MyTrans.Translate(GetVison.GetVisionVec * Time.deltaTime);//巡回させる
        //Vector2 currentPos = MyTrans.position;
        Vector2 movement = GetVison.GetVisionVec;
        _initialDistance = Vector2.Distance(_initialPosition, _myVector);
        _myVector = MyTrans.position;//自分の向きを取得
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
                }
                else
                {
                    EnemyAnimator.Play("leftwalk");
                    lastDirection = Vector2.left;
                }
            }
            // Y方向の移動を確認
            else
            {
                if (movement.y > 0)
                {
                    EnemyAnimator.Play("forwardwalk");
                    lastDirection = Vector2.up;
                }
                else
                {
                    EnemyAnimator.Play("Behindwalk");
                    lastDirection = Vector2.down;
                }
            }
        }
        else
        {
            // 移動がない場合、最後の移動方向に基づいて停止アニメーションを再生
            if (lastDirection == Vector2.right)
            {
                EnemyAnimator.Play("right");
            }
            else if (lastDirection == Vector2.left)
            {
                EnemyAnimator.Play("left");
            }
            else if (lastDirection == Vector2.up)
            {
                EnemyAnimator.Play("forward");
            }
            else if (lastDirection == Vector2.down)
            {
                EnemyAnimator.Play("Behind");
            }
        }

        //_myVector = currentPos;  // 現在の位置を更新



    }
    void SetDirection()
    {
        
    }

}
