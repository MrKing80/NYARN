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
    [Header("���񎞂̈ړ�����")]
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;
    [Header("���񎞂̊p�x����")]
    [SerializeField] private ChangeAngle GetAngle = ChangeAngle.One;//�f�t�H���g�͂X�O�x��]������
    [Header("��Q���̃��C���[")]
    [SerializeField] private LayerMask ObstacleLayer;
    [Header("���C�̋���  ")]
    [SerializeField] private float _rayDistance = 5f;
    private GameObject ParentObject;//�e�I�u�W�F�N�g���i�[����ꏊ
    public Vector2 VisionVec;//�����̌���
    public float _myRotation;//�����̊p�x
    public Transform VisionTrans;//�����̈ʒu
    [Header("���񂳂��邩���䂷��")]
    public bool isPatrol = true;//�p�g���[�������ǂ������䂷��
    private float _radians;//�p�x�������ɕϊ����邽�߂̐��l
    
    RaycastHit2D ObstacleRay;//��Q�����������鎋��
    // Start is called before the first frame update
    void Start()
    {
        ParentObject = transform.parent.gameObject;//�e�X�g�p�ɐe�I�u�W�F�N�g���擾        
        print(ParentObject.name);
        VisionTrans = this.GetComponent<Transform>();
        _myRotation = VisionTrans.rotation.z;//�����̊p�x���擾
        if (isPatrol)//�x������������EnemyMove�X�N���v�g�ňړ�������
        {
            switch (_direction)//�ŏ��Ɉړ��������
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
        VisionControl();
        ObstacleRay = Physics2D.Raycast(VisionTrans.position, VisionVec, _rayDistance, ObstacleLayer);
        if (isPatrol && ObstacleRay.collider!=null && ObstacleRay.collider.gameObject!=ParentObject)//���񎞁A��Q���ɓ���������
        {
            print("��������");
            _myRotation += (int)GetAngle;//������GetAngle�Ŏw�肵���p�x�ɌX������
        }

    }

    void VisionControl()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//�����̊p�x�������ɕϊ�
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//_radians���王���̌������擾
    }
}
