using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    //EnemyTracking GetTracking;
    EnemyVisionScript GetVison;
    public Transform MyTrans;
    public Vector2 MyVector;
    [Header("�����̏����ʒu")]
    public Vector2 InitialPosition;//�����̏����ʒu  
    [Header("�����̃X�s�[�h")]
    [SerializeField] private float _moveSpeed = 4f;
    
    
    void Start()
    {
        //GetTracking = this.GetComponent<EnemyTracking>();
        MyTrans = this.GetComponent<Transform>();//������Transform���擾
        InitialPosition = MyTrans.position;//�����̏����ʒu���擾
        SetDirection();
        GetVison = GetComponentInChildren<EnemyVisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MyVector = MyTrans.position;//�����̌������擾 
        MyTrans.Translate(GetVison.VisionVec * Time.deltaTime);//���񂳂���
        
    }
    void SetDirection()
    {
        
    }

}
