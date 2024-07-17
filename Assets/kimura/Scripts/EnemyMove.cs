using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyTracking GetTracking;
    public Transform MyTrans;
    public Vector2 MyVector;
    [Header("自分の初期位置")]
    public Vector2 InitialPosition;//自分の初期位置  
    [Header("自分のスピード")]
    [SerializeField] private float _moveSpeed = 3f;
    public Vector2 MoveDirection;
    
    void Start()
    {
        GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//自分のTransformを取得
        InitialPosition = MyTrans.position;//自分の初期位置を取得
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        MyVector = MyTrans.position;//自分の向きを取得 
        
    }
    void SetDirection()
    {
        MoveDirection = MyTrans.right;//向きは仮です
    }

}
