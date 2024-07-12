using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rig2D;
    RaycastHit2D GetRay;
    RaycastHit2D ObstacleRay;
    private Vector2 PlayerVec;//プレイヤーの位置を取得する
    private Vector2 MyVector;
    [SerializeField] private float _trackingTime = 0;//追跡時間
    [SerializeField] private float _alertTime = 0;//警戒時間
    [Header("プレイヤーと自分の距離")]
    [SerializeField] private float _distance;//プレイヤーと自分の距離
    [Header("自分の初期位置")]
  　[SerializeField]private Vector2 InitialPosition;//自分の初期位置  
    [Header("レイの距離  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("プレイヤーのレイヤー")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("障害物のレイヤー")]
    [SerializeField] private LayerMask ObstacleLayer;    
    [Header("プレイヤーの位置")]
    [SerializeField] Transform TargetPos;//プレイヤーの位置
    [Header("自分のスピード")]
    [SerializeField] private float _moveSpeed = 5;//敵のスピード
    [Header("追跡フラグ")]
    [SerializeField] private bool TrackingFlag = false;//追跡フラグ
    private int Hit;
    Transform MyTrans;//自分の位置
    void Start()
    {
        Rig2D = this.GetComponent<Rigidbody2D>();
        MyTrans = this.GetComponent<Transform>();//自分のTransformを取得
        InitialPosition = MyTrans.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        MyVector = MyTrans.position;//自分の向きを取得
        //ローテーションをヴェクターに突っ込めばいいかもしれない
        GetRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, TargetLayer);//レイキャストを実行（向きは仮）
        ObstacleRay = Physics2D.Raycast(MyTrans.position, MyTrans.right, _rayDistance, ObstacleLayer);
        Debug.DrawRay(MyTrans.position, MyTrans.right * _rayDistance, Color.red);//レイを可視化

        if (GetRay)//プレイヤーがレイに触れたら
        {
            TrackingFlag = true;
            _trackingTime = 0;
            _alertTime = 0;
        }

        else if (!GetRay && TrackingFlag)//レイにヒットしていないが、追いかけてる最中だったら
        {
            print("のがすな");
            print("自分の位置は"+MyVector);
            _trackingTime += Time.deltaTime;          
        }

        if (_trackingTime >= 10 && _distance >= 20)//プレイヤーを見失ったら  場合によってはorにする
        {
            TrackingFlag = false;          
            _alertTime += Time.deltaTime;
            print("どこ？");
            if (_alertTime >= 10)
            {
                //初期位置に戻る
                MyTrans.position = Vector2.MoveTowards(MyTrans.position, InitialPosition, _moveSpeed * Time.deltaTime);
                print("つかれた");
            }
        }

        if (TrackingFlag)//追跡フラグがオンだったら
        {
            _distance = Vector2.Distance(PlayerVec, MyVector);
            PlayerVec = TargetPos.position;//プレイヤーの位置を取得
            print("距離は" + _distance);
            //プレイヤーを追い掛け回す
            MyTrans.position = Vector2.MoveTowards(MyTrans.position, new Vector2(TargetPos.position.x, TargetPos.position. y), _moveSpeed * Time.deltaTime);
        }
    }

   
}
