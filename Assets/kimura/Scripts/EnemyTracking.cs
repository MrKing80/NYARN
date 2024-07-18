using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rig2D;
    RaycastHit2D GetRay;//自分の視線
    RaycastHit2D ObstacleRay;
    private Vector2 PlayerVec;//プレイヤーの位置を取得する
    private Vector2 MyVector;//自分の向き
    private Vector2 MoveDirection;
    private float _obstacleDistance;
    private float _rayAngle;
    [Header("追跡時間")]
    [SerializeField] private float _trackingTime = 0;//追跡時間
    [Header("警戒時間")]
    [SerializeField] private float _alertTime = 0;//警戒時間
    [Header("プレイヤーと自分の距離")]
    [SerializeField] private float _playerDistance;//プレイヤーと自分の距離 
    [Header("レイの距離  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("プレイヤーのレイヤー")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("障害物のレイヤー")]
    [SerializeField] private LayerMask ObstacleLayer;    
    [Header("プレイヤーの位置")]
    [SerializeField] Transform TargetTrans;//プレイヤーの位置
    [Header("自分の追跡速度")]
    [SerializeField] private float _trackingSpeed = 5;//敵のスピード
    [Header("追跡フラグ")]
    [SerializeField] private bool TrackingFlag = false;//追跡フラグ
    Transform MyTrans;//自分の位置
    EnemyMove GetMove;
    EnemyVisionScript GetEnemyVision;
    void Start()
    {
        Rig2D = this.GetComponent<Rigidbody2D>();
        GetMove = this.GetComponent<EnemyMove>();//自分の動きを取得
        MyTrans = GetMove.MyTrans;//自分のTransformを取得
        GetEnemyVision = GetComponentInChildren<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //_rayAngle = Mathf.Atan2(PlayerVec.y, PlayerVec.x) * Mathf.Rad2Deg;
        //_rayAngle = MyTrans.eulerAngles.z * Mathf.Deg2Rad;
        MyVector = GetMove.MyTrans.position;//自分の向きを取得
        //ローテーションをヴェクターに突っ込めばいいかもしれない
        GetRay = Physics2D.Raycast(MyTrans.position, GetEnemyVision.VisionVec, _rayDistance, TargetLayer);//レイキャストを実行（向きは仮）
        ObstacleRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, ObstacleLayer);//障害物を識別するレイキャストを実行
        Debug.DrawRay(MyTrans.position, GetEnemyVision.VisionVec * _rayDistance, Color.red);//レイを可視化

        if (GetRay)//プレイヤーがレイに触れたら
        {
            TrackingFlag = true;
            _trackingTime = 0;
            _alertTime = 0;
        }

        else if (!GetRay && TrackingFlag)//レイにヒットしていないが、追いかけてる最中だったら
        {
            print("のがすな");
            _trackingTime += Time.deltaTime;          
        }


        if (_trackingTime >= 10 && _playerDistance >= 20)//プレイヤーを見失ったら  場合によってはorにする
        {
            TrackingFlag = false;          
            _alertTime += Time.deltaTime;
            print("どこ？");
            if (_alertTime >= 10)
            {
                //初期位置に戻る
                MyTrans.position = Vector2.MoveTowards(MyTrans.position, GetMove.InitialPosition, _trackingSpeed * Time.deltaTime);
                print("つかれた");
            }
        }


        //if (ObstacleRay)//レイの距離のテスト
        //{
        //    print("ぶつかった");
        //    _obstacleDistance = Vector2.Distance(ObstacleRay.collider.gameObject.transform.position, MyVector);
        //    _rayDistance -= _obstacleDistance;
        //}

       


        if (TrackingFlag)//追跡フラグがオンだったら
        {
            _playerDistance = Vector2.Distance(PlayerVec, MyVector);//自分とプレイヤーの距離を計算
            print("黙って帰るよくない！！！");
            PlayerVec = TargetTrans.position;//プレイヤーの位置を取得
            MyTrans.position = Vector2.MoveTowards(MyTrans.position, new Vector2(TargetTrans.position.x, TargetTrans.position. y), _trackingSpeed * Time.deltaTime); //プレイヤーを追い掛け回す
            //GetRay = Physics2D.Raycast(MyTrans.position, new Vector2(Mathf.Cos(_rayAngle), Mathf.Sin(_rayAngle)), _rayDistance, TargetLayer);
            MoveDirection = TargetTrans.position - MyTrans.position;
            _rayAngle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            GetEnemyVision.VisionTrans.rotation = Quaternion.Euler(new Vector3(0, 0, _rayAngle));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//プレイヤーと追突したら追跡開始
        {
            TrackingFlag = true;
           
        }
    }
}
