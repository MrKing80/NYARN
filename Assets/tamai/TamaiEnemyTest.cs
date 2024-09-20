using UnityEngine;
using UnityEngine.AI;

public class TamaiEnemyTest : MonoBehaviour
{
    // �i�r���b�V���擾
    [SerializeField] private NavMeshAgent enemyNav;
    // �ړI�n�I�u�W�F
    [SerializeField] private GameObject Destination;
    // �^�[�Q�b�g�̈ʒu���L�^
    [SerializeField] private Vector3 targetPos = default;

    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        //�ړI�n�̃I�u�W�F�N�g���擾
        Destination = GameObject.FindWithTag("Player");
        // �ړI�n�̏ꏊ��n��
        targetPos = Destination.transform.position;
        // 2D�Ή��p�炵��
        enemyNav.updateRotation = false;
        enemyNav.updateUpAxis = false;
        //�ړI�n��ݒ�
        enemyNav.SetDestination(targetPos);
    }

    private void FixedUpdate()
    {
        // �o�H�T���̏������ł��Ă��邩�A�ڕW�n�_�̊Ԃ̋�����0.1f�ȏォ
        if (enemyNav.pathPending || enemyNav.remainingDistance > 0.1f)
        {
            return;
        }
        // �ړI�n�̏ꏊ��n��
        targetPos = Destination.transform.position;
        //�ړI�n��ݒ�
        enemyNav.SetDestination(targetPos);
 }
}
