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
    [Header("���񎞂̈ړ�����")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;  
    public Vector2 VisionVec;//�����̌���
    public float _myRotation;//�����̊p�x
    public Transform VisionTrans;//�����̈ʒu
    public bool isPatrol = true;//�p�g���[�������ǂ������䂷��
    private float _radians;//�p�x�������ɕϊ����邽�߂̐��l
    RaycastHit2D TestRay;//�e�X�g�p�̃��C
    // Start is called before the first frame update
    void Start()
    {
        VisionTrans = this.GetComponent<Transform>();
        _myRotation = VisionTrans.rotation.z;//�����̊p�x���擾
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
        _radians = _myRotation * Mathf.Deg2Rad;//�����̊p�x�������ɕϊ�
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radians���王���̌������擾
    }
}
