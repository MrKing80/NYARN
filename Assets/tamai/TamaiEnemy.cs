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
        //目的地のオブジェクトを取得
        Destination = GameObject.Find("Player");
        // 目的地の場所を渡す
        targetPos = Destination.transform;

        //目的地を設定
        naviMashAgent.SetDestination(targetPos.transform.position);
    }

    void Update()
    {
        // 目的地の場所を渡す
        targetPos = Destination.transform;
    }
}
