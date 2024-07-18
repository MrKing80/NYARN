using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public Vector2 VisionVec;//�����̌���
    public float _myRotation;//�����̊p�x
    public Transform VisionTrans;
    public bool isPatrol = true;
    private float _radians;//�p�x�������ɕϊ����邽�߂̐��l
    RaycastHit2D TestRay;//�e�X�g�p�̃��C
    // Start is called before the first frame update
    void Start()
    {
        VisionTrans = this.GetComponent<Transform>();
        _myRotation = VisionTrans.rotation.z;//�����̊p�x���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrol)
        {
            VisionControl();
        }
       
        if (Input.GetKeyDown(KeyCode.Return))//���삷�邩�m���߂�e�X�g
        {
            _myRotation += 90;
            print("������");
            
        }
    }

    void VisionControl()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//�����̊p�x�������ɕϊ�
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//���W�A�����王���̌������擾
    }
}
