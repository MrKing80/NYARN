using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
   
    //RaycastHit2D GetRay;//自分の視線
    private Vector2 PlayerVec;//プレイヤーの位置を取得する
    private Vector2 MyVector;//自分の向き
    private Vector2 MoveDirection;
    private float _initialPosDistance;//初期位置と自分の距離
    private float _trakingTimeLimit = 10;
    private float _arertTimeLimit = 5;
    [SerializeField] GameObject PlayerObj;
    [Header("追跡時間")]
    [SerializeField] private float _trackingTime ;//追跡時間
    [Header("警戒時間")]
    [SerializeField] private float _alertTime;//警戒時間
    [Header("プレイヤーと自分の距離")]
    [SerializeField] private float _playerDistance;//プレイヤーと自分の距離 
    [Header("レイの距離  ")]
    [SerializeField] private float _rayDistance ;
    [Header("プレイヤーのレイヤー")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("プレイヤーの位置")]
    [SerializeField] Transform TargetTrans;//プレイヤーの位置
    [Header("自分の追跡速度")]
    [SerializeField] private float _trackingSpeed = 5;//敵のスピード
    [Header("追跡フラグ")]
    [SerializeField] private bool isTracking = false;//追跡フラグ
    public bool existIsTracking
    {
        get { return isTracking; }
        set { isTracking = value; }
    }
    Transform MyTrans;//自分の位置
    EnemyMove GetMove;//自分の動きを取得する
    EnemyVisionScript GetEnemyVision;//自分の視線を取得
    NavMeshAgent2D GetAgent2D;
    void Start()
    {
      
        GetMove = this.GetComponent<EnemyMove>();//自分の動きを取得
        GetAgent2D = this.GetComponent<NavMeshAgent2D>();//自分のNavMeshAgent2Dを取得
        MyTrans = GetMove.GetMyTrans;//自分のTransformを取得
        GetEnemyVision = GetComponent<EnemyVisionScript>();//子オブジェクトからEnemyVisionScriptを取得
        //GetAgent = this.GetComponent<NavMeshAgent>();
        //GetAgent.updateRotation = false;
        //GetAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        //_rayAngle = MyTrans.eulerAngles.z * Mathf.Deg2Rad;
        MyVector = GetMove.GetMyTrans.position;//自分の向きを取得
        //GetRay = Physics2D.Raycast(MyTrans.position, GetEnemyVision.GetVisonVec, _rayDistance, TargetLayer);//レイキャストを実行
      
        Debug.DrawRay(MyTrans.position, GetEnemyVision.GetVisonVec * _rayDistance, Color.red);//レイを可視化

        if (GetEnemyVision.GetHit1|| GetEnemyVision.GetHit2 || GetEnemyVision.GetHit3)//プレイヤーがレイに触れたら
        {
            isTracking = true;//追跡フラグをオンにする
            _trackingTime = _trakingTimeLimit;
            _alertTime = _arertTimeLimit;
        }

        else if (!GetEnemyVision.GetHit1 && isTracking)//レイにヒットしていないが、追いかけてる最中だったら
        {
            print("のがすな");
            _trackingTime -= Time.deltaTime;          
        }


        if (_trackingTime <= 0 &&_playerDistance >= 10)//プレイヤーを見失ったら  場合によってはorにする
        {
            TargetLost();
        }

        if (isTracking&&!PlayerObj.activeSelf&&_playerDistance>=5)//プレイヤーがロッカーに隠れた時のテスト
        {
            //print("非表示です");
            TargetLost();
        }

            if (isTracking)//追跡フラグがオンだったら
        {
            print("みいつけた！！");
            _playerDistance = Vector2.Distance(PlayerVec, MyVector);//自分とプレイヤーの距離を計算
            PlayerVec = TargetTrans.position;//プレイヤーの位置を取得
            GetAgent2D.SetDestination(TargetTrans.position);//プレイヤーを追い掛け回す
            GetEnemyVision.existIsPatrol = false;//警備をやめて追跡
            //GetAgent2D.enabled = true;
            //GetEnemyVision.GetVisonVec = (TargetTrans.position - MyTrans.position).normalized;
        }
    }

   //新しいメソッド書く
   void TargetLost()
    {
        isTracking = false;
        _alertTime -= Time.deltaTime;
        print("どこ？");
        if (_alertTime <= 0)//完全に見失ったら
        {
            print("つかれた");
            GetAgent2D.SetDestination(GetMove.GetInitialPos);
            _initialPosDistance = Vector2.Distance(MyVector, GetMove.GetInitialPos);
            if (MyVector == GetMove.GetInitialPos)//初期位置に戻ったら
            {
                GetEnemyVision.existIsPatrol = true;//警備再開させる
                //GetAgent2D.enabled = false;
                print(GetEnemyVision.existIsPatrol);
                print("警備再開");
            }
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//プレイヤーと追突したら追跡開始
        {
            isTracking = true;          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
