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
    [Header("�����̏����ʒu")]
    public Vector2 InitialPosition;//�����̏����ʒu  
    [Header("�����̃X�s�[�h")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//������Transform���擾
        Agent2D=this.GetComponent<NavMeshAgent2D>();
        InitialPosition = MyTrans.position;//�����̏����ʒu���擾
        SetDirection();
        GetVison = GetComponentInChildren<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _initialDistance = Vector2.Distance(InitialPosition, MyVector);
        MyVector = MyTrans.position;//�����̌������擾 
        MyTrans.Translate(GetVison.VisionVec * Time.deltaTime);//���񂳂���
        //if (GetVison.isPatrol && _initialDistance >= 5)
        //{
        //    GetVison.VisionVec = (InitialPosition - MyVector).normalized;
        //    print("����"); 
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
