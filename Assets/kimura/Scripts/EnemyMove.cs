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
    [SerializeField] GameObject[] _patrolPoint;
    Vector2 _patrolPos;
    private Transform _myTrans;
    public Transform _getMyTrans//MyTransのプロパティ
    {
        get { return _myTrans; }
        set { _myTrans = value; }
    }
    private Vector2 _myVector;
    private int _patrolPointNumber = 1;
    private float _distanceThreshold = 0.1f; // 目的地に到達したと見なす距離の閾値
    private Vector2 _lastDirection;  // 最後の移動方向を保存する変数
    [Header("自分の初期位置")]
    private Vector2 _initialPosition;//自分の初期位置  

    public Vector2 _getInitialPos//InitialPositionのプロパティ
    {
        get { return _initialPosition; }
        set { _initialPosition = value; }
    }
    [Header("自分のスピード")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //配列で目的地を設定してAIで巡回させればいいじゃないか？
        //GetTracking = this.GetComponent<EnemyTracking>();
        _myTrans = this.GetComponent<Transform>();//自分のTransformを取得
        _enemyAnimator = this.GetComponent<Animator>();
        _agent2D=this.GetComponent<NavMeshAgent2D>();
        _initialPosition = _myTrans.position;//自分の初期位置を取得
        _getVison = GetComponent<EnemyVisionScript>();//子オブジェクトからEnemyVisionスクリプトを取得
        _getTracking = GetComponent<EnemyTracking>();
        _patrolPos = _patrolPoint[_patrolPointNumber].transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        //Vector2 currentPos = MyTrans.position;
        Vector2 movement = _getVison._getVisionVec;
        _myVector = _myTrans.position;//自分の向きを取得
        if (_getVison._existIsPatrol)//巡回中だったら
        {

            Vector2 direction = _patrolPos - _myVector;
            float _targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _getVison._getMyRotation = _targetAngle;
            _agent2D.SetDestination(_patrolPos);
            if (Vector2.Distance(_myTrans.position, _patrolPos) <= _distanceThreshold)//目的地に着いたら
            {
                SetDirection();               
            }
        }
        // 移動があった場合、方向に応じてアニメーションを再生
        if (movement.magnitude > 0.1f||_getTracking._existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", true);
           
            // X方向の移動を確認
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0 || _getVison._getMyRotation<=45&& _getVison._getMyRotation >= 315)
                {
                    _enemyAnimator.Play("rightwalk");
                    _lastDirection = Vector2.right;
                    _enemyAnimator.SetTrigger("rightwalk");
                    //EnemyAnimator.SetBool("rightwalk", true);
                    //print("みぎあるきです");
                }
                else if (movement.x<0||_getVison._getMyRotation <= 225 && _getVison._getMyRotation >= 135)
                {
                    _enemyAnimator.Play("leftwalk");
                    _lastDirection = Vector2.left;
                    _enemyAnimator.SetTrigger("leftwalk");
                    //EnemyAnimator.SetBool("leftwalk", true);
                    //print("ひだりあるきです");
                }
            }
            // Y方向の移動を確認
            else
            {
                if (movement.y > 0|| _getVison._getMyRotation <= 135 && _getVison._getMyRotation >= 45)
                {
                    _enemyAnimator.Play("forwardwalk");
                    _lastDirection = Vector2.up;
                    _enemyAnimator.SetTrigger("forwardwalk");
                    //EnemyAnimator.SetBool("forwardwalk", true);
                    //print("うえあるきです");
                }
                else if(movement.y<0||_getVison._getMyRotation <= 315 && _getVison._getMyRotation >= 225)
                {
                    _enemyAnimator.Play("Behindwalk");
                    _lastDirection = Vector2.down;
                    _enemyAnimator.SetTrigger("Behindwalk");
                    //EnemyAnimator.SetBool("Behindwalk", true);
                    //print("したあるきです");
                }
            }
        }

        if(!_getVison._existIsPatrol&&!_getTracking._existIsTracking)
        {
            //EnemyAnimator.SetBool("isMoving", false);
            
            // 移動がない場合、最後の移動方向に基づいて停止アニメーションを再生
            if (_lastDirection == Vector2.right)
            {
                _enemyAnimator.Play("right");
                _enemyAnimator.SetTrigger("right");
                //print("みぎです");
            }
            else if (_lastDirection == Vector2.left)
            {
                _enemyAnimator.Play("left");
                _enemyAnimator.SetTrigger("left");
                //print("ひだりです");
            }
            else if (_lastDirection == Vector2.up)
            {
                _enemyAnimator.Play("forward");
                _enemyAnimator.SetTrigger("forward");
                //print("うえです");
            }
            else if (_lastDirection == Vector2.down)
            {
                _enemyAnimator.Play("Behind");
                _enemyAnimator.SetTrigger("Behind");
                //print("したです");
            }
        }


    }
    void SetDirection()
    {
        print(_patrolPointNumber);
        _patrolPointNumber++;
        if (_patrolPointNumber>=_patrolPoint.Length)//もしも要素数を超えたら
        {
            _patrolPointNumber = default;//０に戻す
        }
        _patrolPos = _patrolPoint[_patrolPointNumber].transform.position;
    }

}
