using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public Vector2 VisionVec;//�����̌���
    private float _myRotation;//�����̊p�x
    private float _radians;//�p�x�������ɕϊ����邽�߂̐��l
    RaycastHit2D TestRay;//�e�X�g�p�̃��C

    // Start is called before the first frame update
    void Start()
    {
        _myRotation = this.transform.rotation.z;//�����̊p�x���擾
    }

    // Update is called once per frame
    void Update()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//�����̊p�x�������ɕϊ�
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//���W�A�����王���̌������擾
        TestRay = Physics2D.Raycast(this.transform.position, VisionVec, 5f);
        Debug.DrawRay(this.transform.position, VisionVec * 10f, Color.green);
        if (Input.GetKeyDown(KeyCode.Return))//���삷�邩�m���߂�e�X�g
        {
            _myRotation += 90;
            print("������");
        }
    }
}
