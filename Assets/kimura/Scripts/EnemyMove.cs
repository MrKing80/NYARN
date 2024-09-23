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
        GetTracking = GetComponent<EnemyTracking>();
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
            MyTrans.Translate(movement * _moveSpeed * Time.deltaTime);//巡回させる
        }
        // 移動があった場合、方向に応じてアニメーションを再生
        if (movement.magnitude > 0.1f||GetTracking.existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", true);
           
            // X方向の移動を確認
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0 || GetVison.GetMyRotation<=45&& GetVison.GetMyRotation >= 315)
                {
                    EnemyAnimator.Play("rightwalk");
                    lastDirection = Vector2.right;
                    EnemyAnimator.SetTrigger("rightwalk");
                    //EnemyAnimator.SetBool("rightwalk", true);
                    //print("みぎあるきです");
                }
                else if (movement.x<0||GetVison.GetMyRotation <= 225 && GetVison.GetMyRotation >= 135)
                {
                    EnemyAnimator.Play("leftwalk");
                    lastDirection = Vector2.left;
                    EnemyAnimator.SetTrigger("leftwalk");
                    //EnemyAnimator.SetBool("leftwalk", true);
                    //print("ひだりあるきです");
                }
            }
            // Y方向の移動を確認
            else
            {
                if (movement.y > 0|| GetVison.GetMyRotation <= 135 && GetVison.GetMyRotation >= 45)
                {
                    EnemyAnimator.Play("forwardwalk");
                    lastDirection = Vector2.up;
                    EnemyAnimator.SetTrigger("forwardwalk");
                    //EnemyAnimator.SetBool("forwardwalk", true);
                    //print("うえあるきです");
                }
                else if(movement.y<0||GetVison.GetMyRotation <= 315 && GetVison.GetMyRotation >= 225)
                {
                    EnemyAnimator.Play("Behindwalk");
                    lastDirection = Vector2.down;
                    EnemyAnimator.SetTrigger("Behindwalk");
                    //EnemyAnimator.SetBool("Behindwalk", true);
                    //print("したあるきです");
                }
            }
        }

        if(!GetVison.existIsPatrol&&!GetTracking.existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", false);
            
            // 移動がない場合、最後の移動方向に基づいて停止アニメーションを再生
            if (lastDirection == Vector2.right)
            {
                EnemyAnimator.Play("right");
                EnemyAnimator.SetTrigger("right");
                //print("みぎです");
            }
            else if (lastDirection == Vector2.left)
            {
                EnemyAnimator.Play("left");
                EnemyAnimator.SetTrigger("left");
                //print("ひだりです");
            }
            else if (lastDirection == Vector2.up)
            {
                EnemyAnimator.Play("forward");
                EnemyAnimator.SetTrigger("forward");
                //print("うえです");
            }
            else if (lastDirection == Vector2.down)
            {
                EnemyAnimator.Play("Behind");
                EnemyAnimator.SetTrigger("Behind");
                //print("したです");
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

        //_myVector = currentPos;  // 現在の位置を更新

        

    }
    void SetDirection()
    {
        
    }

}
