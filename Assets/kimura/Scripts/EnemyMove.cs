using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    //EnemyTracking GetTracking;

    EnemyVisionScript GetVison;
    NavMeshAgent2D Agent2D;
    public Transform MyTrans;
    public Vector2 MyVector;
    private float _initialDistance;
    [Header("自分の初期位置")]
    public Vector2 InitialPosition;//自分の初期位置  
    [Header("自分のスピード")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//自分のTransformを取得
        Agent2D=this.GetComponent<NavMeshAgent2D>();
        InitialPosition = MyTrans.position;//自分の初期位置を取得
        SetDirection();
        GetVison = GetComponentInChildren<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _initialDistance = Vector2.Distance(InitialPosition, MyVector);
        MyVector = MyTrans.position;//自分の向きを取得 
        MyTrans.Translate(GetVison.VisionVec * Time.deltaTime);//巡回させる
        //if (GetVison.isPatrol && _initialDistance >= 5)
        //{
        //    GetVison.VisionVec = (InitialPosition - MyVector).normalized;
        //    print("巡回"); 
        //}

        //else if(GetVison.isPatrol&&_initialDistance <= 0.01f)
        //{
        //    //GetVison.VisionVec =
        //}
    }
    void SetDirection()
    {
        
    }

}
