using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    public enum ChangeAngle
    {
        One = 90,
        Two = 180,
        Tree = 270
    }
    [Header("巡回時の移動方向")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;//デフォルトは右向き
    [Header("巡回時の角度調節")]
    [SerializeField] private ChangeAngle GetAngle = ChangeAngle.One;//デフォルトは９０度回転させる
    [Header("障害物のレイヤー")]
    [SerializeField] private LayerMask ObstacleLayer;
    [Header("プレイヤーのレイヤー")]
    [SerializeField] private LayerMask TargetLayer;
    [Header("レイの距離  ")]
    [SerializeField] private float _rayDistance = 5f;
    [Header("レイの半径")]
    [SerializeField] private float _rayRadius = 1f;
    [SerializeField] private float _maxDistance = 10f;
    public Vector2 GetVisonVec//VisionVecのプロパティ
    {
        get { return VisionVec; }
        set { VisionVec = value; }
    }
    private Transform VisionTrans;//自分の位置
    [Header("巡回させるか制御する")]
    private bool isPatrol = true;//パトロール中かどうか制御する
    public bool existIsPatrol//isPatrolのプロパティ
    {
        get { return isPatrol; }
        set { isPatrol = value; }
    }
    private float _myRotation;//視線の角度 
    public float GetMyRotation
    {
        get { return _myRotation; }
        set { _myRotation = value; }
    }
    private float _radians;//角度を向きに変換するための数値
    private float _angleOffset = 15f;
    private GameObject ParentObject;//親オブジェクトを格納する場所
    private Vector2 VisionVec;//視線の向き
    private Vector2 Hit2Vec;
    private Vector2 Hit3Vec;
    RaycastHit2D ObstacleRay;//障害物を見分ける視線
    RaycastHit2D PresenceRay;
    EnemyTracking GetTracking;
    // Start is called before the first frame update
    void Start()
    {
        ParentObject = transform.parent.gameObject;//テスト用に親オブジェクトを取得        
        print(ParentObject.name);
        VisionTrans = this.GetComponent<Transform>();
        GetTracking = GetComponentInParent<EnemyTracking>();
        _myRotation = VisionTrans.rotation.z;//視線の角度を取得
        if (isPatrol)//警備中だったらEnemyMoveスクリプトで移動させる
        {
            switch (_direction)//最初に移動する方向
            {
                case MoveDirection.Up:
                    _myRotation += 90;
                    break;
                case MoveDirection.Down:
                    _myRotation += 270;
                    break;
                case MoveDirection.Right:
                    _myRotation += 0;
                    break;
                case MoveDirection.Left:
                    _myRotation += 180;
                    break;           
            }          
        }
    }

    // Update is called once per frame
    void Update()
    {
        VisionConvert();
      
        RaycastHit2D hit1 = Physics2D.Raycast(VisionTrans.position, VisionVec, _rayDistance, TargetLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(VisionTrans.position,Hit2Vec, _rayDistance, TargetLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(VisionTrans.position,Hit3Vec, _rayDistance, TargetLayer);
        Debug.DrawRay(VisionTrans.position, GetVisonVec * _rayDistance, Color.red);
        Debug.DrawRay(VisionTrans.position, Hit2Vec * _rayDistance, Color.blue);
        Debug.DrawRay(VisionTrans.position, Hit3Vec * _rayDistance, Color.green);
        ObstacleRay = Physics2D.Raycast(VisionTrans.position, VisionVec, _rayDistance, ObstacleLayer);//障害物を見分けるレイ
        PresenceRay = Physics2D.CircleCast(VisionTrans.position, _rayRadius, VisionVec,_maxDistance,TargetLayer);//死角でもプレイヤー察知できるようにするレイ
      
        if (isPatrol && ObstacleRay.collider!=null && ObstacleRay.collider.gameObject!=ParentObject)//巡回時、障害物に当たったら
        {
            print("あたった");
            _myRotation += (int)GetAngle;//視線をGetAngleで指定した角度に傾かせる
            print(_myRotation);
            if (_myRotation >= 360)//角度リセットの仮組
            {
                _myRotation -= 360;
            }

            //３６０度超えたらリセットする仕組み必要かも
        }
        if (PresenceRay)
        {
            print("なんや?");
            print(PresenceRay.collider.gameObject.name);//テスト用に名前を取得する
            TurnAngle();//当たったオブジェクトの位置に振り向く
        }

        if (hit1 || hit2 || hit3)
        {

        }

    }

    void VisionConvert()//角度を向きに変換するメソッド
    {
        _radians = _myRotation * Mathf.Deg2Rad;//視線の角度を向きに変換
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radiansから視線の向きを取得
        float Hit2angle = _myRotation + _angleOffset * Mathf.Deg2Rad;
        Hit2Vec = new Vector2(Mathf.Cos(Hit2angle), Mathf.Sin(Hit2angle));
        float Hit3angle = _myRotation - _angleOffset * Mathf.Deg2Rad;
         Hit3Vec = new Vector2(Mathf.Cos(Hit3angle), Mathf.Sin(Hit3angle));
    }

    void TurnAngle()
    {
        float PresenceAngle = Mathf.Atan2(PresenceRay.collider.gameObject.transform.position.y, PresenceRay.collider.gameObject.transform.position.x) * Mathf.Rad2Deg;
        _myRotation = PresenceAngle;
        isPatrol = false;
    }

    void OnDrawGizmos()//PresenceRayを可視化
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(VisionTrans.position, _rayRadius);
        
    }

  
}
