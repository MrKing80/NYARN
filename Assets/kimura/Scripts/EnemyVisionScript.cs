using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public enum MoveDirection//移動方向を決めるときの定数
    {
        Up,
        Down,
        Left,
        Right
    }
    public enum ChangeAngle//障害物に衝突した際どれくらい角度を変えるか決めるときの定数
    {
        Angle90 = 90,
        Angle180 = 180,
        Angle270 = 270
    }
    [Header("巡回時の移動方向")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;//デフォルトは右向き
    [Header("衝突時の角度調節")]
    [SerializeField] private ChangeAngle _getAngle = ChangeAngle.Angle90;//デフォルトは９０度回転させる
    [Header("障害物のレイヤー")]
    [SerializeField] private LayerMask _obstacleLayer;
    [Header("プレイヤーのレイヤー")]
    [SerializeField] private LayerMask _targetLayer;
    [Header("レイの距離  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("レイの半径")]
    [SerializeField] private float _rayRadius = 1f;
    [SerializeField] private float _maxDistance = 10f;
    [Header("立ち止まる時間")]
    [SerializeField] private float _stopTime = 5f;
    [SerializeField] private  float _initialValue = 5f;//汎用の初期値（テスト用）
    private float _currentDistance;
    public Vector2 _getVisionVec//VisionVecのプロパティ
    {
        get { return _visionVec; }
        set { _visionVec = value; }
    }
    private Transform _visionTrans;//自分の位置
    [Header("停止するか制御する")]
    [SerializeField] private bool _isStop = false;//停止させるためのフラグ
    public bool _existsIsStop
    {
        get { return _isStop; }
        set { _isStop = value; }
    }
    [Header("巡回させるか制御する")]
    [SerializeField] private bool _isPatrol = true;//パトロール中かどうか制御する
    public bool _existIsPatrol//isPatrolのプロパティ
    {
        get { return _isPatrol; }
        set { _isPatrol = value; }
    }
    
    private float _myRotation;//視線の角度 
    public float _getMyRotation//_myRotationのプロパティ
    {
        get { return _myRotation; }
        set { _myRotation = value; }
    }
    private float _radians;//角度を向きに変換するための変数
    private float _angleOffset = 15f;//hit2,hit3の角度調節に使う変数
    private float _currentRotation = default;//myRotationの値を取得するための変数
    private float _turnAroundTime = 0.5f;
    private float _turnAroundTimeValue = 0.5f;
    private float _presenceAngle;//衝突時に振り向かせるための変数
    private Vector2 _visionVec;//視線の向き
    private Vector2 Hit2Vec;
    private Vector2 Hit3Vec;
    RaycastHit2D _obstacleRay;//障害物を見分ける視線
    RaycastHit2D _presenceRay;//死角でもプレイヤーを察知できるようにする球状のレイ
    RaycastHit2D hit1;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    public RaycastHit2D GetHit1
    {
        get { return hit1;}
    }
    public RaycastHit2D GetHit2
    {
        get { return hit2; }
    }

    public RaycastHit2D GetHit3
    {
        get { return hit3; }
    }
    EnemyTracking GetTracking;
    // Start is called before the first frame update
    void Start()
    {               
        _visionTrans = this.GetComponent<Transform>();
        GetTracking = GetComponent<EnemyTracking>();
        //_currentDistance = _rayDistance;
        _myRotation = _visionTrans.rotation.z;//角度を取得
        if (_isPatrol)//警備中だったらEnemyMoveスクリプトで移動させる
        {
            switch (_direction)//最初に移動する方向
            {
                case MoveDirection.Up:
                    _myRotation = 90;
                    break;
                case MoveDirection.Down:
                    _myRotation = 270;
                    break;
                case MoveDirection.Right:
                    _myRotation = 0;
                    break;
                case MoveDirection.Left:
                    _myRotation = 180;
                    break;
            }
        }
        _currentRotation = _myRotation;//myRotationの値を取得
    }

    // Update is called once per frame
    void Update()
    {
        VisionConvert();
        hit1 = Physics2D.Raycast(_visionTrans.position, _visionVec, _rayDistance, _targetLayer);//正面のレイ
        //hit2 = Physics2D.Raycast(VisionTrans.position, Hit2Vec, _rayDistance, TargetLayer);
        //hit3 = Physics2D.Raycast(VisionTrans.position, Hit3Vec, _rayDistance, TargetLayer);
        Debug.DrawRay(_visionTrans.position, _visionVec * _rayDistance, Color.red);
        //Debug.DrawRay(VisionTrans.position, Hit2Vec * _rayDistance, Color.blue);
        //Debug.DrawRay(VisionTrans.position, Hit3Vec * _rayDistance, Color.green);
        _obstacleRay = Physics2D.Raycast(_visionTrans.position, _visionVec, _rayDistance, _obstacleLayer);//障害物を見分けるレイ
        _presenceRay = Physics2D.CircleCast(_visionTrans.position, _rayRadius, _visionVec, _maxDistance, _targetLayer);//死角でもプレイヤー察知できるようにするレイ
        //int _turnCount = default;
        if (_myRotation >= 360 && _isPatrol)//360度超えたら角度リセット
        {
            
            _myRotation -= 360;
            
            //print(_currentRotation);
        }
        else if (_myRotation < 0)
        {
           
            _myRotation += 360;
            
        }

        if (_isPatrol && _obstacleRay.collider != null && _obstacleRay.collider.gameObject != this.gameObject)//巡回時、障害物に当たったら
        {
            
            _myRotation += (int)_getAngle;//視線をGetAngleで指定した角度に傾かせる 　
            if (_myRotation >= 360 && _isPatrol)//360度超えたら角度リセット
            {

                _myRotation -= 360;
                _currentRotation = _myRotation;//再度myRotationの値を取得
                                               //print(_currentRotation);
            }
            else if (_myRotation < 0)
            {

                _myRotation += 360;
                _currentRotation = _myRotation;
            }
            //print(_myRotation);
        }

        if (_presenceRay&&!GetTracking._existIsTracking)//索敵範囲にプレイヤーが衝突したら
        {
            
            //print(PresenceRay.collider.gameObject.name);//テスト用に名前を取得する
            _isPatrol = false;//巡回をやめる
            _isStop = true;//立ち止まる
            //print(_myRotation);
                          //if (_turnCount == 1)
                          //{

            //    _turnCount++;

            //}
            if (_isStop == false)
            {
                _stopTime = _initialValue;
                _turnAroundTime = _turnAroundTimeValue;
            }
           

            _presenceAngle = Mathf.Atan2(_presenceRay.collider.transform.position.y, _presenceRay.collider.transform.position.x) * Mathf.Rad2Deg;//衝突したオブジェクトの座標を取得
            
        }
        else
        {
            //_turnCount = default;
        }

        if (_isStop)//止まったら
        {
            
            _stopTime -= Time.deltaTime;//立ち止まる時間をカウントダウン
            _turnAroundTime -= Time.deltaTime;//振り向くまでの時間をカウントダウン
            if (_turnAroundTime <= 0)//一定時間立ち止まったら
            {
                TurnAngle();//プレイヤーが視界内にいた位置に振り向く
               
            }
            if (_stopTime <= 0)//０秒になったら（振り向く前にプレイヤーが移動したら)
            {        
                _myRotation = _currentRotation;//_myRotationを巡回していた時の角度にもどす
                _isPatrol = true;//再び巡回させる
                _isStop = false;
                _stopTime = _initialValue;//初期値に戻す
                _turnAroundTime = _turnAroundTimeValue;//いずれマジックナンバー消す
            }
        }
    }

    /// <summary>
    ///  角度を向きに変換するメソッド
    /// </summary>
    void VisionConvert()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//視線の角度を向きに変換
        _visionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radiansから視線の向きを取得
        //float Hit2Angle = _myRotation + _angleOffset * Mathf.Deg2Rad;
        //Hit2Vec = new Vector2(Mathf.Cos(Hit2Angle), Mathf.Sin(Hit2Angle));
        //float Hit3Angle = _myRotation - _angleOffset * Mathf.Deg2Rad;
        //Hit3Vec = new Vector2(Mathf.Cos(Hit3Angle), Mathf.Sin(Hit3Angle));
    }

    /// <summary>
    ///  指定した角度に振り向かせるメソッド
    /// </summary>
    void TurnAngle()
    {
        _presenceAngle = Mathf.Atan2(_presenceRay.point.y, _presenceRay.point.x) * Mathf.Rad2Deg;//衝突したオブジェクトの座標を取得
        _myRotation = _presenceAngle;//PresenceAngleの値を取得してその値の向きに合わせる
    }

    void OnDrawGizmos()//PresenceRayを可視化
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(_visionTrans.position, _rayRadius);
    }

}
