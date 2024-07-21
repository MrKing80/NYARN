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
    [Header("巡回時の移動方向")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;  
    public Vector2 VisionVec;//視線の向き
    public float _myRotation;//視線の角度
    public Transform VisionTrans;//自分の位置
    public bool isPatrol = true;//パトロール中かどうか制御する
    private float _radians;//角度を向きに変換するための数値
    RaycastHit2D TestRay;//テスト用のレイ
    // Start is called before the first frame update
    void Start()
    {
        VisionTrans = this.GetComponent<Transform>();
        _myRotation = VisionTrans.rotation.z;//視線の角度を取得
        if (isPatrol)
        {
            switch (_direction)
            {
                case MoveDirection.Right:
                    VisionVec = Vector2.right;
                    break;
                case MoveDirection.Left:
                    VisionVec = Vector2.left;
                    break;
                case MoveDirection.Up:
                    VisionVec = Vector2.up;
                    break;
                case MoveDirection.Down:
                    VisionVec = Vector2.down;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        VisionControl();             
    }

    void VisionControl()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//視線の角度を向きに変換
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radiansから視線の向きを取得
    }
}
