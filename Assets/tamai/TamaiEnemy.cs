using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TamaiEnemy : MonoBehaviour
{
    [SerializeField] private Transform targetPos = default;
    [SerializeField] private GameObject Destination;
    [SerializeField] private NavMeshAgent2D naviMashAgent;

    void Start()
    {
        naviMashAgent = GetComponent<NavMeshAgent2D>();
        //�ړI�n�̃I�u�W�F�N�g���擾
        Destination = GameObject.Find("Player");
        // �ړI�n�̏ꏊ��n��
        targetPos = Destination.transform;

        //�ړI�n��ݒ�
        naviMashAgent.SetDestination(targetPos.transform.position);
    }

    void Update()
    {
        // �ړI�n�̏ꏊ��n��
        targetPos = Destination.transform;
    }
}
