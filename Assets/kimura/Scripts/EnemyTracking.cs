using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
   
    //RaycastHit2D GetRay;//自分の視線
    private Vector2 _playerVec;//プレイヤーの位置を取得する
    private Vector2 _myVector;//自分の向き
    private Vector2 MoveDirection;
    private float _initialPosDistance;//初期位置と自分の距離
    private float _trakingTimeLimit = 10;
    private float _arertTimeLimit = 5;
   
    [SerializeField] GameObject _playerObj;
    [SerializeField] GameObject _lightObj;
    [Header("追跡時間")]
    [SerializeField] private float _trackingTime ;//追跡時間
    [Header("警戒時間")]
    [SerializeField] private float _alertTime;//警戒時間
    [Header("プレイヤーと自分の距離")]
    [SerializeField] private float _playerDistance;//プレイヤーと自分の距離 
    [Header("レイの距離  ")]
    [SerializeField] private float _rayDistance ;
    [Header("プレイヤーのレイヤー")]
    [SerializeField] private LayerMask _targetLayer;
    [Header("プレイヤーの位置")]
    private Transform _targetTrans;//プレイヤーの位置
    [Header("自分の追跡速度")]
    [SerializeField] private float _trackingSpeed = 5;//敵のスピード
    [Header("追跡フラグ")]
    [SerializeField] private bool _isTracking = false;//追跡フラグ
   
    NavMeshAgent GetAgent;
    public bool _existIsTracking
    {
        get { return _isTracking; }
        set { _isTracking = value; }
    }
    Transform _myTrans;//自分の位置
    EnemyMove _getMove;//自分の動きを取得する
    EnemyVisionScript _getEnemyVision;//自分の視線を取得
    NavMeshAgent2D _getAgent2D;
    void Start()
    {
        _targetTrans = GameObject.FindGameObjectWithTag("Player").transform;
        _getMove = this.GetComponent<EnemyMove>();//自分の動きを取得
        _getAgent2D = this.GetComponent<NavMeshAgent2D>();//自分のNavMeshAgent2Dを取得
        _myTrans = _getMove._getMyTrans;//自分のTransformを取得
        _getEnemyVision = GetComponent<EnemyVisionScript>();//子オブジェクトからEnemyVisionScriptを取得
        //GetAgent = this.GetComponent<NavMeshAgent>();
        //GetAgent.enabled = false;
        //GetAgent.updateRotation = false;
        //GetAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        //_rayAngle = MyTrans.eulerAngles.z * Mathf.Deg2Rad;
        _myVector = _getMove._getMyTrans.position;//自分の向きを取得
        //GetRay = Physics2D.Raycast(MyTrans.position, GetEnemyVision.GetVisonVec, _rayDistance, TargetLayer);//レイキャストを実行
      
        //Debug.DrawRay(_myTrans.position, _getEnemyVision._getVisionVec * _rayDistance, Color.red);//レイを可視化

        if (_getEnemyVision._getHit1)//プレイヤーがレイに触れたら
        {
            _isTracking = true;//追跡フラグをオンにする
            _trackingTime = _trakingTimeLimit;
            _alertTime = _arertTimeLimit;
        }

        else if (!_getEnemyVision._getHit1 && _isTracking)//レイにヒットしていないが、追いかけてる最中だったら
        {
            
            _trackingTime -= Time.deltaTime;          
        }


        if (_isTracking&&_trackingTime <= 0 ||_playerDistance >= 200)//プレイヤーを見失ったら  場合によってはorにする
        {
            TargetLost();
        }

        if (_isTracking&&!_playerObj.activeSelf&&_playerDistance>=5)//プレイヤーがロッカーに隠れた時のテスト
        {
            //print("非表示です");
            TargetLost();
        }

            if (_isTracking)//追跡フラグがオンだったら
        {           
            _playerDistance = Vector2.Distance(_playerVec, _myVector);//自分とプレイヤーの距離を計算
            _playerVec = _targetTrans.position;//プレイヤーの位置を取得
            _getAgent2D.SetDestination(_targetTrans.position);//プレイヤーを追い掛け回す
            _getEnemyVision._existIsPatrol = false;//警備をやめて追跡
            _getEnemyVision._existsIsStop = false;
                                                 //GetAgent2D.enabled = true;
            Vector2 direction = _targetTrans.position - _myTrans.position;//プレイヤーに視線を振り向かせる
            float _targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _getEnemyVision._getMyRotation = _targetAngle;
            //GetEnemyVision.GetVisonVec = (TargetTrans.position - MyTrans.position).normalized;
        }
    }
    /// <summary>
    /// <para>プレイヤーを見失った時のメソッド</para>
    /// </summary>
   //新しいメソッド書く
   void TargetLost()
    {
        _isTracking = false;
        _alertTime -= Time.deltaTime;

        if (_alertTime <= 0)//完全に見失ったら
        {
            OnDestinationReached();
            //GetAgent.SetDestination(GetMove.GetInitialPos);
            //_initialPosDistance = Vector2.Distance(MyVector, GetMove.GetInitialPos);
            //if (!GetAgent.pathPending&&GetAgent.remainingDistance<=GetAgent.stoppingDistance)//初期位置に戻ったら
            //{
            //    if (!GetAgent.hasPath || GetAgent.velocity.sqrMagnitude == 0f)
            //    {
            //        OnDestinationReached();//警備を再開させる
            //    }

            //}

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//プレイヤーと追突したら追跡開始
        {
            _isTracking = true;          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }

    void OnDestinationReached()
    {
        _getEnemyVision._existIsPatrol = true;//警備再開させる
        //GetAgent2D.enabled = false;
        //print(_getEnemyVision._existIsPatrol);
       
        //GetAgent.enabled = false;
    }

}
